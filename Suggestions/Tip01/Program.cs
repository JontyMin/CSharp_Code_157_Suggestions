using System;
using System.Text;

namespace Tip01
{
    class Program
    {
        /*
         * 建议1 正确操作字符串
         * 尽量少的装箱
         * 避免分配额外的内存
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            String str1 = "str1" + 9;
            String str2 = "str2" + 9.ToString();
            NewMethod1();
            NewMethod2();
            NewMethod3();
            NewMethod4();
        }

        /// <summary>
        /// IL 创建3个字符串对象
        /// 执行1次concat
        /// </summary>
        private static void NewMethod1()
        {
            string s1 = "abc";
            s1 = "123" + s1 + "456";
        }

        /// <summary>
        /// 创建2个对象
        /// 执行1次ToSting 1次Concat
        /// </summary>
        private static void NewMethod2()
        {
            string s1 = 9 + "456";
        }

        /// <summary>
        /// 创建1个对象
        /// </summary>
        private static string NewMethod3()
        {
            /*
             *  IL_0001: ldstr        "123456789"
             *  IL_0006: stloc.0      // str
             */
            string str = "123" + "456" + "789";
            // 等效于 string str = "123456789";
            return str;
        }

        /// <summary>
        /// 效果同上
        /// </summary>
        /// <returns></returns>
        private static string NewMethod4()
        {
            const string a = "t";

            string str = "abc" + a; // a是常量

            // 等效于 "abc"+"t"

            return str;
        }



        /*
         * StringBuilder
         * 不会每一次都重新创建对象
         * 预先以非托管的方式分配内存
         * 默认长度16,当长度>16 <32
         * 按倍数分配内存
         */


        /// <summary>
        /// 创建5个对象
        /// 4次Concat
        /// </summary>
        private static void NewMethod7()
        {
            string a = "J";
            a += "o";
            a += "n";
            a += "t";
            a += "y";
        }
        /// <summary>
        /// 创建4个对象
        /// 1次Concat
        /// </summary>
        private static void NewMethod8()
        {
            string a = "J";
            string b = "o";
            string c = "n";
            string d = "y";
            string result = a + b + c + d;
        }

        private static void NewMethod9()
        {
            string a = "J";
            string b = "o";
            string c = "n";
            string d = "y";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(a);
            stringBuilder.Append(b);
            stringBuilder.Append(c);
            stringBuilder.Append(d);
            string result = stringBuilder.ToString();

            //string.Format("{0}{1}{2}{3}", a, b, c, d);
            var format = $"{a}{b}{c}{d}";
        }

    }
}
