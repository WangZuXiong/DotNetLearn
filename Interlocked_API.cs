using System;
using System.Threading;

/*
    Interlocked.Increment 方法：让++成为原子操作； //以原子操作的形式递增指定变量的值并存储结果。
    Interlocked.Decrement 方法：让--成为原子操作。 //以原子操作的形式递减指定变量的值并存储结果。

    什么叫原子操作呢。就是不会被别人打断，因为C#中的一个语句，编译成机器代码后会变成多个语句。
    在多线程环境中，线程切换有可能会发生在这多个语句中间。使用Interlocked.Increment,Interlocked.Decrement 可以避免被打断,保证线程安全。    
*/
class Interlocked_API
{
    static void Main1()
    {
        for (int loop = 0; loop < 20; loop++)
        {
            sum = 0;
            Thread t1 = new Thread(Thread1);
            Thread t2 = new Thread(Thread2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine("sum = " + sum);         // sum = 200000 ?
        }
    }

    static int sum;
    static void Thread1()
    {
        for (int i = 0; i < 100000; i++)
        {
            //sum++;
            Interlocked.Increment(ref sum);
        }
    }
    static void Thread2()
    {
        for (int i = 0; i < 100000; i++)
        {
            //sum++;
            Interlocked.Increment(ref sum);
        }
    }
}