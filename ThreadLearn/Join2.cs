using System;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Join2
    {
        static Thread thread2;

        static void Main1()
        {
            ThreadStart threadStart1 = new ThreadStart(Method1);
            Thread thread1 = new Thread(threadStart1);
            thread1.Start();


            ThreadStart threadStart2 = new ThreadStart(Method2);
            thread2 = new Thread(threadStart2);
            thread2.Start();



        }

        private static void Method1()
        {
            thread2.Join();//调用了Join方法之后，线程1 会等 线程2 执行结束之后才执行
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("1");
            }
        }

        private static void Method2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("2");
            }
        }
    }
}
