using System;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Join1
    {
        static void Main1()
        {
            ThreadStart threadStart = new ThreadStart(WriteY);
            Thread thread = new Thread(threadStart);
            thread.Start();


            thread.Join();//调用了Join方法之后，主线程会等thread线程执行结束之后才执行


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




