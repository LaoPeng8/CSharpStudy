using System;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    /**
     * 变量
     * 
     * int      : C#的关键字
     * Int32    : 遵循.NET规范
     * Int32和int是完全相同的类型, 仅是命名方式的差异 Int32是.NET框架中定义的结构体名称, 属于系统类型命名规范(如System.Int32), 而int是C#语言关键字, 为Int32的别名
     * int是Int32的语法糖，编译时会被直接替换为System.Int32
     * 
     * @Autoer PengJiaJun
     * @Date 2025-10-14 22:42
     */
    class Demo02
    {
        byte b = 1;// 1个字节, 0-255
        sbyte sb = -1;// 1个字节,  -128-127

        short sInt = 0;// 2个字节, -32768-32767
        Int16 sInt16 = 0;// 2个字节, 有符号位

        int tInt = 0;// 4个字节
        Int32 tInt32 = 0;// 4个字节, 有符号位

        long lLong = 0;// 8个字节
        Int32 lInt32 = 0;// 8个字节, 有符号位

        float fFloat = 0.0f;// 4个字节
        float fFloat2 = 3.14f;

        double dFloat = 0.0d;// 8个字节 
        double dFloat2 = 3.1415926;

        decimal d = 3.14m;// 16个字节

        bool flag = true;// 1个字节
        char c = 'a';// 2个字节

        public void Show()
        {
            char cc = '\n';

            string s = @"Hello, ""World""";// @下 转义不让用, 双引号可以通过两个 "" 来转移
            string str = @"C:\Program Files (x86)\Microsoft Visual Studio";// @会使字符串中的转义字符失效 \
            string str2 = @"\t \n";
            string sql = @"SELECT * 
               FROM Users 
               WHERE Id = 1";  // 直接换行，无需连接符


            Console.WriteLine("========================Demo02-Start=========================");
            Console.WriteLine(cc);
            Console.WriteLine(s);// Hello, "World"
            Console.WriteLine(str);
            Console.WriteLine(str2);// 原样输出 \t \n
            Console.WriteLine(sql);// 正常换行
            string userName = Console.ReadLine();// 读取一行
            int userAge = Convert.ToInt32(Console.ReadLine());// System.FormatException:“The input string '张三' was not in a correct format.”
            Console.WriteLine("you name:\t" + userName);// 正常换行
            Console.WriteLine("you age:\t" + userAge);// 正常换行
            Console.WriteLine("========================Demo02-End=========================");
        }


        public void Sum()
        {
            long a = 0L;
            long b = 0L;

            a = Convert.ToInt64(Console.ReadLine());
            b = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(a + b);
        }


        public void Avg()
        {
            Console.Write("请输入求平均数的个数:");
            int longListLength = Convert.ToInt32(Console.ReadLine());
            long[] longList = new long[longListLength];

            Console.WriteLine("\n请输入" + longListLength + "个数");
            for (int i = 0; i < longList.Length; i++)
            {
                longList[i] = Convert.ToInt64(Console.ReadLine());
            }


            Console.WriteLine("平均数为: " + longList.Sum() / longList.Length);
        }

        public void DivideMoney()
        {
            int a = 0;
            int b = 0;
            Console.WriteLine("将A元钱平均分给B个人，每个人可以分得多少？");
            Console.Write("A = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("每人可以分: " + (a / b) + "元钱");
            Console.WriteLine($"每人可以分: {a / b}元钱");
            Console.WriteLine("每人可以分: {0}元钱", (a / b));
        }

        public void Swap()
        {
            int a = 10;
            int b = 20;
            Console.WriteLine($"A = {a}");
            Console.WriteLine($"B = {b}");

            int temp = b;
            b = a;
            a = temp;
            Console.WriteLine("借助 temp 交换后");
            Console.WriteLine($"A = {a}");
            Console.WriteLine($"B = {b}");


            Console.WriteLine("=================================");
            int c = 500;
            int d = 800;
            Console.WriteLine($"C = {c}");
            Console.WriteLine($"D = {d}");

            c = c + d;// c = 1300, d = 800
            d = c - d;// c = 1300, d = 500
            c = c - d;// c = 800,  d = 500
            Console.WriteLine("加法交换后");
            Console.WriteLine($"C = {c}");
            Console.WriteLine($"D = {d}");

            Console.WriteLine("=================================");
            int e = 7;
            int f = 9;
            Console.WriteLine($"E = {e}");
            Console.WriteLine($"F = {f}");

            e = e ^ f;// 1110(14) = 0111(7) ^ 1001(9)
            f = e ^ f;// 0111(7 ) = 1110(14) ^ 1001(9)
            e = e ^ f;// 1001(9 ) = 1110(14) ^ 0111(7)
            Console.WriteLine("异或交换后(^仅适用于整数)");
            Console.WriteLine($"E = {e}");
            Console.WriteLine($"F = {f}");
        }

        public void Print()
        {
            int a = 1;
            int b = 2;
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);// 格式化输出
            Console.WriteLine("{0} + {0} = {2}", 10, 20, 30);// 10 + 10 = 30
        }

        public void SplitInt()
        {
            int a = 26;
            Console.WriteLine($"{a} 的十位数是: {a / 10}");
            Console.WriteLine($"{a} 的个位数是: {a % 10}");
        }
    }
}
