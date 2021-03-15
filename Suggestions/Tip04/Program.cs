using System;
using System.Diagnostics;

namespace Tip04
{
    class Program
    {
        static void Main(string[] args)
        {
            double re;
            long ticks;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                try
                {
                    re = double.Parse("123");
                }
                catch (Exception e)
                {
                    re = 0;
                }
            }

            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"double.Parse()成功，{ticks} ticks");

            stopwatch=Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                if (double.TryParse("123",out re)==false)
                {
                    re = 0;
                }
            }
            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"double.TryParse()成功,{ticks} ticks");


            stopwatch=Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                try
                {
                    re = double.Parse("aaa");
                }
                catch (Exception e)
                {
                    re = 0;
                }
            }
            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"double.Parse()失败,{ticks} ticks");

            stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                if (double.TryParse("aaa", out re) == false)
                {
                    re = 0;
                }
            }
            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"double.TryParse()失败,{ticks} ticks");
        }
    }
}
