using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet期末项目.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Sharing;
using 订单报告库;
using COM_test;
using CppCLR;

namespace dotNet期末项目.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //下单
        [HttpPost("/createOrder")]
        public async Task<ActionResult> CreateOrder([FromForm]Orders order)
        {
            DateTime time = DateTime.Now;
            order.Time = time;

            OrdersContext ordersContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.OrdersContext)) as OrdersContext;
            bool result = await ordersContext.CreateOrder(order);
            if (result)
            {
                return Ok("Create Successfully!");
            }
            return StatusCode(500, "Fail!");
        }

        //查看某人所有订单
        [HttpGet("/showOrders")]
        public async Task<ActionResult> ShowOrders()
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            OrdersContext ordersContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.OrdersContext)) as OrdersContext;
            return Ok(await ordersContext.ShowOrders(username));
        }

        //计算顺丰运费
        [HttpGet("/freight")]
        public ActionResult CalculateFreight(string place, double weight)
        {
            //return Ok(CppCLR.Calculator.GetCalculator().Calculate(place, weight));
            return Ok(Sharing.Calculator.GetCalculator().Calculate(place, weight));
        }

        //计算中通运费
        [HttpGet("/freight2")]
        public ActionResult CalculateFreight2(string place, double weight)
        {
            return Ok(ZhongTongFreightCalculator.Calculator.GetCalculator().Calculate(place, weight));
        }

        //计算圆通运费
        [HttpGet("/freight3")]
        public ActionResult CalculateFreight3(string place, double weight)
        {
            var tmp = new COM_test.Class1();
            return Ok(tmp.Calculate(place, weight));
        }

        [HttpGet("/orderReport")]
        public async Task<ActionResult> GetOrderReport()
        {
            //从Cookie中获取用户的名字
            Request.Cookies.TryGetValue("username", out string username);

            //获取该用户所有订单
            OrdersContext ordersContext = HttpContext.RequestServices.GetService(typeof(dotNet期末项目.Models.OrdersContext)) as OrdersContext;
            List<Orders> orders = await ordersContext.ShowOrders(username);

            //生成报告
            Report report = ReportGenerator.GenerateReport(orders);
            return Ok(report);
        }
    }
}