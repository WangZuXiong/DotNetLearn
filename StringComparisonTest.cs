using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLearn
{
    static class StringComparisonTest
    {
        //使用序数比对可将速度提高大约十倍，这种比较类型以 C 和 C++ 工程师熟悉的方式比较字符串：简单地比较字符串的每个连续字节，不考虑该字节所表示的字符。
        //切换至序数比对的方式非常简单，只需将 StringComparison.Ordinal 作为最终参数提供给 String.Equals：
        public static bool ComparisonWithOrdinal(string str1, string str2)
        {
            return str1.Equals(str2, StringComparison.Ordinal);
        }

        public static bool Comparison(string str1, string str2)
        {
            return str1.Equals(str2);
        }

        public static bool Equals(string str1, string str2)
        {
            return string.Equals(str1, str2);
        }


        public static bool CustomEndsWith(this string a, string b)
        {
            int ap = a.Length - 1;
            int bp = b.Length - 1;

            while (ap >= 0 && bp >= 0 && a[ap] == b[bp])
            {
                ap--;
                bp--;
            }

            return (bp < 0);
        }

        public static bool CustomStartsWith(this string a, string b)
        {
            int aLen = a.Length;
            int bLen = b.Length;

            int ap = 0; int bp = 0;

            while (ap < aLen && bp < bLen && a[ap] == b[bp])
            {
                ap++;
                bp++;
            }

            return (bp == bLen);
        }
    }
}
