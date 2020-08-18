using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearn.ThreadLearn
{
    class Awaiter1
    {
        static void Main1()
        {
            A a = new A();
            Task<string> t = a.Func();

            Console.WriteLine(t.Result);
            Console.WriteLine(123123);

            Console.ReadKey();
        }

    }

    public class A
    {
        public async Task<string> Func()
        {
            MyClass myClass = new MyClass();
            string result = await myClass.GetAsync();
            return result;
        }
    }


    class MyClass
    {
   

        public Task<string> GetAsync()
        {
            Task<string> task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "132";
            });
            return task;
        }
    }
}
