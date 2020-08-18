using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    class HashTest
    {
        static void Main1()
        {
            var str1 = "wzx";
            var str2 = "www";
            var str3 = "www";


            Console.WriteLine("str1 hash code:" + str1.GetHashCode());//-1666658207
            Console.WriteLine("str2 hash code:" + str2.GetHashCode());//1653609987
            Console.WriteLine("str3 hash code:" + str3.GetHashCode());//1653609987








            StudentClass student1 = new StudentClass();
            student1.Name = "1";

            StudentClass student2 = new StudentClass();
            student2.Name = "1";

            Console.WriteLine("student1== student2   " + (student1 == student2));//False
            Console.WriteLine("student1.Equals(student2)   " + (student1.Equals(student2)));//True
            Console.WriteLine("student1.GetHashCode()==student2.GetHashCode()  " + (student1.GetHashCode() == student2.GetHashCode()));//True








            List<StudentClass> studentClasses1 = new List<StudentClass>();
            studentClasses1.Add(student1);
            List<StudentClass> studentClasses2 = new List<StudentClass>();
            studentClasses2.Add(student1);

            Console.WriteLine(studentClasses1.Equals(studentClasses2));//False

            Console.WriteLine(studentClasses1.Equals(studentClasses1));//True


        }
    }
}
