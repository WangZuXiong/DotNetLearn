using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DotNetLearn.Array
{
    class Array2
    {
        static void Main()
        {
            //交错数组


            //声明
            int[][] vs1 = new int[3][];
            //赋值
            vs1[0] = new int[] { 1, 1, 1 };
            vs1[1] = new int[] { 1, 1 };
            vs1[2] = new int[] { 1 };
            vs1[2][0] = 100;

            int[][] vs2 = new int[3][] 
            {
                new int[3] { 1, 2, 3 }, 
                new int[2] { 1, 2 }, 
                new int[1] { 1 } 
            };


            for (int i = 0; i < vs1.Length; i++)
            {
                for (int j = 0; j < vs1[i].Length; j++)
                {
                    Console.Write(vs1[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();




            foreach (int[]  temp in vs2)
            {
                foreach (int item in temp)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }



            int[][][] vs3 = new int[1][][]
            {
               new int[][]{ }
            };


            Console.WriteLine(vs3.Length);
        }
    }
}

/*
    数组类型	    总时间（100 次迭代）

    一维数组	    660 ms
    交错数组	    730 ms
    多维数组	    3470 ms
 */