using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace fourthlySeason
{
    public class MyStudent
    {
        public string Name { get; set; }

        private string Description { get; set; }

        private int a;

        private int b;

        public int c;

        public string d;

        public string selectNameById()
        {
            return "小明";
        }

        public int deleteById()
        {
            return 1;
        }

        public void UpdateNameById(Guid id, string name) {}
    }

    /**
     * 反射
     */
    internal class Demo04
    {

        public void Test01()
        {
            // Type
            Type f = typeof(Demo04);
            Console.WriteLine("类名: " + f.Name);
            Console.WriteLine("命名空间: " + f.Namespace);
            Console.WriteLine("程序集: " + f.Assembly);

            /**
             * 无参的 GetFields() 只能获取到 public 的变量
             */
            //Type myStudentType = typeof(MyStudent);// 通过类名获取 Type 对象 (反射对象)
            Type myStudentType = new Student().GetType();// 通过对象获取 Type 对象 (反射对象)
            List<string> fieldList = new List<string>();  
            FieldInfo[] fieldInfos = myStudentType.GetFields();
            foreach (FieldInfo fi in fieldInfos)
            {
                fieldList.Add(fi.Name);
            }
            Console.WriteLine("利用反射获取,类MyStudent的 所有public 变量: [" + string.Join<string>(',', fieldList)+"]");// [c,d]


            /**
             * GetFields()
             *  BindingFlags.Public         获取public的变量
             *  BindingFlags.NonPublic      获取非public(private, protected, internal)的变量
             *  BindingFlags.Instance       获取实例变量(非静态变量)
             *  BindingFlags.Static         获取静态变量
             *  
             *  参数 用 | 来分割的解释
             *  (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
             *  实际传入的还是一个变量, 但是是一个全新的值, 即
             *  0001 Public
             *  0010 NonPublic
             *  0100 Instance
             *  1000 Static
             *  1111 经过 | 运算后得到的全新的值, 相当于拼接参数了
             *  
             *  | 运算符是C#中的按位或运算符, 用于组合多个位标志.
             *  由于 BindingFlags 枚举被设计为位标志, 使用 | 可以将多个搜索条件合并成一个参数传递给方法, 方法再通过位运算解析出所有被指定的条件.
             *  这是一种高效且灵活地传递多个选项的常见方法.
             */
            List<string> fieldList2 = new List<string>();
            FieldInfo[] fieldInfos2 = myStudentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo fi in fieldInfos2)
            {
                fieldList2.Add(fi.Name);
            }
            Console.WriteLine("利用反射获取,类MyStudent的 所有 变量: [" + string.Join<string>(',', fieldList2) + "]");// [<Name>k__BackingField,<Description>k__BackingField,a,b,c,d]


            /**
             * GetProperties() 用来获取属性
             * 
             */
            List<string> fieldList3 = new List<string>();
            PropertyInfo[] propertyInfos = myStudentType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo pi in propertyInfos)
            {
                fieldList3.Add(pi.Name);
            }
            Console.WriteLine("利用反射获取,类MyStudent的 所有 属性: [" + string.Join<string>(',', fieldList3) + "]");// [Name,Description]



            MethodInfo[] methodInfos = myStudentType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            List<string> methodList = new List<string>();
            foreach (MethodInfo mi in methodInfos)
            {
                methodList.Add(mi.Name);
            }
            Console.WriteLine("利用反射获取,类MyStudent的 所有 方法: [" + string.Join(",", methodList) + "]");// [get_Name,set_Name,get_Description,set_Description,selectNameById,deleteById,UpdateNameById,GetType,MemberwiseClone,Finalize,ToString,Equals,GetHashCode]

        }

    }
}
