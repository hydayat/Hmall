using System;
using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyKeyFile("shrd.snk")]
namespace Sharing
{
	public class Calculator
	{
		// 单例模式的唯一实例
		private static Calculator calculator = null;

		public static Calculator GetCalculator()
		{
			if (calculator != null)
			{
				return calculator;
			}

			calculator = new Calculator();
			return calculator;
		}

		private readonly Dictionary<string, Tuple<int,int>> priceTable;

		private Calculator()
		{
			priceTable = new Dictionary<string, Tuple<int, int>>
			{
				{ "东莞", new Tuple<int, int>(11, 1) },
				{ "广州", new Tuple<int, int>(13, 2) },
				{ "深圳", new Tuple<int, int>(13, 2) },
				{ "福建", new Tuple<int, int>(20, 8) },
				{ "广西", new Tuple<int, int>(22, 8) },
				{ "江西", new Tuple<int, int>(22, 8) },
				{ "湖南", new Tuple<int, int>(22, 8) },
				{ "海南", new Tuple<int, int>(22, 8) },
				{ "贵州", new Tuple<int, int>(23, 12) },
				{ "安徽", new Tuple<int, int>(23, 12) },
				{ "湖北", new Tuple<int, int>(23, 12) },
				{ "重庆", new Tuple<int, int>(23, 13) },
				{ "四川", new Tuple<int, int>(23, 13) },
				{ "云南", new Tuple<int, int>(23, 13) },
				{ "河南", new Tuple<int, int>(23, 13) },
				{ "上海", new Tuple<int, int>(23, 13) },
				{ "江苏", new Tuple<int, int>(23, 13) },
				{ "浙江", new Tuple<int, int>(23, 13) },
				{ "北京", new Tuple<int, int>(23, 14) },
				{ "天津", new Tuple<int, int>(23, 14) },
				{ "辽宁", new Tuple<int, int>(23, 14) },
				{ "陕西", new Tuple<int, int>(23, 14) },
				{ "河北", new Tuple<int, int>(23, 14) },
				{ "山西", new Tuple<int, int>(23, 14) },
				{ "山东", new Tuple<int, int>(23, 14) },
				{ "甘肃", new Tuple<int, int>(23, 18) },
				{ "宁夏", new Tuple<int, int>(23, 18) },
				{ "青海", new Tuple<int, int>(23, 18) },
				{ "内蒙古", new Tuple<int, int>(25, 20) },
				{ "吉林", new Tuple<int, int>(25, 20) },
				{ "黑龙江", new Tuple<int, int>(25, 20) },
				{ "新疆", new Tuple<int, int>(28, 25) },
				{ "西藏", new Tuple<int, int>(28, 25) }
			};
			string[] places = { "江门", "惠州", "佛山", "中山", "珠海", "肇庆", "清远", "云浮", "阳江", "揭阳", "茂名", "韶关", "梅州", "汕头", "湛江", "河源", "潮州", "汕尾" };
			foreach (string place in places)
			{
				priceTable.Add(place, new Tuple<int, int>(12, 2));
			}
		}

		//计算价格
		public double Calculate(string place, double real_weight)
		{
			// 进位
			double weight = 0;//进位后的重量
			if (real_weight >= 100) {
				weight = Math.Round(real_weight);
			}
			else {
				weight = Math.Floor(real_weight);//整数部分
				double tmp = real_weight - weight;//小数部分
				if (tmp <= 0.5 && tmp > 0)
				{
					weight += 0.5;
				}
				else if (tmp > 0.5)
				{
					weight += 1;
				}
				if (weight < 1)
				{
					weight = 1;
				}
			}
			

			int first_weight = priceTable[place].Item1;//首重
			int next_weight  = priceTable[place].Item2;//续重

			//Console.WriteLine(first_weight);
			//Console.WriteLine(weight);
			//Console.WriteLine(next_weight);

			return first_weight + (weight - 1) * next_weight;
		}

		public static void Test()
		{
			Console.WriteLine("test...");
		}
	}
}
