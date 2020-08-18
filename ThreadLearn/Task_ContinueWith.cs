using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Task_ContinueWith
    {
        static void Main1()
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 1;
            });

            task.ContinueWith(task =>
            {
                Console.WriteLine(task.Result);
            });


            Console.ReadLine();
        }
    }
}
