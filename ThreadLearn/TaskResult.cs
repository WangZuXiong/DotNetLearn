using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class TaskResult
    {
        static void Main1()
        {
            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine("Foo");
                Thread.Sleep(1000);
                return 1;
            });

            int result = task.Result;//如果task还没有完成 那么就会一直阻塞，直到task完成为止

            Console.WriteLine(result);




            //计算质数的个数
            Task<int> task1 = Task.Run(() =>
            {
                return Enumerable.Range(2, 3000000).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
            });

            int primeNumber = task1.Result;
            Console.WriteLine(primeNumber);

        }
    }
}
