using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    class TimeUtil
    {
        static void Main()
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
    }
}
