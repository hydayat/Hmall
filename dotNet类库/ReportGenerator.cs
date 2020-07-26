using System;
using System.Collections.Generic;

namespace 订单报告库
{
	public class Orders
	{
		public string Username { get; set; }
		public string Goodname { get; set; }
		public int Price { get; set; }
		public int Amount { get; set; }
		public DateTime Time { get; set; }
	}

	public class Report
	{
		public Report()
		{
			TotalCash = 0;
			TotalAmount = 0;
			OrderCnt = 0;
			MaxCash = 0;
			MinCash = int.MaxValue;
			MaxAmount = 0;
			MinAmount = int.MaxValue;
			MeanCash = 0;
			MeanAmount = 0;
			MaxTime = new DateTime();
			MinTime = DateTime.Now;
			M1A1 = 0;
			M1A2 = 0;
			M41 = 0;
			MarderIII = 0;
			Merkava = 0;
			Panther = 0;
			Wespe = 0;
			T55A = 0;
			StugIII = 0;
			M109A3G = 0;
			Challenger = 0;
			Chieftain = 0;
			Hetzer = 0;
			JS3 = 0;
			M4 = 0;
			M26 = 0;
			M60A1 = 0;
			M2A2 = 0;
		}
		public int TotalCash { get; set; } //总购买金额
		public int TotalAmount { get; set; }//购买商品总数
		public int OrderCnt { get; set; }  //订单总数
		public int MaxCash { get; set; }   //单笔最高购买金额
		public int MinCash { get; set; }   //单笔最低购买金额
		public int MaxAmount { get; set; } //单笔最高购买数量
		public int MinAmount { get; set; } //单笔最低购买数量
		public int MeanCash { get; set; }  //平均每单购买金额
		public int MeanAmount { get; set; }//平均每单购买数量
		public DateTime MaxTime { get; set; } //最近购买时间
		public DateTime MinTime { get; set; } //第一次购买时间

		public int M1A1 { get; set; }
		public int M1A2 { get; set; }
		public int M41 { get; set; }
		public int MarderIII { get; set; }
		public int Merkava { get; set; }
		public int Panther { get; set; }
		public int Wespe { get; set; }
		public int T55A { get; set; }
		public int StugIII { get; set; }
		public int M109A3G { get; set; }
		public int Challenger { get; set; }
		public int Chieftain { get; set; }
		public int Hetzer { get; set; }
		public int JS3 { get; set; }
		public int M4 { get; set; }
		public int M26 { get; set; }
		public int M60A1 { get; set; }
		public int M2A2 { get; set; }
	}

	public class ReportGenerator
	{
		public static Report GenerateReport(List<Orders> orders)
		{
			Report report = new Report();

			foreach (Orders order in orders)
			{
				//提取有用的信息
				string goodName = order.Goodname;
				int price = order.Price * order.Amount;
				int amount = order.Amount;
				DateTime time = order.Time;

				//更新报告
				report.TotalCash += price;
				report.TotalAmount += amount;
				report.OrderCnt += 1;
				if (price > report.MaxCash)
					report.MaxCash = price;
				if (price < report.MinCash)
					report.MinCash = price;
				if (amount > report.MaxAmount)
					report.MaxAmount = amount;
				if (amount < report.MinAmount)
					report.MinAmount = amount;
				if (DateTime.Compare(time, report.MinTime) < 0)
					report.MinTime = time;
				if (DateTime.Compare(time, report.MaxTime) > 0)
					report.MaxTime = time;

				switch (goodName)
				{
					case "M1A1":
						report.M1A1 += amount;
						break;
					case "M1A2":
						report.M1A2 += amount;
						break;
					case "M41":
						report.M41 += amount;
						break;
					case "MarderIII":
						report.MarderIII += amount;
						break;
					case "Merkava":
						report.Merkava += amount;
						break;
					case "Panther":
						report.Panther += amount;
						break;
					case "Wespe":
						report.Wespe += amount;
						break;
					case "T-55A":
						report.T55A += amount;
						break;
					case "StugIII":
						report.StugIII += amount;
						break;
					case "M109A3G":
						report.M109A3G += amount;
						break;
					case "Challenger":
						report.Challenger += amount;
						break;
					case "Chieftain":
						report.Chieftain += amount;
						break;
					case "Hetzer":
						report.Hetzer += amount;
						break;
					case "JS3-Stalin":
						report.JS3 += amount;
						break;
					case "M4-Sherman":
						report.M4 += amount;
						break;
					case "M26-Pershing":
						report.M26 += amount;
						break;
					case "M60A1":
						report.M60A1 += amount;
						break;
					case "M2A2":
						report.M2A2 += amount;
						break;
					default:
						break;
				}
			}
			report.MeanAmount = report.TotalAmount / report.OrderCnt;
			report.MeanCash = report.TotalCash / report.OrderCnt;

			return report;
		}

		public static void Test()
		{
			Console.WriteLine("订单报告库 test...");
		}
	}
}
