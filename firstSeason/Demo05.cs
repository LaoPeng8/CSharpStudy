using System;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    /// <summary>
    /// 学生 结构体
    /// </summary>
    struct StudentInfo
    {
        public int id;

        public string name;

        public int age;

        public int grade;

        // 结构体内也可以定义方法
        public void showStudentInfo()
        {
            Console.WriteLine($"学号: {id}\n姓名: {name}\n年龄: {age}\n年级: {grade}");
        }
    }

    class Demo05
    {
        public void TestStruct()
        {
            // 居然不用 new
            StudentInfo studentInfo;
            studentInfo.id = 1;
            studentInfo.name = "张三";
            studentInfo.age = 10;
            studentInfo.grade = 2;

            Console.WriteLine(studentInfo);// firstSeason.StudentInfo
            Console.WriteLine($"学号: {studentInfo.id}\n姓名: {studentInfo.name}\n年龄: {studentInfo.age}\n年级: {studentInfo.grade}");
            Console.WriteLine("===================================================================================================");
            studentInfo.showStudentInfo();
        }

        public void Add(int a, int b)
        {
            Console.WriteLine($"{a} + {b} = {a + b}");
        }

        public void Sub(int a, int b)
        {
            Console.WriteLine($"{a} - {b} = {a - b}");
        }

        /**
         * 委托, 感觉类似于抽象方法, 也类似于C语言的 函数指针
         */
        public delegate void MyDelegate(int a, int b);


        // 定义了一个委托, 具体实现不知道, 反正到时候传啥我执行啥
        public delegate void ShowGameOverButton();

        // 游戏中方法, 由于此时游戏结束后显示按钮的方法由其他人开发, 暂时调用不了, 可以以参数的这种方式灵活进行, 先调用, 后期通过参数传递
        public void play(ShowGameOverButton showGameOverButton)
        {
            Console.WriteLine("游戏中...");
            Console.WriteLine("挂了...");
            if(showGameOverButton != null)
            {
                showGameOverButton();
            }
        }

    }
}
