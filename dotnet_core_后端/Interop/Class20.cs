using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace dotNet期末项目.Interop
{
	public class Class20
	{
        [DllImport("littlewin32dll.dll")]
        public static extern int Add(int x, int y);

        [DllImport("littlewin32dll.dll")]
        public static extern int Sub(int x, int y);

        [DllImport("littlewin32dll.dll")]
        public static extern int Multiply(int x, int y);

        [DllImport("littlewin32dll.dll")]
        public static extern int Divide(int x, int y);
    }
}
