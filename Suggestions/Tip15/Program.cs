using System;
using System.Diagnostics;

namespace Tip15
{

    /*
     * dynamic让C#语言具有了弱语言的特性
     * 编译器在编译时不再对类型进行检查
     * dynamic与var
     * var 属于编译器的语法糖，编译时会自动匹配变量的实际类型，并用实际类型替换该变量的声明
     * dynamic在编译后实际上是一个object,运行时检查类型
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var times = 1000000;

            DynamicSample dynamicSample = new DynamicSample();
            var addMethod = typeof(DynamicSample).GetMethod("Add");
            var delg = (Func<DynamicSample, int, int, int>) Delegate.CreateDelegate(
                typeof(Func<DynamicSample, int, int, int>), addMethod);
            Stopwatch stopwatch1 = Stopwatch.StartNew();

            for (int i = 0; i < times; i++)
            {
                //addMethod.Invoke(dynamicSample, new object?[] { 1, 2 });
                delg(dynamicSample, 1, 2);
            }

            Console.WriteLine($"反射耗时：{stopwatch1.ElapsedMilliseconds}毫秒");

            dynamic dynamicSample2 = new DynamicSample();
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            for (int i = 0; i < times; i++)
            {
                dynamicSample2.Add(4, 2);
            }

            Console.WriteLine($"dynamic耗时：{stopwatch2.ElapsedMilliseconds}毫秒");
        }
    }


    public class DynamicSample
    {
        public string Name { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
