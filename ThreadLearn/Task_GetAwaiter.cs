using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Task_GetAwaiter
    {
        static void Main1()
        {
            Task<int> task = Task.Run(() =>
            {
                //do some thing

                return 1;
            });
            TaskAwaiter<int> taskAwaiter = task.GetAwaiter();

            taskAwaiter.OnCompleted(() =>
            {
                int result = taskAwaiter.GetResult();
                Console.WriteLine(result);
            });

            Console.ReadLine();
        }
    }
}
