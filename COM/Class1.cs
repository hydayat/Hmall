using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace COM_test
{
    [Guid("671BD477-7819-461F-8316-FA2006C7152E")]
    public interface MyCom_Interface
    {
        [DispId(1)]
        double Calculate(string place, double real_weight);
    }

    [Guid("3FA32F43-481F-480F-A6B3-D0AF40592C4F"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface MyCom_Events
    {
    }

    [Guid("8A311621-F62E-4459-9BD3-BA762892942E"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(MyCom_Events))]
    public class Class1 : MyCom_Interface
    {
        public double Calculate(string place, double real_weight)
        {
             Dictionary<string, Tuple<int, int>> priceTable;
            priceTable = new Dictionary<string, Tuple<int, int>>
            {
                { "山东", new Tuple<int, int>(10, 3) },
                { "江苏", new Tuple<int, int>(10, 3) },
                { "浙江", new Tuple<int, int>(10, 3) },
                { "上海", new Tuple<int, int>(10, 3) },
                { "安徽", new Tuple<int, int>(10, 5) },
                { "天津", new Tuple<int, int>(10, 5) },
                { "北京", new Tuple<int, int>(10, 5) },
                { "河北", new Tuple<int, int>(10, 5) },
                { "湖北", new Tuple<int, int>(15, 10) },
                { "江西", new Tuple<int, int>(15, 10) },
                { "重庆", new Tuple<int, int>(15, 10) },
                { "四川", new Tuple<int, int>(15, 10) },
                { "吉林", new Tuple<int, int>(15, 10) },
                { "河南", new Tuple<int, int>(15, 10) },
                { "广州", new Tuple<int, int>(15, 10) },
                { "黑龙江", new Tuple<int, int>(15, 10) },
                { "辽宁", new Tuple<int, int>(15, 10) },
                { "海南", new Tuple<int, int>(15, 10) },
                { "山西", new Tuple<int, int>(15, 10) },
                { "广西", new Tuple<int, int>(15, 10) },
                { "陕西", new Tuple<int, int>(15, 10) },
                { "湖南", new Tuple<int, int>(15, 10) },
                { "云南", new Tuple<int, int>(20, 15) },
                { "内蒙古", new Tuple<int, int>(20, 15) },
                { "青海", new Tuple<int, int>(20, 15) },
                { "贵州", new Tuple<int, int>(20, 15) },
                { "宁夏", new Tuple<int, int>(20, 15) },
                { "甘肃", new Tuple<int, int>(20, 15) },
                { "新疆", new Tuple<int, int>(30, 30) },
                { "西藏", new Tuple<int, int>(30, 30) },
            };
            //  进位
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
