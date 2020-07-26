using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace CSharpInvokeCSharp.CSharpDemo
{
    public class CPPDLL
    {
        [DllImport("CSharpInvokeCPP.CPPDemo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void edge(string path);

        [DllImport("CSharpInvokeCPP.CPPDemo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void erode(string path);

        [DllImport("CSharpInvokeCPP.CPPDemo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void blur(string path);
    }
}
