using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSharpInvokeCSharp.CSharpDemo;
using System.Reflection;
using System.Runtime.Loader;
using dotNet期末项目.Interop;
using System.Threading;
using CppCLR;

namespace dotNet期末项目.Controllers
{
    [ApiController]
    public class AvatorController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AvatorController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //上传待处理的图片
        [HttpPost("/tmpAvator")]
        public ActionResult UploadTmpAvator([FromForm] IFormFile file)
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            if (file == null)
                return BadRequest();

            //将图片存至本地
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator");
            string filePath = Path.Combine(uploadsFolder, username+".jpg");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            //添加三个滤镜
            ThreadPool.QueueUserWorkItem(new WaitCallback(t =>
            {
                CPPDLL.erode(filePath);
            }));
            ThreadPool.QueueUserWorkItem(new WaitCallback(t =>
            {
                CPPDLL.blur(filePath);
            }));
            ThreadPool.QueueUserWorkItem(new WaitCallback(t =>
            {
                CPPDLL.edge(filePath);
            }));

            return Ok("tmpAvator/" + username + ".jpg");

            /*Thread.Sleep(2000);
            return Ok("tmpAvator/byd.jpg");*/
        }

        [HttpGet("/tmpAvator")]
        public ActionResult AddFilter(string type)
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            //获取待处理图片的位置
            /*string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + ".jpg");
            switch (type)
            {
                case "0":
                    //暂时没有操作
                    break;
                case "1":
                    CPPDLL.erode(filePath);
                    break;
                case "2":
                    CPPDLL.blur(filePath);
                    break;
                case "3":
                    CPPDLL.edge(filePath);
                    break;
                default:
                    return BadRequest();
            }*/
            return Ok("tmpAvator/"+ username + "_" + type + ".jpg");

            /*switch (type) {
                case "1":
                    return Ok("tmpAvator/byd_1.jpg");
                case "2":
                    return Ok("tmpAvator/byd_2.jpg");
                case "3":
                    return Ok("tmpAvator/byd_3.jpg");
                default:
                    return Ok("tmpAvator/byd.jpg");
            }*/
            
        }

        [HttpPut("/avator")]
        public ActionResult SetAvator(string type)
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            //更换头像文件
            string sourcePath = Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + "_" + type + ".jpg");
            string targetPath = Path.Combine(_hostingEnvironment.WebRootPath, "avator", username + ".jpg");
            if (System.IO.File.Exists(sourcePath))
            {
                System.IO.File.Copy(sourcePath, targetPath, true);

                //清空临时文件
                System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + ".jpg"));
                System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + "_1.jpg"));
                System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + "_2.jpg"));
                System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", username + "_3.jpg"));

                return Ok();
            }

            return BadRequest();

            /*Request.Cookies.TryGetValue("username", out string username);
            string sourcePath = Path.Combine(_hostingEnvironment.WebRootPath, "tmpAvator", "byd_" + type + ".jpg");
            string targetPath = Path.Combine(_hostingEnvironment.WebRootPath, "avator", username + ".jpg");
            System.IO.File.Copy(sourcePath, targetPath, true);
            return Ok();*/
        }
    }
}