using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging; //多這行

namespace WinProj_Delegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicalCenter animalHospital = new MedicalCenter();
            Lion notVeryBraveLion = new Lion();
            Antelope bigMaleAntelope = new Antelope();

            animalHospital.ScheduleAppointment(new MedicalCenter.AppointmentType(bigMaleAntelope.CheckHooves));
            animalHospital.ProcessNextPatient();

            animalHospital.ScheduleAppointment(new MedicalCenter.AppointmentType(notVeryBraveLion.CheckClawss));
            animalHospital.ProcessNextPatient();

            //void myTest delegate
            //testCenter T1 = new testCenter();
            //Lion L1 = new Lion();
            //T1.callMyTest(new testCenter.TestType(L1.CheckClawss));
            //T1.RunProcess();

        }

        //有回傳值的delegate
        //delegate2跳進去判斷是否有得到委派的方法 確定有不是null,就Dotrick執行SplashCustomer or JumpThroughHoop
        private void button2_Click(object sender, EventArgs e)
        {
            //Dolphin zooDolphin = new Dolphin();
            //zooDolphin.Trick = new Dolphin.TrickType(JumpThroughHoop);
            //zooDolphin.DoTricks();

            //Mydelegate 2
            Apple A1 = new Apple();
            A1.Trick = new Apple.AppleType(SplashCustomer);
            A1.DoTrick();
        }

        private void SplashCustomer() 
        {
            Console.WriteLine("Splash");
        }

        private void JumpThroughHoop() 
        {
            Console.WriteLine("Jumped through hoop");
        }
        //註冊多個方法並執行
        private void button3_Click(object sender, EventArgs e)
        {
            SimpleMath sm = new SimpleMath();
            SimpleMath.calculate calculate = new SimpleMath.calculate(sm.Add);
            calculate += new SimpleMath.calculate(sm.Substract);
            int x = calculate(10, 5);
            Console.WriteLine(x);

            calculate -= new SimpleMath.calculate(sm.Substract);
            x = calculate(7, 5);
            Console.WriteLine(x);
        }
        //多執行序 非同步程式
        private void button4_Click(object sender, EventArgs e)
        {
            AsyncCallback callback = MyCallBackMethod;
            MathOperation op = new MathOperation(MyMath.calculate);
            op.BeginInvoke(0.25, callback, "HelloTest");
            MessageBox.Show("Hello End...");
            //mat
        }

        void MyCallBackMethod(IAsyncResult ar) 
        {
            object hello = ar.AsyncState;
            AsyncResult AsyncResult = (AsyncResult)ar;
            MathOperation op = (MathOperation)AsyncResult.AsyncDelegate;
            double result = op.EndInvoke(ar);
            Console.WriteLine("回呼傳回值: {0}, 資料引數: {1}", result, hello);
        }
        delegate double MathOperation(double input);
    }
}
