using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotNet期末项目.Models;
using System.Net;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace dotNet期末项目.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AccountController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //注册
        [HttpPost("/signup")]
        public async Task<ActionResult> Signup([FromForm]Account account)
        {
            AccountContext accountContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.AccountContext)) as AccountContext;
            
            //如果该用户名已被注册
            if (await accountContext.SelectOne(account.Username) != null)
            {
                return BadRequest("用户名已存在");
            }

            /*
             * 【说明】此处用 await 执行 addAccount 函数时，不会同步执行后面的 if(result) 语句，而是说执行该请求的线程能同时执行其他的而请求。
             */
            bool result = await accountContext.AddAcount(account);

            if (result)
            {
                //创建默认头像
                string source = Path.Combine(_hostingEnvironment.WebRootPath, "img", "avator.jpg");
                string dest = Path.Combine(_hostingEnvironment.WebRootPath, "avator", account.Username + ".jpg");
                System.IO.File.Copy(source, dest, true);
                
                return Ok("成功注册账号");
            }

            return StatusCode(500,"数据库错误");
        }

        //登录
        [HttpPost("/signin")]
        public async Task<ActionResult> Signin([FromForm]Account account)
        {
            AccountContext accountContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.AccountContext)) as AccountContext;

            //判断用户是否存在
            string username = account.Username;
            Account target_account = await accountContext.SelectOne(username);
            if (target_account == null)
            {
                return BadRequest("用户名不存在");
            }

            //判断密码是否正确
            string real_pswd = target_account.Password;
            if (account.Password == real_pswd)
            {
                Response.Cookies.Append("username", username);
                return Ok("登录成功");
            }

            return BadRequest("密码错误");
        }

        //判断当前浏览器是否登录
        [HttpGet("/isSign")]
        public ActionResult IsSign()
        {
            Request.Cookies.TryGetValue("username",out string username);
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("未登录");
            }
            return Ok("已登录");
        }

        //获得当前用户的用户名
        [HttpGet("/getUsername")]
        public ActionResult GetUsername()
        {
            Request.Cookies.TryGetValue("username", out string username);
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("未登录");
            }
            return Ok(username);
        }
    }
}