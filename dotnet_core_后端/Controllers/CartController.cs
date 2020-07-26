using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet期末项目.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNet期末项目.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        //添加购物车
        [HttpPost("/addCart")]
        public async Task<ActionResult> AddCart([FromForm]Cart cart)
        {
            CartContext cartContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.CartContext)) as CartContext;

            if (await cartContext.AddCart(cart))
            {
                return Ok("Add to cart successfully!");
            }
            return StatusCode(500, "Fail!");
        }

        //查看购物车
        [HttpGet("/showCart")]
        public async Task<ActionResult> ShowCart()
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            CartContext cartContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.CartContext)) as CartContext;
            return Ok(await cartContext.Check(username));
        }

        //删除购物车
        [HttpGet("/deleteCart")]
        public async Task<ActionResult> DeleteCart(string username, string goodname)
        {
            CartContext cartContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.CartContext)) as CartContext;
            bool result = await cartContext.DeleteOne(username, goodname);
            if (result)
            {
                return Ok("Delete successfully!");
            }
            return StatusCode(500, "Fail!");
        }
    }
}