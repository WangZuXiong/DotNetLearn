using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    class Array1
    {
        static void Main1()
        {
            //二维数组
            int[,] vs = new int[3, 3];
            vs[0, 1] = 1;
            vs[1, 1] = 1;

            foreach (var item in vs)
            {
                Console.Write(item);
                Console.Write("  ");
            }
            Console.WriteLine();


            Console.WriteLine("Length:" + vs.Length.ToString());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(vs[i, j]);
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
}

/*
    数组类型	    总时间（100 次迭代）

    一维数组	    660 ms
    交错数组	    730 ms
    多维数组	    3470 ms
 */