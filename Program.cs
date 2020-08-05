using System;
using System.Threading;

/*
       Interlocked.Increment 方法：让++成为原子操作；Interlocked.Decrement 方法让--成为原子操作。
       什么叫原子操作呢。就是不会被别人打断，因为C#中的一个语句，编译成机器代码后会变成多个语句。
       在多线程环境中，线程切换有可能会发生在这多个语句中间。使用Interlocked.Increment,Interlocked.Decrement 可以避免被打断,保证线程安全。    
    */
class Program
{
    static void Main1(string[] args)
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
            sum++;
        }
    }
    static void Thread2()
    {
        for (int i = 0; i < 100000; i++)
        {
            sum++;
        } 
    }
}

 
class Test
{
    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(ThreadMethod));
        Thread thread2 = new Thread(new ThreadStart(ThreadMethod));
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();

        // Have the garbage collector run the finalizer for each
        // instance of CountClass and wait for it to finish.
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("UnsafeInstanceCount: {0}" +
            "\nSafeCountInstances: {1}",
            CountClass.UnsafeInstanceCount.ToString(),
            CountClass.SafeInstanceCount.ToString());
    }

    static void ThreadMethod()
    {
        CountClass cClass;

        // Create 100,000 instances of CountClass.
        for (int i = 0; i < 100000; i++)
        {
            cClass = new CountClass();
        }
    }
}

class CountClass
{
    static int unsafeInstanceCount = 0;//不使用原子操作
    static int safeInstanceCount = 0;//使用原子操作

    static public int UnsafeInstanceCount
    {
        get { return unsafeInstanceCount; }
    }

    static public int SafeInstanceCount
    {
        get { return safeInstanceCount; }
    }

    public CountClass()
    {
        unsafeInstanceCount++;
        Interlocked.Increment(ref safeInstanceCount);
    }

    ~CountClass()
    {
        unsafeInstanceCount--;
        Interlocked.Decrement(ref safeInstanceCount);
    }
}