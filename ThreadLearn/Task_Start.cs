using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Task_Start
    {
        static void Main1()
        {
            Task.Run(() => { Console.WriteLine("111"); });
            //task 其实使用的也是线程池，默认创建出来的线程都是后台线程，
            //前台线程 结束之后 后台线程也会结束
            //所以当主线程（前台）结束之后，子线程也会结束


            //Console.ReadLine();
            Thread.Sleep(100);


            //适用于长时间运行的任务
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("2222");  
            }, TaskCreationOptions.LongRunning);

            Thread.Sleep(100);
        }
    }
}
