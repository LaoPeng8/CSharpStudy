using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{
    public class Student
    {
        public Student() { }
        public Student(string name, int age) { }

        // 这种是变量, 首字母小写, get set方法
        // 实际上变量和属性的区分是有没有 访问器 get; set;
        public string name;
        
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }


        // 这种是属性, 首字母大写, 属性在赋值或获取时 都是调用 get set 的, 就算没有定义, 那也是默认的 get set
        // 如果设置为私有 private, 那么就算设置了 get set 也访问不了
        public int Age
        {
            // 其他类调用时 student.Age 默认就是调用 get
            // 访问器可以单独设置访问权限 (默认是使用 属性上的访问权限)
            private get
            {
                return Age;
            }

            // set 中获取到的值默认是 value, 就是说其他类调用时 student.Age = 5; 会默认调用 Age的set来赋值, 而set中获取到的 5 也就是 value
            // 假如注掉set访问器, 则 Age属性是只读的, 只读属性 只能在‌声明时初始化(public int Age2 { get; } = 25)‌或在‌构造函数中赋值‌，在其他任何方法中都无法修改其值
            set
            {
                Age = value;
            }
        }

        private int Age2 { get; set; }


    }

    class Demo01
    {

        /**
         * 异常处理, C# 中的异常好像并没有像Java那种方法自己不处理异常而是直接往外抛, 由调用者来处理异常, 也就是说没有必须要处理的异常
         */
        public static void TestException()
        {
            int? t1 = null;
            int? t2 = null;


            while(true)
            {
                try
                {
                    Console.WriteLine("请输入数字");
                    t1 = int.Parse(Console.ReadLine());
                    t2 = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("请输入数字, 而不是其他");
                    t1 = null;
                    t2 = null;
                }

                if(t1 != null && t2 != null)
                {
                    break;
                }
            }

            Console.WriteLine($"{t1} + {t2} = {t1 + t2}");

        }


        public static void TestVariable()
        {
            var a = 4;
            //a = "abc"; // 报错, 匿名类型会在第一次赋值时 是什么类型就是什么类型, 后续不能改
        }
    }
}
