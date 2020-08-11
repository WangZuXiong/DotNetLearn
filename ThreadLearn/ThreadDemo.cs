using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class ThreadDemo
    {
        static void Main1()
        {
            Thread.CurrentThread.Name = "Main Thread....";
            ThreadStart threadStart = new ThreadStart(WriteY);
            Thread thread = new Thread(threadStart);
            thread.Name = "Write Y Thread....";
            thread.Start();

            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
        }

        private static void WriteY()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }

    //xy交替出现
}
