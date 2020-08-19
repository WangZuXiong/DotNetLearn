using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Task_TaskCompletionSource
    {
        static void Main1()
        {
            TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();


            new Thread(() =>
            {
                Thread.Sleep(1000);
                taskCompletionSource.SetResult(1);
            })
            {
                IsBackground = true
            }.Start();

            Task<int> task = taskCompletionSource.Task;
            Console.WriteLine(task.Result);

            Console.ReadLine();
        }
    }
}
