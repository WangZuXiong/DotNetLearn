using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Signal
    {
        static void Main1()
        {
            var signal = new ManualResetEvent(false);

            Thread thread = new Thread(() =>
            {
                Console.WriteLine("1");

                signal.WaitOne();
                signal.Dispose();

                Console.WriteLine("2");
            });
            thread.Start();


            Thread.Sleep(3000);
            signal.Set();//发出信号


            //signal.Reset();//可以调用这个方法重置

        }
    }
}
