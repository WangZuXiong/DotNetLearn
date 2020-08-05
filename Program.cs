using System;
using System.Threading;

namespace DotNetLearn
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}


        public static void Main()
        {
            Class1 class1 = new Class1();
            Thread newThread = new Thread(new ThreadStart(class1.TestMethod));
            newThread.Start();
            Thread.Sleep(1000);

            // Abort newThread.
            Console.WriteLine("Main aborting new thread.");
            newThread.Abort();

            // Wait for the thread to terminate.
            newThread.Join();
            Console.WriteLine("New thread terminated - Main exiting.");
        }
    }


    public class Class1
    {

        public void TestMethod()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("New thread running.");
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException abortException)
            {
                Console.WriteLine((string)abortException.ExceptionState);
            }
        }

    }
}
