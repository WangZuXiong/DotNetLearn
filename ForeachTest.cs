using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetLearn
{
    public class ForeachTest
    {
        public ForeachTest()
        {
            List<int> vs = new List<int>();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            foreach (var item in vs)
            {
                
            }

            foreach (var item in keyValuePairs)
            {

            }



            T t = new T();

            foreach (var item in t)
            {

            }

//public class List<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
//public class Dictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary, IDeserializationCallback, ISerializable where TKey : notnull
        
        }


        //实现IEnumerable接口 或者声明公共返回值为IEnumerator名为GetEnumerator的函数即可 使用foreach遍历
        public class T //: IEnumerable
        {
            //IEnumerator IEnumerable.GetEnumerator()
            //{
            //    throw new NotImplementedException();
            //}

            public IEnumerator GetEnumerator() { throw new Exception(); }

        }


        //IEnumerable

    }
}

