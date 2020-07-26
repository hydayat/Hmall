using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet期末项目.Models
{
	public class CartContext
	{
		//连接字符串
		private string ConnectionString { get; set; }

		//构造函数，用于初始化连接字符串
		public CartContext(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		//建立数据库连接
		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(ConnectionString);
		}

		//添加购物车
		public async Task<bool> AddCart(Cart cart)
		{
			bool result;
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"insert into cart(username, goodname, price, amount) values(@username, @goodname, @price, @amount)"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", cart.Username));
				cmd.Parameters.Add(new MySqlParameter("@goodname", cart.Goodname));
				cmd.Parameters.Add(new MySqlParameter("@price", cart.Price));
				cmd.Parameters.Add(new MySqlParameter("@amount", cart.Amount));
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

		//删除一项
		public async Task<bool> DeleteOne(string username, string goodname)
		{
			bool result;
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"delete from cart where username=@username and goodname=@goodname"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", username));
				cmd.Parameters.Add(new MySqlParameter("@goodname", goodname));
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

		//查询某人的购物车
		public async Task<List<Cart>> Check(string username)
		{
			List<Cart> carts = new List<Cart>();
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"select * from cart where username=@username"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", username));
				//执行 sql 操作
				using (DbDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						carts.Add(new Cart()
						{
							Username = reader.GetString("username"),
							Goodname = reader.GetString("goodname"),
							Price = reader.GetInt32("price"),
							Amount = reader.GetInt32("amount")
						});
					}
				}
				return carts;
			}
		}
	}
}
