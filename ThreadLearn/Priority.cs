using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace DotNetLearn.ThreadLearn
{
    class Priority
    {
        void Func()
        {
            Thread thread = new Thread(()=> { });
            //提高线程的优先级
            thread.Priority = ThreadPriority.Highest;

            using (Process process = Process.GetCurrentProcess())
            {
                //提高进程的优先级
                process.PriorityClass = ProcessPriorityClass.High;
            }  
        }
    }
}
