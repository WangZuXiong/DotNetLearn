using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    class TimeStudy
    {
        public static void Foo1()
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dateTime = new DateTime(2020, 8, 19, 19, 20, 0);

            Console.WriteLine(dateTime.Ticks);

            long t = (dateTime.Ticks - dateTimeStart.Ticks) / 10000;

            Console.WriteLine(t);
            Console.WriteLine(DateTime.Now.Ticks);

            Console.WriteLine("dateTimeStart:" + dateTimeStart.Ticks);
            TimeSpan toNow = new TimeSpan(1597836196895 * 10000);
            DateTime dateTime1 = dateTimeStart.Add(toNow);
             
            Console.WriteLine(dateTime1.Ticks);
            Console.WriteLine(dateTime1.Year);
            Console.WriteLine(dateTime1.Month);
            Console.WriteLine(dateTime1.Day);
        }


        public static void Foo()
        {
            //TICK最小的时间单位刻度，相当于100奈秒（1奈秒等于十亿分之一秒）。刻度可正可负。

            //DateTime.Now.Ticks    不是现在的0时区当前时间戳
            var currentTimeStamp = (DateTime.Now.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks) / 10000; //0时区当前时间戳
            Console.WriteLine(currentTimeStamp);//1608819496143


            var temp = new TimeSpan(1, 0, 0) / 10000;//1个小时的毫秒数   

            TimeSpan timeSpan = new TimeSpan(currentTimeStamp * 10000);

            Console.WriteLine(timeSpan.Days);
        }
    }
}
