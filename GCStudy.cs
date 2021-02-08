using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    class GCStudy
    {


    }


    class MyGCCollectClass
    {       
        private const long maxGarbage = 1000;

       public static void Main1()
        {
            MyGCCollectClass myGCCol = new MyGCCollectClass();

            // Determine the maximum number of generations the system确定系统的最大代数
            // garbage collector currently supports.//垃圾回收器当前支持。
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);//The highest generation is 2

            myGCCol.MakeSomeGarbage();

            // Determine which generation myGCCol object is stored in.确定myGCCol对象存储在哪一代中。
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));//Generation: 0

            // Determine the best available approximation of the number
            // of bytes currently allocated in managed memory.
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));//Total Memory: 103528

            // Perform a collection of generation 0 only.
            GC.Collect(0);

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));//Generation: 1

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));//Total Memory: 76896

            // Perform a collection of all generations up to and including 2.
            GC.Collect(2);

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));//Generation: 2
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));//Total Memory: 76776
            Console.Read();
        }

        void MakeSomeGarbage()
        {
            Version vt;

            for (int i = 0; i < maxGarbage; i++)
            {
                // Create objects and release them to fill up memory
                // with unused objects.
                vt = new Version();
            }
        }
    }

}
