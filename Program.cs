using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetLearn
{
    class Program
    {
        static void Main()
        {
            string str1 = "1234";
            string str2 = "1234";


            ExcTime("ComparisonWithOrdinal", () =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    StringComparisonTest.ComparisonWithOrdinal(str1, str2);
                }
            });

            ExcTime("Comparisonl", () =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    StringComparisonTest.Comparison(str1, str2);
                }
            });

            ExcTime("Equals", () =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    StringComparisonTest.Equals(str1, str2);
                }
            });



            Console.WriteLine();

            ExcTime("CustomStartsWith", () =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    str1.CustomStartsWith(str2);
                }
            });

            ExcTime("StartsWith", () =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    str1.StartsWith(str2);
                }
            });
        }



        static void ExcTime(string testTag, Action action)
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
