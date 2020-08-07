using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public  class Lab 
{
    private int FindSecondMaxNum(int[] vs)
    {
        var max = int.MinValue;
        var secondMax = int.MinValue;

        for (int i = 0; i < vs.Length; i++)
        {
            if (vs[i] > max)
            {
                secondMax = max;
                max = vs[i];
            }
            else
            {
                if (vs[i] > secondMax)
                {
                    secondMax = vs[i];
                }
            }
        }
        return secondMax;
    }

    private void TestMyListRemove()
    {
        List<int> tempList = new List<int>();

        for (int i = 0; i < 1000; i++)
        {
            tempList.Add(i);
        }
        //using (new ProfilerMarker("ListRemoveAdvance").Auto())
        //{
        //    Utility.ListRemoveAdvance(tempList, 1);//288b 2.25ms
        //}

        //using (new ProfilerMarker("ListRemove").Auto())
        //{
        //    tempList.Remove(1);//0 b 0.7ms
        //}


        for (int i = 0; i < tempList.Count; i++)
        {
            Console.WriteLine(tempList[i]);
        }
    }

    void ValueRefTest()
    {

        string str1 = "1";//str1 ---> new string("1")
        string str2 = str1;//str2 --> str1传递引用 
        str2 = "2";//str2 --> new string("2") 传引用，str2指向一个新的字符串，str1没有改变
        Console.WriteLine(str1);//1
        //但是string又有值传递的效果，这bai是因为string是常量，不能更改

        StudentClass studentClass1 = new StudentClass();
        studentClass1.Age = 1;
        StudentClass studentClass2 = studentClass1;
        studentClass2.Age = 2;
        Console.WriteLine(studentClass1.Age);//2


        StudentStruct studentStruct1 = new StudentStruct();
        studentStruct1.Age = 1;

        StudentStruct studentStruct2 = studentStruct1;
        studentStruct2.Age = 2;
        Console.WriteLine(studentStruct1.Age);//3
    }

    private void StructTest()
    {
        //类使用前必须new关键字实例化，Struct不需要
        StudentStruct vector2;
        vector2.Age = 1;
        vector2.Height = 1;
        vector2.Name = "123456";

        Console.WriteLine(vector2.ToString());//(1.0, 1.0)
    }

    void ListCountTest()
    {
        List<int> vs = new List<int>(10);
        vs.Add(1);
        vs.Clear();
        Console.WriteLine(vs.Count);//0
    }

    void ipp_ppi_Test()
    {
        //i++ 先传值，再自增
        //++i 先自增，再传值
        //在这里的例子中：都是自增，没有用到传值  所以结果是一样的
        List<int> vs = new List<int>
        {
            1,
            2,
            3
        };

        for (int i = 0; i < vs.Count; i++)
        {
            Console.WriteLine(vs[i]);//1 2 3
        }

        for (int i = 0; i < vs.Count; ++i)
        {
            Console.WriteLine(vs[i]);//1 2 3
        }

        Console.WriteLine("========================");
        for (int i = 0; i < vs.Count;)
        {
            Console.WriteLine(vs[i]);//1 2 3
            i++;
        }

        int index1 = 0;
        if (index1 < vs.Count)
        {
            Console.WriteLine(vs[index1]);
            index1++;//index = 1
        }
        if (index1 < vs.Count)
        {
            Console.WriteLine(vs[index1]);
            index1++;//index = 2
        }
        if (index1 < vs.Count)
        {
            Console.WriteLine(vs[index1]);
            index1++;//index = 3
        }





        for (int i = 0; i < vs.Count;)
        {
            Console.WriteLine(vs[i]);//1 2 3
            ++i;
        }

        int index2 = 0;
        if (index2 < vs.Count)
        {
            Console.WriteLine(vs[index2]);
            ++index2;//index = 1
        }
        if (index2 < vs.Count)
        {
            Console.WriteLine(vs[index2]);
            ++index2;//index = 2
        }
        if (index2 < vs.Count)
        {
            Console.WriteLine(vs[index2]);
            ++index2;//index = 3
        }
    }

    void StringSort()
    {

        List<string> vs = new List<string>();
        vs.Add("A/B/C");
        vs.Add("A");
        vs.Add("A/B");

        vs.Add("F/B");

        vs.Sort();

        Console.WriteLine(string.Join(",", vs));
    }

    private void As_Test()
    {

        Animal dog = new Dog();

        Console.WriteLine(dog is Animal);//True

        Dog dog1 = new Dog();

        Animal animal = dog1 as Animal;//多余的转换
        Console.WriteLine(animal == null);//False

        Animal animal1 = dog1 as Animal;//多余的转换
        Console.WriteLine(animal == null);//False

        Dog dog2 = animal as Dog;//向下转型
        Console.WriteLine(dog2 == null);//False
    }

    void GetHashCodeTest()
    {
        var str1 = "wzx";
        var str2 = "www";

        Console.WriteLine("wzx hash code:" + str1.GetHashCode());
        Console.WriteLine("www hash code:" + str2.GetHashCode());


        StudentClass student1 = new StudentClass();
        student1.Name = "1";

        StudentClass student2 = new StudentClass();
        student2.Name = "1";

        Console.WriteLine("student1== student2   " + (student1 == student2));
        Console.WriteLine("student1.Equals(student2)   " + (student1.Equals(student2)));
        Console.WriteLine("student1.GetHashCode()==student2.GetHashCode()  " + (student1.GetHashCode() == student2.GetHashCode()));
    }

    void ReturnTest()
    {
        Console.WriteLine("1");
        Return();
        Console.WriteLine("2");
        Console.WriteLine("3");
    }

    void Return()
    {
        return;
    }

    void StackTest()
    {
        //栈是先进后出
        Stack<string> strStack = new Stack<string>();
        //元素入栈用push,就是向栈中添加元素
        strStack.Push("A");
        strStack.Push("B");
        strStack.Push("C");

        //获取stack 中的元素个数
        int num = strStack.Count;
        //Pop出栈，返回栈顶的元素 并且删除
        string str1 = strStack.Pop();
        //popPeek返回栈顶的元素 不删除
        string str2 = strStack.Peek();

        strStack.Clear();




        Stack<int> vs = new Stack<int>(1);
        vs.Push(1);
        vs.Push(2);
        vs.Push(3);

        //Console.WriteLine("Count:" + vs.Count.ToString());//Count:3
        //Console.WriteLine(vs.Pop());//3
        //Console.WriteLine("Count:" + vs.Count.ToString());//Count:2
        //Console.WriteLine(vs.Pop());//2
        //Console.WriteLine("Count:" + vs.Count.ToString());//Count:1
        //Console.WriteLine(vs.Pop());//1
        //Console.WriteLine(vs.Pop());//InvalidOperationException: Stack empty.

        Console.WriteLine("Count:" + vs.Count.ToString());//Count:3
        Console.WriteLine(vs.Peek());//3
        Console.WriteLine("Count:" + vs.Count.ToString());//Count:3
        Console.WriteLine(vs.Peek());//3
        Console.WriteLine("Count:" + vs.Count.ToString());//Count:3
        Console.WriteLine(vs.Peek());//3
        Console.WriteLine(vs.Peek());//3
    }

    void QueueTest()
    {
        //队列是先进先出
        Queue<string> strQueue = new Queue<string>();
        strQueue.Enqueue("A");
        strQueue.Enqueue("B");
        strQueue.Enqueue("C");

        int count = strQueue.Count;
        //返回队列里面第一个元素  并且删除这个元素
        string str1 = strQueue.Dequeue();
        //返回队列里面第一个元素
        string str2 = strQueue.Peek();
    }

    /// <summary>
    /// 朗母达表达式排序
    /// </summary>
    private void LongmudaSort()
    {
        //var list = new List<Student>
        //    {
        //        new Student (10,160),
        //        new Student (20,170),
        //        new Student (20,150)
        //    };

        //for (int i = 0; i < list.Count; i++)
        //{
        //    Console.WriteLine(list[i].ToString());
        //}

        //Console.WriteLine("==============");

        //按照年龄排序
        //如果年龄一致的话则按照身高排序

        //list.Sort((item1, item2) =>
        //{
        //    if (item1.Age == item2.Age)
        //    {
        //        return item1.Height.CompareTo(item2.Height);
        //    }
        //    return item1.Age.CompareTo(item2.Age);
        //});

        ////权重大的排前面
        //list.Sort((item1, item2) => item1.Age.CompareTo(item2.Age) * 2 + item1.Height.CompareTo(item2.Height));


        ////list.AddRange(new List<Student>());
        //for (int i = 0; i < list.Count; i++)
        //{
        //    Console.WriteLine(list[i].ToString());
        //}



        List<Tuple<int, int>> tmp = new List<Tuple<int, int>>()
        {
            new Tuple<int,int>(2,1),
            new Tuple<int,int>(53,1),
            new Tuple<int,int>(12,1),
            new Tuple<int,int>(22,3),
            new Tuple<int,int>(1,2),
        };

        //先按照Item2升序排列 Item2相同的情况下在按照Item1降序排列
        //tmp.Sort((x, y) =>
        //(x.Item1.CompareTo(y.Item1) * -1
        //+ x.Item2.CompareTo(y.Item2) * 2));

        //for (int i = 0; i < tmp.Count; i++)
        //{
        //    Console.WriteLine(tmp[i].Item1 + "," + tmp[i].Item2);
        //}
        //53,1
        //12,1
        //2,1
        //1,2
        //22,3


        //先按照Item2降序排列 Item2相同的情况下在按照Item1降序排列
        // tmp.Sort((x, y) =>
        //-(x.Item1.CompareTo(y.Item1)
        //+ x.Item2.CompareTo(y.Item2) * 2));
        // for (int i = 0; i < tmp.Count; i++)
        // {
        //     Console.WriteLine(tmp[i].Item1 + "," + tmp[i].Item2);
        // }
        //22,3
        //1,2
        //53,1
        //12,1
        //2,1


        //先按照Item2升序排列 Item2相同的情况下在按照Item1升序排列
        // tmp.Sort((x, y) =>
        //(x.Item1.CompareTo(y.Item1) * 1
        //+ x.Item2.CompareTo(y.Item2) * 2));
        // for (int i = 0; i < tmp.Count; i++)
        // {
        //     Console.WriteLine(tmp[i].Item1 + "," + tmp[i].Item2);
        // }
        //2,1
        //12,1
        //53,1
        //1,2
        //22,3



        //先按照Item2升序排列 Item2相同的情况下在按照Item1降序排列
        // tmp.Sort((x, y) =>
        //(y.Item1.CompareTo(x.Item1) * 1
        //+ x.Item2.CompareTo(y.Item2) * 2));
        // for (int i = 0; i < tmp.Count; i++)
        // {
        //     Console.WriteLine(tmp[i].Item1 + "," + tmp[i].Item2);
        // }
        //53,1
        //12,1
        //2,1
        //1,2
        //22,3

        //先按照Item2降序排列 Item2相同的情况下在按照Item1降序排列
        tmp.Sort((x, y) =>
       (y.Item1.CompareTo(x.Item1) * 1
       + y.Item2.CompareTo(x.Item2) * 2));
        for (int i = 0; i < tmp.Count; i++)
        {
            Console.WriteLine(tmp[i].Item1 + "," + tmp[i].Item2);
        }
        //22,3
        //1,2
        //53,1
        //12,1
        //2,1
    }

    /// <summary>
    /// 向右操作运算符
    /// 向左操作运算符
    /// </summary>
    private void OperatorTest()
    {
        int m = 8;
        Console.WriteLine(m >> 1);//十进制转化为二进制 8 = 1000 ，1向右边移动1位，0100，即4
        Console.WriteLine(m >> 2);//十进制转化为二进制 8 = 1000 ，1向右边移动2位，0010，即2
        Console.WriteLine(m >> 3);//十进制转化为二进制 8 = 1000 ，1向右边移动3位，0001，即1

        int n = 2;
        Console.WriteLine(n << 1);//十进制转化为二进制 2 = 10 ，1向左边移动1位，100，即4
        Console.WriteLine(n << 2);//十进制转化为二进制 2 = 10 ，1向左边移动2位，1000，即8
        Console.WriteLine(n << 3);//十进制转化为二进制 2 = 10 ，1向左边移动3位，10000，即16
    }

    /// <summary>
    /// 反射程序集，调用其中的静态函数
    /// </summary>
    public void LoadAssemblyInvokeStaticMethod()
    {
        string assemblyPath = @"E:\wangzuxiong\Unity Project\UnityLearn\Library\ScriptAssemblies\Assembly-CSharp.dll";
        string className = "Lab";
        string methodName = "TestStaticMethod";
        Assembly assembly = Assembly.LoadFile(assemblyPath);
        Type type = assembly.GetType(className);
        MethodInfo methodInfo = type.GetMethod(methodName);
        methodInfo.Invoke(null, new object[] { 1 });
    }

    public static void TestStaticMethod(int x)
    {
        Console.WriteLine(x);
    }

    /// <summary>
    /// 反射程序集，调用其中的非静态函数
    /// </summary>
    public void LoadAssemblyInvokeMethod()
    {
        string assemblyPath = @"E:\wangzuxiong\Unity Project\UnityLearn\Library\ScriptAssemblies\Assembly-CSharp.dll";
        string className = "Lab";
        string methodName = "TestStaticMethod";
        Assembly assembly = Assembly.LoadFile(assemblyPath);
        Type type = assembly.GetType(className);
        var instance = Activator.CreateInstance(type);
        MethodInfo methodInfo = type.GetMethod(methodName);
        methodInfo.Invoke(instance, new object[] { 1 });
    }


    public void MyInvoke(object obj, string methodName, params object[] vs)
    {
        obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase).Invoke(obj, vs);
    }

    public void TestMethod(int x)
    {
        Console.WriteLine(x);
    }


   


    public struct StudentStruct
    {
        public int Age;
        public int Height;
        public string Name;
    }


    public class StudentClass
    {
        public int Age;
        public int Height;
        public string Name;


        //public override bool Equals(object obj)
        //{
        //    return Name == ((Student)obj).Name;
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        //public Student(int age, int height)
        //{
        //    Age = age;
        //    Height = height;
        //}

        //public override string ToString()
        //{
        //    return ("Age:" + Age + " Height:" + Height);
        //}

        public void Say(string str)
        {
            Console.WriteLine("==>" + str);
        }
    }

    /// <summary>
    /// 字典比较的方案
    /// </summary>
    public void DictComparerTest()
    {
        //用枚举用作Dict的Key时，会有装箱的的操作
        Dictionary<TestEnum, int> keyValuePairs = new Dictionary<TestEnum, int>();


        //比较合理的方式 不造成装箱的操作
        Dictionary<TestEnum, int> keyValuePairs2 = new Dictionary<TestEnum, int>(new DictEqualityComparer());
    }

    /// <summary>
    /// Key比较器
    /// </summary>
    public class DictEqualityComparer : IEqualityComparer<TestEnum>
    {
        public bool Equals(TestEnum x, TestEnum y)
        {
            return x == y;
        }

        public int GetHashCode(TestEnum obj)
        {
            return (int)obj;
        }
    }

    public enum TestEnum
    {
        X = 1,
        Y = 2,
        Z = 3
    }

    public abstract class TestA 
    {
        /// <summary>
        /// 抽象
        /// </summary>
        public abstract void Func1();

        internal abstract void Func3();

        protected abstract void Func2();


        public virtual void Func4()
        {

        }

    }
    public class TestB : TestA
    {
        public override void Func1()
        {
            throw new System.NotImplementedException();
        }

        protected override void Func2()
        {
            throw new System.NotImplementedException();
        }

        internal override void Func3()
        {
            throw new System.NotImplementedException();
        }

        public override void Func4()
        {
            base.Func4();
        }
    }


    class Animal
    {
        public void call() { Console.WriteLine("无声的叫唤"); }
    }

    class Dog : Animal
    {
        // new的作用是隐藏父类的同名方法
        public new void call() { Console.WriteLine("叫声：汪～汪～汪～"); }
        public void smell() { Console.WriteLine("嗅觉相当不错！"); }
    }



    void EncryptionTest()
    {
        var str = "123";
        var bytes = Encoding.UTF8.GetBytes(str);
        Console.WriteLine(string.Join(",", bytes));
        var strFromBytes = Encoding.UTF8.GetString(bytes);
        Console.WriteLine(strFromBytes);



        Console.WriteLine("========加密========");
        //加密
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= 1;
        }
        Console.WriteLine(string.Join(",", bytes));
        var strFromBytes1 = Encoding.UTF8.GetString(bytes);
        Console.WriteLine(strFromBytes1);



        Console.WriteLine("========解密========");
        //解密
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= 1;
        }
        Console.WriteLine(string.Join(",", bytes));
        var strFromBytes2 = Encoding.UTF8.GetString(bytes);
        Console.WriteLine(strFromBytes2);
    }



    /// <summary>
    /// List Remove Advance 
    /// 对List排序无要求的情况下
    /// 可以先将要remove的元素与List尾部的元素交换位置，之后在remove
    /// 这样就少了整体向后偏移 的一个过程
    /// 效率能够提高
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="value"></param>
    public static void ListRemoveAdvance<T>(List<T> list, T value)
    {
        if (value.Equals(list[list.Count - 1]))
        {
            list.Remove(value);
            return;
        }

        int index = list.FindIndex((item) =>
        {
            return item.Equals(value);
        });
        //将value移到最后
        var temp = list[index];
        list[index] = list[list.Count - 1];
        list[list.Count - 1] = temp;

        list.Remove(value);
    }
}



