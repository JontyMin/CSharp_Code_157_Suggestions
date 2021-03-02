namespace Tip03
{
    public class SecondType:FirstType
    {
        public string Name { get; set; }

        /*
        public static explicit operator SecondType(FirstType firstType)
        {
            SecondType secondType = new SecondType()
            {
                Name = $"转型自{firstType.Name}"
            };
            return secondType;
        }
        */
        static void DoWithSomeType(object obj)
        {
            //SecondType secondType = (SecondType) obj;
            //SecondType secondType = obj as SecondType;
            //if (secondType!=null)
            //{
                
            //}


            // is 不能操作基元类型
            if (obj is SecondType)
            {
                SecondType secondType = obj as SecondType;
            }
        }
    }
}