#include "pch.h"

#include "CppCLR.h"
#include<stdio.h>
#pragma once

using namespace System;
using namespace System::Collections::Generic;
using namespace std;
namespace CppCLR {
	public ref class Calculator
	{
		// 单例模式的唯一实例
	private:
		static Calculator ^calculator = nullptr;

	public:
		static Calculator ^GetCalculator()
		{
			if (calculator != nullptr)
			{
				return calculator;
			}

			calculator = gcnew Calculator();
			return calculator;
		}
	private:
		Dictionary<String^, Tuple<int, int>^> ^priceTable;

	private:
		Calculator()
		{
			priceTable = gcnew Dictionary<String^, Tuple<int, int>^>;
			priceTable->Add("东莞", gcnew Tuple<int, int>(11, 1));
			priceTable->Add("广州", gcnew Tuple<int, int>(13, 2));
			priceTable->Add("深圳", gcnew Tuple<int, int>(13, 2));
			priceTable->Add("福建", gcnew Tuple<int, int>(20, 8));
			priceTable->Add("广西", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("江西", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("湖南", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("海南", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("贵州", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("安徽", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("湖北", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("重庆", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("四川", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("云南", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("河南", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("上海", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("江苏", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("浙江", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("北京", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("天津", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("辽宁", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("陕西", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("河北", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("山西", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("山东", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("甘肃", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("宁夏", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("青海", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("内蒙古", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("吉林", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("黑龙江", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("新疆", gcnew Tuple<int, int>(28, 25));
			priceTable->Add("西藏", gcnew Tuple<int, int>(28, 25));
			array<String^> ^places = { "江门", "惠州", "佛山", "中山", "珠海", "肇庆", "清远", "云浮", "阳江", "揭阳", "茂名", "韶关", "梅州", "汕头", "湛江", "河源", "潮州", "汕尾" };
			for each(String^ place in places)
			{
				priceTable->Add(place, gcnew Tuple<int, int>(12, 2));
			}
		}

		//计算价格
	public:
		double Calculate(String ^place, double real_weight)
		{
			// 进位
			double weight = 0;//进位后的重量
			if (real_weight >= 100) {
				weight = Math::Round(real_weight);
			}
			else {
				weight = Math::Floor(real_weight);//整数部分
				double tmp = real_weight - weight;//小数部分
				if (tmp < 0.5 && tmp>0)
				{
					weight += 0.5;
				}
				else if (tmp>0.5)
				{
					weight += 1;
				}
				if (weight < 1)
				{
					weight = 1;
				}
			}
			int first_weight = priceTable[place]->Item1;//首重
			int next_weight = priceTable[place]->Item2;//续重
			return first_weight + (weight - 1)*next_weight;
		}

	};
}
