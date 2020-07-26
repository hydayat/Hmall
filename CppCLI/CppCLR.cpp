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
		// ����ģʽ��Ψһʵ��
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
			priceTable->Add("��ݸ", gcnew Tuple<int, int>(11, 1));
			priceTable->Add("����", gcnew Tuple<int, int>(13, 2));
			priceTable->Add("����", gcnew Tuple<int, int>(13, 2));
			priceTable->Add("����", gcnew Tuple<int, int>(20, 8));
			priceTable->Add("����", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("����", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("����", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("����", gcnew Tuple<int, int>(22, 8));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 12));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("�Ĵ�", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("�Ϻ�", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("�㽭", gcnew Tuple<int, int>(23, 13));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("���", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("�ӱ�", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("ɽ��", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("ɽ��", gcnew Tuple<int, int>(23, 14));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("����", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("�ຣ", gcnew Tuple<int, int>(23, 18));
			priceTable->Add("���ɹ�", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("����", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("������", gcnew Tuple<int, int>(25, 20));
			priceTable->Add("�½�", gcnew Tuple<int, int>(28, 25));
			priceTable->Add("����", gcnew Tuple<int, int>(28, 25));
			array<String^> ^places = { "����", "����", "��ɽ", "��ɽ", "�麣", "����", "��Զ", "�Ƹ�", "����", "����", "ï��", "�ع�", "÷��", "��ͷ", "տ��", "��Դ", "����", "��β" };
			for each(String^ place in places)
			{
				priceTable->Add(place, gcnew Tuple<int, int>(12, 2));
			}
		}

		//����۸�
	public:
		double Calculate(String ^place, double real_weight)
		{
			// ��λ
			double weight = 0;//��λ�������
			if (real_weight >= 100) {
				weight = Math::Round(real_weight);
			}
			else {
				weight = Math::Floor(real_weight);//��������
				double tmp = real_weight - weight;//С������
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
			int first_weight = priceTable[place]->Item1;//����
			int next_weight = priceTable[place]->Item2;//����
			return first_weight + (weight - 1)*next_weight;
		}

	};
}
