using System;

namespace Tip03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FirstType firstType = new FirstType(){Name="first type"};

            SecondType secondType = (SecondType) firstType; // 转型成功

            //secondType=firstType as SecondType; 编译不通过

            /*
             * 强制类型转换可能意味着两件不同的事情
             * 1、FirstType和SecondType依靠转换操作符完成转换
             * 2、FirstType是SecondType基类
             *
             * 如果类型之间存在强制转换 那么它们之间的关系只能是其中一种，
             * 不能同时有继承关系，又提供转换符
             */
            object obj = firstType;
            secondType = (SecondType) obj;// 转型失败
            // 编译器在这里判断的是secondType和object有没有继承关系
            // 所有的都继承自object基类 ，所以编译没有错误，但是在运行时会检查类型

            /*
             * Suggest：如果类型之间都上溯到了某个共同的基类
             * 那么根据此基类进行的转型(基类转型为子类本身)应该使用as
             * 子类与子类之间的转型应该提供转换操作符，进行强制转型
             */


        }
    }
}
