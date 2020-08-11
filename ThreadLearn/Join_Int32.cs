using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Join_Int32
    {
        static void Main1()
        {
            ThreadStart threadStart = new ThreadStart(WriteY);
            Thread thread = new Thread(threadStart);
            thread.Start();

            //先执行完thread 子线程 在执行mian thread
            //如果线程已终止，则为 true；如果 false 参数指定的时间量已过之后还未终止线程，则为 timeout。
            bool isTermination = thread.Join(1);
            if (isTermination)
            {
                Console.WriteLine("thread 线程已经终止");
            }
            else
            {
                Console.WriteLine("线程已经超出时间量");
            }

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
        }

        private static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}
