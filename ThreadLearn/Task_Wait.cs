using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Task_Wait
    {
        static void Main1()
        {
            Task task  = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("run in task");
            });

            Console.WriteLine(task.IsCompleted);

            task.Wait();//阻塞到task完成操作  类似Thread.Join()
            Console.WriteLine(task.IsCompleted);

        }
    }
}
