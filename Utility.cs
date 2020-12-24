using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetLearn
{
    public class Utility
    {
        /// <summary>
        /// 计算执行事件
        /// </summary>
        /// <param name="testTag"></param>
        /// <param name="action"></param>
        public static void ExcTime(string testTag, Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action?.Invoke();
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            double milliseconds = timespan.TotalMilliseconds;
            Console.WriteLine(string.Format("{0,30}   {1,-10}", testTag, milliseconds.ToString()));
        }
    }
}
