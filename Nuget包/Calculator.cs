using System;
using System.Collections.Generic;

namespace ZhongTongFreightCalculator
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

		private readonly Dictionary<string, Tuple<int, int>> priceTable;

		private Calculator()
		{
			priceTable = new Dictionary<string, Tuple<int, int>>
			{
				{ "广东", new Tuple<int, int>(8, 2) },
				{ "上海", new Tuple<int, int>(8, 6) },
				{ "浙江", new Tuple<int, int>(8, 6) },
				{ "江苏", new Tuple<int, int>(8, 6) },
				{ "安徽", new Tuple<int, int>(10, 6) },
				{ "北京", new Tuple<int, int>(10, 8) },
				{ "天津", new Tuple<int, int>(10, 8) },
				{ "重庆", new Tuple<int, int>(10, 7) },
				{ "山东", new Tuple<int, int>(10, 7) },
				{ "福建", new Tuple<int, int>(10, 7) },
				{ "湖北", new Tuple<int, int>(10, 6) },
				{ "湖南", new Tuple<int, int>(10, 6) },
				{ "河北", new Tuple<int, int>(12, 8) },
				{ "河南", new Tuple<int, int>(12, 8) },
				{ "江西", new Tuple<int, int>(10, 6) },
				{ "四川", new Tuple<int, int>(10, 8) },
				{ "山西", new Tuple<int, int>(12, 8) },
				{ "辽宁", new Tuple<int, int>(13, 10) },
				{ "吉林", new Tuple<int, int>(13, 10) },
				{ "陕西", new Tuple<int, int>(12, 8) },
				{ "黑龙江", new Tuple<int, int>(13, 10) },
				{ "广西", new Tuple<int, int>(10, 6) },
				{ "云南", new Tuple<int, int>(12, 8) },
				{ "海南", new Tuple<int, int>(12, 8) },
				{ "贵州", new Tuple<int, int>(10, 6) },
				{ "内蒙古", new Tuple<int, int>(15, 12) },
				{ "宁夏", new Tuple<int, int>(18, 15) },
				{ "新疆", new Tuple<int, int>(18, 15) },
				{ "甘肃", new Tuple<int, int>(18, 15) },
				{ "青海", new Tuple<int, int>(18, 15) },
				{ "香港", new Tuple<int, int>(25, 10) },
				{ "澳门", new Tuple<int, int>(35, 25) },
				{ "台湾", new Tuple<int, int>(35, 30) },
				{ "珠三角", new Tuple<int, int>(7, 1) }
			};
		}

		//计算价格
		public double Calculate(string place, double real_weight)
		{
			// 进位
			double weight = 0;//进位后的重量
			if (real_weight >= 100)
			{
				weight = Math.Round(real_weight);
			}
			else
			{
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
			int next_weight = priceTable[place].Item2;//续重
			return first_weight + (weight - 1) * next_weight;
		}
	}
}
