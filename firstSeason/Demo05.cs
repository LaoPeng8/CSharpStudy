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
    }
}
