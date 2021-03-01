using System;
using System.Net;

namespace Tip02
{
    class Program
    {
        /*
         * top02
         * 使用默认转型方法
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 1、使用类型的转换运算符
            // 2、使用系统内置方法  Parse ,TryParse
            // 3、Convert转换帮助类
            int i = 0;
            float j = 0;
            j = i;   // int => float 隐式转换
            i = (int) j; // 显示转换


            Ip ip = "192.168.0.1";

            /*
             * 4、CLR支持的转型
             * 上溯转型、下溯转型：基类和子类互转
             */
            Animal animal;
            Cat cat = new Cat();

            animal = cat; // 隐式转换 Cat就是animal

            // cat = animal;// 编译报错
            cat = (Cat) animal;// 必须有一个显示转换

        }
    }

    class Ip
    {
        private IPAddress value;

        public Ip(string ip)
        {
            value = IPAddress.Parse(ip);
        }

        public static implicit operator Ip(string ip)
        {
            Ip iptemp = new Ip(ip);
            return iptemp;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
