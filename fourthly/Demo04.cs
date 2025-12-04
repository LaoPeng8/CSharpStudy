#define DEBUGXX
// 宏定义, 必须在第一行

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using fourthlySeason.myAttribute;

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
    [Info("PengJiaJun", "0.0.1", "这个类学习了反射, 特性 (最近几天都没学习啊, 下班了过的好快 T_T)")]
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

        /**
         * [] 特性
         * Obsolete("提示", 是否报错) false 仅给出警告, true则编译报错
         */
        [Obsolete("不再建议使用, 请使用 Demo04.Test03", false)]
        public void Test02()
        {
            Console.WriteLine("Hello, Test02");
        }

        public void Test03()
        {
            DebugLog("进入Test03()方法, " + DateTime.Now);
            Console.WriteLine("Hello, Test03");
            DebugLog("结束Test03()方法, " + DateTime.Now);
        }

        /**
         * 用来 Debug 时打印信息用的, 直接用 WriteLine 打印, 调试完成后可能忘记删除
         * 使用特性 可以很方便的开关 打印信息, 避免流入到生产环境
         * 
         * 仅当 宏定义 #define DEBUGXX 存在时, 该方法才存在, 其他类/方法调用本方法时, 才会实际调用, 否则不会调用
         * 
         * 奇怪的是 当我定义后 [Conditional("DEBUG")] 即使我未定义 #define DEBUG 该方法依旧会打印, 可能是其他哪些地方定义了 #define DEBUG 吗???
         */
        [Conditional("DEBUGXX")]
        public static void DebugLog(string message)
        {
            Console.WriteLine($"-----Message: {message}");
        }

        /**
         * [CallerFilePath] 调用者文件名 (哪个文件调用的我)
         * [CallerLineNumber] 调用者行号 (哪一行调用的)
         * [CallerMemberName] 谁调用的 (目前打印的是方法名)
         * 
         * [DebuggerStepThrough] Debug时, 不会进入该特性标记的方法, 直接略过
         */
        [DebuggerStepThrough]
        public void Test04(string msg, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",  [CallerLineNumber] int lineNumber = 0)
        {
            Console.WriteLine($"我打印了: {msg} (我被{filePath}文件中的{memberName}在{lineNumber}行处调用)");
            // 我打印了: 人有悲欢离合, 月有阴晴圆缺, 此事古难全 (我被D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\Program.cs文件中的<Main>$在29行处调用)
            // 我打印了: 但愿人长久, 千里共婵娟 (我被D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\Program.cs文件中的<Main>$在30行处调用)
        }

        /**
         * 
         */
        public void Test05()
        {
            Type demo04Type = typeof(Demo04);

            bool flag = demo04Type.IsDefined(typeof(InfoAttribute), false);// IsDefined 判断该类, 是否使用了特性 InfoAttribute
            Console.WriteLine(flag);

            object[] value = demo04Type.GetCustomAttributes(false);
        }
    }
}
