using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Synchronization_Context
    {
        private static SynchronizationContext _synchronizationContext;

        static void Main1()
        {
            _synchronizationContext = new SynchronizationContext();

            new Thread(Work).Start();
        }

        static void Work()
        {
            Console.WriteLine(">>>" + Thread.CurrentThread.Name);

            Thread.Sleep(3000);

            //在子线程中调用主线程的方法
            //比如说可以在子线程中调用WPF 的 text
            //在子线程中调用UnityEngine
            _synchronizationContext.Post(t =>
            {
                Console.WriteLine(">>>" + Thread.CurrentThread.Name);
            }, null);
        }
    }
}
