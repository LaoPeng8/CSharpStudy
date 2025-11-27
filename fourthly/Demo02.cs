using System;
using System.Collections.Generic;
using System.Text;

namespace fourthlySeason
{
    class Student
    {
        public Student()
        {
        }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    internal class Demo02
    {
        private delegate string ShowStudent(Student student);// 定义委托 (委托本质上是一个类, 所以不能定义在方法内)

        /// <summary>
        /// 测试委托
        /// 
        /// 
        /// 
        /// 测试委托
        ///     1.需要使用 delegate 关键字定义一个方法, 主要是输入参数和返回值
        ///     2.然后在方法内部就可以直接使用这个方法了 (因为具有相同的输入参数和返回值, 所以这个方法实际的效果是已经达到了(尽管没有实现))
        ///     3.我们在实际调用时候, 就需要传入一个方法（参数和返回值一致）, 那么这个方法中实际执行的就是我们传入的方法了
        /// 
        /// 类似Java的函数式编程 @Function
        ///     1.先定义一个接口, 接口中只有一个方法, 规定了输入参数和返回值
        ///     2.其他类及方法使用时, 可以直接通过参数, 传入一个这个接口对象, 然后就可以直接调用这个方法了 (因为具有相同的输入参数和返回值, 所以这个方法实际的效果是已经达到了(尽管没有实现))
        ///     3.我们在调用这个类的方法时, 就要传入一个这个接口对象, 具体的实现由我们直接传入(Lambda或匿名内部类), 我们传入的什么, 这个方法中实际执行的就是什么
        /// </summary>
        public void Test01()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(1, "张三", 10),
                new Student(2, "李四", 15),
                new Student(3, "王五", 13),
                new Student(4, "赵六", 21)
            };

            // 测试委托, 通过Lambda的方式, 传入的 ShowStudent 的实现, 相当于就将这个Lambda作为实参 赋值给了 形参showStudent
            PrintStudent(studentList, (x) => {
                return x.Name;
            });


            //ShowStudent showStudentT = ShowStudentT;// 两种赋值委托的方式
            ShowStudent showStudentT = new ShowStudent(ShowStudentT);
            PrintStudent(studentList, showStudentT);// 实实在在传入一个方法
        }

        // 实现一个委托方法
        private string ShowStudentT(Student student)
        {
            return "{没有学生}";
        }

        /// <summary>
        /// 打印列表中的Student, 至于具体如何打印, 由外界通过委托传入(更加灵活)
        /// </summary>
        /// <param name="studentList"></param>
        /// <param name="showStudent"></param>
        /// <exception cref="Exception"></exception>
        private void PrintStudent(List<Student> studentList, ShowStudent showStudent)
        {
            if(showStudent == null)
            {
                throw new Exception("getStudent is null");
            }

            foreach (Student student in studentList)
            {
                string studentString = showStudent(student);
                Console.WriteLine(studentString);
            }
        }

        /// <summary>
        /// 除了我们自己定义委托之外(private delegate string ShowStudent(Student student); 这种就是我们自己定义的委托)
        /// 系统还给我们提供了内置的的委托类型
        ///     Action<in T1, in T2, ...> 返回值 void, 输入参数 0~N个
        ///     Func<in T1, in T2, ..., out TResult> 有一个返回值, 输入参数 0~N个
        /// 
        /// 类似于Java中自带的 四大函数接口
        ///     Consuemr<T> 输入一个参数, 返回0个值
        ///     Supplier<T> 输入0个参数, 返回一个值
        ///     Function<T,R> 输入一个参数，返回一个参数
        ///     Predicate<T> 输入一个参数, 判断是否满足条件, 返回boolean
        /// 
        /// </summary>
        public void Test02()
        {
            Action method1 = Demo1;
            method1();

            Action<int> method2 = Demo2;
            method2(12345);

            Action<int, double> method3 = Demo3;
            method3(12345, 54321.0);

            Func<string> method4 = Demo4;
            Console.WriteLine(method4());

            Func<int, string> method5 = Demo5;
            Console.WriteLine(method5(2));


        }

        private void Demo1()
        {
            Console.WriteLine("Demo1");
        }

        private void Demo2(int x)
        {
            Console.WriteLine("Demo2: " + x);
        }

        private void Demo3(int x, double y)
        {
            Console.WriteLine("Demo3: " + (x + y));
        }


        private string Demo4()
        {
            return "弃我去者, 昨日之日不可留";
        }
        private string Demo5(int x)
        {
            return "乱我心者, 今日之日多烦忧" + "("+x+"行)";
        }

        /// <summary>
        /// 多播委托
        ///     委托可以包含多个方法, 这种委托称为多播委托, 使用多播委托就可以按照顺序调用多个方法, 多播委托只能得到调用的最后一个方法的结果, 所以一般我们把多播委托的返回类型声明为void
        ///     多播委托包含一个逐个调用的委托集合, 如果通过委托调用的其中一个方法抛出异常, 整个迭代就会停止.
        ///     
        /// 取得委托中的所有方法 GetInvocationList()
        /// </summary>

        public void Test03()
        {
            Action action = Demo5;
            action += Demo6;
            action += Demo5;

            //action();

            Delegate[] delegates = action.GetInvocationList();// 获取委托中的所有方法
            foreach(Delegate item in delegates)
            {
                item.DynamicInvoke();// 调用委托中的方法
            }

        }

        private void Demo5()
        {
            Console.WriteLine("滚滚长江东逝水");
        }
        private void Demo6()
        {
            Console.WriteLine("浪花淘尽英雄");
        }


        /// <summary>
        /// 匿名方法, 大多数赋值给委托的方法, 都只在此处调用, 单独定义一个方法对整体结构不优雅, 就可以使用匿名方法
        /// </summary>
        public void Test04()
        {
            // 匿名方法, 直接通过 delegate (参数列表) {方法体}
            Func<int, int, int> plus = delegate (int x, int y)
            {
                return x + y;
            };

            int res = plus(1, 2);
            Console.WriteLine("result: " + res);
        }

        /// <summary>
        /// Lambda 表达式简化匿名方法
        /// </summary>
        public void Test04Plus()
        {
            //Func<int, int, int> plus = (x, y) => { return x + y; };
            Func<int, int, int> plus = (x, y) =>  x + y;// 当Lambda方法体只有一行语句时, 可以省略 {} 和 return

            int res = plus(1, 2);
            Console.WriteLine("result: " + res);
        }

        /// <summary>
        /// Lambda 可以访问外部的 参数 (既然Lambda可以房屋内外部的参数, 那么显然匿名方法(Test04())也是可以访问外部的参数的)
        /// </summary>
        public void Test05() {
            int b = 10;
            Func<int, int> func = (a) => a + b;

            int res = func(510);
            Console.WriteLine("result: " + res);
        }
    }
}
