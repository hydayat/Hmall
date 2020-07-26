using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using 订单报告库;

namespace dotNet期末项目.Models
{
	public class OrdersContext
	{
		//连接字符串
		private string ConnectionString { get; set; }

		//构造函数，用于初始化连接字符串
		public OrdersContext(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		//建立数据库连接
		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(this.ConnectionString);
		}

		//创建一个订单
		public async Task<bool> CreateOrder(Orders orders)
		{
			bool result;
			//获取数据库连接
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				//建立连接
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"insert into orders(username, goodname, price, amount, time) values(@username, @goodname, @price, @amount, @time)"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", orders.Username));
				cmd.Parameters.Add(new MySqlParameter("@goodname", orders.Goodname));
				cmd.Parameters.Add(new MySqlParameter("@price", orders.Price));
				cmd.Parameters.Add(new MySqlParameter("@amount", orders.Amount));
				cmd.Parameters.Add(new MySqlParameter("@time", orders.Time));
				//执行 sql 操作
				try
				{
					await cmd.ExecuteNonQueryAsync();
					result = true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					result = false;
				}
			}
			return result;
		}

		//查看某用户的所有订单
		public async Task<List<Orders>> ShowOrders(string username)
		{
			List<Orders> orders = new List<Orders>();
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"select * from orders where username=@username"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", username));
				//执行 sql 操作
				using (DbDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						orders.Add(new Orders()
						{
							Username = reader.GetString("username"),
							Goodname = reader.GetString("goodname"),
							Price = reader.GetInt32("price"),
							Amount = reader.GetInt32("amount"),
							Time = reader.GetDateTime("time")
						});
					}
				}
				return orders;
			}
		}
	}
}
