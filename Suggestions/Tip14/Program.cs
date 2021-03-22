using System;

namespace Tip14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Employee marry = new Employee()
            {
                IDCode = "A1", Age = 10,
                Department = new Department() {Name = "Dep1"}
            };

            Employee rose =marry.DeepCloneBeReflection<Employee>(marry) as Employee;
            Console.WriteLine($"{rose.IDCode}-{rose.Age}-{rose.Department}");
            Console.WriteLine("开始改变mike值");
            marry.IDCode = "A2";
            marry.Age = 20;
            marry.Department.Name = "Dep2";
            Console.WriteLine($"{rose.IDCode}-{rose.Age}-{rose.Department}");

        }
    }
}
