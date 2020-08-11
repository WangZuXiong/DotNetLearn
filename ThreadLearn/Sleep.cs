using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNetLearn.ThreadLearn
{
    class Sleep
    {
        static void Main()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("sleep 1000");
            }
        }

    }
}
