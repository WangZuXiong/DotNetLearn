using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class ThreadSafe
    {
        static bool _done;

        static object _locker = new object();

        static void Main1()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            //当两个线程同时竞争一个锁的时候（锁🔒可以基于任何引用类型对应），一个线程会等待或者阻塞直到锁变成可用为止
            lock (_locker)
            {
                //同一时刻 最多只有一个线程在这块代码块里面执行

                if (!_done)
                {
                    Console.WriteLine("Done");
                    Thread.Sleep(1000);
                    _done = true;
                }
            }
        }
    }
}
