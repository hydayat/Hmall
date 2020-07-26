using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace dotNet期末项目.Models
{
	public class AccountContext
	{
		//连接字符串
		private string ConnectionString { get; set; }

		//构造函数，用于初始化连接字符串
		public AccountContext(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		//建立数据库连接
		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(this.ConnectionString);
		}

		//查看所有的用户
		public List<Account> GetAccounts()
		{
			List<Account> list = new List<Account>();
			// 连接数据库
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand mySqlCommand = new MySqlCommand("select * from account", mySqlConnection);
				//执行 sql 语句
				using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						list.Add(new Account()
						{
							Username = reader.GetString("username"),
							Password = reader.GetString("password")
						});
					}
				}
			}
			return list;
		}

		//查看某个用户
		public async Task<Account> SelectOne(string username)
		{
			Account account;
			// 连接数据库
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"select * from account where username=@username"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", username));
				//执行 sql 语句
				using (DbDataReader reader = await cmd.ExecuteReaderAsync())
				{
					if (reader.Read())//该用户存在
					{
						account = new Account()
						{
							Username = reader.GetString("username"),
							Password = reader.GetString("password")
						};
					}
					else//该用户不存在
					{
						account = null;
					}
				}
			}
			return account;
		}

		//增加一个用户
		public async Task<bool> AddAcount(Account account)
		{
			bool result;
			using (MySqlConnection mySqlConnection = GetConnection())
			{
				mySqlConnection.Open();
				//初始化 sql 语句
				MySqlCommand cmd = new MySqlCommand
				{
					Connection = mySqlConnection,
					CommandText = @"insert into account(username, password) values(@username, @password)"
				};
				cmd.Parameters.Add(new MySqlParameter("@username", account.Username));
				cmd.Parameters.Add(new MySqlParameter("@password", account.Password));
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
	}

}
