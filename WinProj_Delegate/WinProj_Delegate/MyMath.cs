using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProj_Delegate
{
    class MyMath
    {
        public static double calculate(double x) 
        {
            System.Threading.Thread.Sleep(3000);
            return (x * x);
        }
    }
}
