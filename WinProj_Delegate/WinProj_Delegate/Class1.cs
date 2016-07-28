using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProj_Delegate
{
    class Class1
    {
    }
    public abstract class Animal { }

    public class Antelope : Animal 
    {
        public void CheckHooves() 
        {
            Console.WriteLine("Schedule Hoof Checkup");
        }
    
    }

    public class Lion : Animal
    {
        public void CheckClawss()
        {
            Console.WriteLine("Schedule Claw Checkup");
        }

    }

    public class MedicalCenter 
    {
        public delegate void AppointmentType();//其他方法都跟delegate一樣不回傳值且不回傳引數
        public AppointmentType animalCheckup; //animalCheckup變數是AppointmentType資料型態

        public void ScheduleAppointment(AppointmentType a) 
        {
            animalCheckup = a;
        }

        public void ProcessNextPatient() 
        {
            if (animalCheckup != null) 
            {
                animalCheckup();
            }
        }
    }
    //myTest1
    public class testCenter 
    {
        public delegate void TestType();
        public TestType myTestType;

        public void callMyTest(TestType b) 
        {
            myTestType = b;
        }
        public void RunProcess() 
        {
            if (myTestType != null) 
            {
                myTestType();
            }
        }

    }
    //註冊多個方法並執行multicast
    //這個在研華比較常用
    public class SimpleMath 
    {
        public delegate int calculate(int x, int y);

        public int Add(int x, int y) 
        {
            int sum = 0;
            sum = x + y;
            Console.WriteLine("{0}+{1}={2}", x, y, sum);
            return sum;
        }
        public int Substract(int x, int y) 
        {
            int sum = 0;
            sum = x - y;
            Console.WriteLine("{0}-{1}={2}", x, y, sum);
            return sum;
        }

        public int Multiply(int x, int y)
        {
            int sum = 0;
            sum = x * y;
            Console.WriteLine("{0}*{1}={2}", x, y, sum);
            return sum;
        }

        public int Divide(int x, int y)
        {
            int sum = 0;
            sum = x / y;
            Console.WriteLine("{0}/{1}={2}", x, y, sum);
            return sum;
        }
    }
}
