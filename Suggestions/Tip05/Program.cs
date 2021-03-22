using System;

namespace Tip05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
             *
             * 可以为空的类型Nullable<T>
             * 因为是结构体 所以只有值引用类型才可以作为可空类型
             * 引用类型本身就可以为null
             *
             */
            //Nullable<int> i = null;
            int? i = null;

            int j = i ?? 0;
            // 如果i的HasValue为true 则将i的value赋值给j,否则就给j赋值为0
        }

        [Serializable]
        public struct Nullable<T> where T :struct
        {
            
        }
    }
}
