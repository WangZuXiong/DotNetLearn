using System;
namespace DotNetLearn
{
    public class OOPTest
    {
        public OOPTest()
        {
            //var water = new Water();
            //var lcdScreen = new LCDScreen();
            //var speaker = new Speaker();
            //var kettle = new Kettle(lcdScreen, speaker);
            //kettle.Boil(water);



            var lcdScreen = new LCDScreen();
            var speaker = new Speaker();

            var kettle = new Kettle();
            kettle.OnBoilHandle += (t) => { lcdScreen.Display(t.ToString()); };
            kettle.OnBoilHandle += (t) => { if (t > 96) speaker.Speak(t.ToString()); };
        }

        public class Water
        {
            public float Temperature;
        }

        public delegate void OnBoilEventHandle(float t);

        public class Kettle
        {
            //private LCDScreen _lcdScreen;
            //private Speaker _speaker;

            //public Kettle(LCDScreen lCDScreen, Speaker speaker)
            //{
            //    _lcdScreen = lCDScreen;
            //    _speaker = speaker;
            //}

            public event OnBoilEventHandle OnBoilHandle;

            public void Boil(Water water)
            {
                while (water.Temperature < 100)
                {
                    water.Temperature++;

                    OnBoilHandle?.Invoke(water.Temperature);
                }



                //_lcdScreen.Display(water.Temperature.ToString());

                //if (water.Temperature > 96)
                //{
                //    _speaker.Speak("水开了");
                //}
            }
        }

        public class LCDScreen
        {
            public void Display(string value)
            {
                Console.WriteLine("Display：" + value);
            }
        }

        public class Speaker
        {
            public void Speak(string value)
            {
                Console.WriteLine("Speak:" + value);
            }
        }

    }
}


namespace Delegate
{
    // 热水器
    public class Heater
    {
        private int temperature;
        public string type = "RealFire 001";       // 添加型号作为演示
        public string area = "China Xian";         // 添加产地作为演示
                                                   //声明委托
        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
        public event BoiledEventHandler Boiled; //声明事件

        // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)
            { // 如果有对象注册
                Boiled(this, e);  // 调用所有注册对象的方法
            }
        }

        // 烧水。
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //建立BoiledEventArgs 对象。
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);  // 调用 OnBolied方法
                }
            }
        }
    }

    // 警报器
    public class Alarm
    {
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
                                                //访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }

    // 显示器
    public class Display
    {
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {   //静态方法
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main1()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.Boiled += alarm.MakeAlert;   //注册方法
            heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
            heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以这么注册
            heater.Boiled += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法
        }
    }
}