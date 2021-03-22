using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Tip14
{
    [Serializable]
    public class Employee:ICloneable
    {
        public string IDCode { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 使用二进制流 需要序列化属性
        /// </summary>
        /// <returns></returns>
        public Employee DeepClone()
        {
            using Stream objectStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream,this);
            objectStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objectStream)as Employee;
        }


        public  T DeepCloneBeReflection<T>(T obj)
        {
            if (obj.GetType().IsValueType)
            {
                return obj;
            }
            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                         BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in fields)
            {
                try
                {
                    field.SetValue(retval,DeepCloneBeReflection(field.GetValue(obj)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return (T)retval;
        }
    }

    [Serializable]
    public class Department
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}