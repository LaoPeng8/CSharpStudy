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

    }
}
