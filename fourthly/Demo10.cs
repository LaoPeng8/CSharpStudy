using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace fourthlySeason
{

    /// <summary>
    /// 扩展方法
    ///     扩展方法可以向现有的类型中添加新的方法
    ///     1. 定义扩展方法的类必须是 static 类
    ///     2. 扩展方法必须声明为 public 和 static
    ///     3. 扩展方法的第一个参数必须包含关键字this, 并且在后面指定扩展的类的名称
    /// 
    /// 
    /// Linq中提供了很多关于集合类的扩展方法, 而所有实现了IEnumerable<T>这个接口的类都可以使用这些方法. (这说明这些扩展方法参数是 (this IEnumerable<T>))
    /// </summary>
    public static class MyExtends
    {
        public static int StringToInt32(this string str)
        {
            return str.Length;
        }

        public static long StringToInt64(this string str)
        {
            return Convert.ToInt64(str);
        }

        public static int[] Sort(this int[] arr, int flag)
        {
            if (arr == null || arr.Length <= 0)
            {
                return new int[0];
            }

            if(flag > 0)
            {
                int[] ints = arr.ToList().OrderByDescending(x => x).ToArray();
                return ints;
            }else
            {
                int[] ints = arr.ToList().OrderBy(x => x).ToArray();
                return ints;
            }

        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public bool Gender { get; set; } = false;// true男, false女

        public override string? ToString()
        {
            return $"{{ID: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}, Gender: {Gender} }}";
        }
    }


    public delegate string SayHello(int age);

    /// <summary>
    /// Linq
    /// https://www.bilibili.com/video/BV1hEypYNE3f/
    /// https://www.bilibili.com/video/BV1rRyHYDE9d/
    /// </summary>
    internal class Demo10
    {
        List<Person> list = new List<Person>()
            {
                new Person() { Id = 1, Name = "张三", Age = 19, Salary = 2000, Gender = true },
                new Person() { Id = 1, Name = "张四", Age = 18, Salary = 3500, Gender = true },
                new Person() { Id = 2, Name = "老王", Age = 29, Salary = 20000, Gender = true },
                new Person() { Id = 3, Name = "老五", Age = 30, Salary = 3837, Gender = false },
                new Person() { Id = 3, Name = "老六", Age = 45, Salary = 3000, Gender = false },
                new Person() { Id = 3, Name = "老七", Age = 7, Salary = 30000, Gender = true },
                new Person() { Id = 3, Name = "老八", Age = 25, Salary = 9283, Gender = false },
            };

        public string SayChinese(int age)
        {
            return $"哈喽, 我的年龄是 {age}岁";
        }

        public string SayEnglish(int age)
        {
            return $"Hello, My age is {age}";
        }
        /**
         * 最原始的委托
         *      1.先定义委托
         *      2.再定义实际方法
         *      3.再给委托赋值
         *      4.再调用委托
         * 评价: 一般情况下不会使用, 99%, 因为 .net 自带的 Action 与 Func 已经可以完成绝大部分的要求, 不需要自己自定义委托类型
         */
        public void Test01()
        {
            SayHello sayChinese = SayChinese;
            SayHello sayEnglish = SayEnglish;

            Console.WriteLine(sayChinese(25));
            Console.WriteLine(sayEnglish(25));
        }


        /**
         * 更近一步的委托, 直接使用 Action 或 Func 两者之间前者无返回值, 后者有返回值, 参数都是 0 ~ N
         *      1.定义实际方法
         *      2.再给委托赋值
         *      3.再调用委托
         * 评价: 有一定的使用空间, 但大部分场景肯定是不用这种方式的, 可能当方法体比较大的时候, 匿名方法的看起来不太美观/直观时会用这种方式
         */
        public void Test02()
        {
            Func<int, string> sayChinese = SayChinese;
            Func<int, string> sayEnglish = SayEnglish;

            Console.WriteLine(sayChinese(25));
            Console.WriteLine(sayEnglish(25));
        }


        /**
         * 更近一步的委托, 使用匿名方法
         *      1.直接给委托赋值
         *      2.再调用委托
         * 评价: 一般情况下不会使用, 当需要赋值给委托的方法, 逻辑复杂/方法体大使会使用 Test02() 的方式, 当方法体小/只在此处调用时 会使用匿名方法的简化方式 Lambda
         */
        public void Test03()
        {
            Func<int, string> sayChinese = delegate (int age)
            {
                if(age < 0)
                {
                    age = -1;
                }
                string result = $"哈喽, 我的年龄是 {(age == -1 ? "未知" : age)}岁";
                return result;
            };

            Func<int, string> sayEnglish = delegate (int age)
            {
                if (age < 0)
                {
                    age = -1;
                }
                string result = $"Hello, My age is {(age == -1 ? "unknown" : age)}";
                return result;
            };

            Console.WriteLine(sayChinese(25));
            Console.WriteLine(sayEnglish(-199));
        }


        /**
         * 最终的方式 Lambda
         */
        public void Test04()
        {
            //按照Java Lambda的语法, 当只有一个参数时可省略参数处的(), 当方法体只有一句话时可省略 {}, 可省略 return
            Func<int, string> sayChinese = (age) => { return $"哈喽, 我的年龄是 {age}岁"; };
            Func<int, string> sayEnglish = age => $"Hello, my name is {age}";

            Console.WriteLine(sayChinese(25));
            Console.WriteLine(sayEnglish(-199));
        }


        /**
         * 不用 Linq 时处理数据
         */
        public void Test05()
        {
            List<int> MyFilter(int[] nums, Func<int, bool> fn)
            {
                List<int> list = new List<int>();
                foreach(int num in nums)
                {
                    if(fn(num))
                    {
                        list.Add(num);
                    }
                }

                return list;
            }

            int[] nums = { 30, 11, 2, 3, 90, 12, 33, 23 };
            List<int> list = MyFilter(nums, (num) => num > 10);

            Console.WriteLine($"[{string.Join(",", list)}]");
        }


        /**
         * 测试扩展方法
         */
        public void Test06()
        {
            string str = "储存条件: 常温密封保存. 开启前, 无需冷藏; 开启后, 请立即饮用. 说明: 请勿连同包装在微波炉中加热.";

            Console.WriteLine("长度: " + str.StringToInt32());// string默认是没有这些方法的, 这就是扩展方法, 我们自己添加的
            Console.WriteLine("数字: " + "1234567".StringToInt64());

            int[] nums = { 30, 11, 2, 3, 90, 12, 33, 23 };
            Console.WriteLine($"排序前: [{string.Join(",", nums)}]");
            Console.WriteLine($"降序后: [{string.Join(",", nums.Sort(1))}]");// int[] 类型原本也没有Sort, 这也是扩展方法
            Console.WriteLine($"升序后: [{string.Join(",", nums.Sort(0))}]");
        }


        /**
         * Linq Where Count LongCount
         */
        public void Test07()
        {
            IEnumerable<Person> personEnumerable = list.Where<Person>(o => o.Salary > 2000 && o.Age >= 20);
            Console.WriteLine("20岁及以上的人 同时 工资大于2000 的人有: " + personEnumerable.Count() + "个");// LongCount
            Console.WriteLine($"[{string.Join(",", personEnumerable.Select(o => o.Name))}]");//[laowang,laoli]


            Console.WriteLine(list.Count(o => o.Age >= 19));// 3 Count中也可以直接传入条件
        }


        /**
         * Linq
         * 
         * Single 如果有且只有一条满足条件的数据, 则返回数据, 如果返回值 大于1条 或 小于1条, 则会抛出异常
         * SingleOrDefault 如果返回值小于1条会返回默认值, 如果大于1条会抛出异常
         * 
         * First 如果满足条件的数据有一条或者多条, 会返回第一条数据, 如果没有满足条件的数据, 则会抛出异常
         * FirstOrDefault 如果满足条件的数据有一条或多条会返回第一条数据, 如果没有满足条件的数据会返回默认值
         * 
         * 最常用的是 FirstOrDefault() 另外几个根本没用过, 甚至没见过
         */
        public void Test08()
        {

            // Single
            try
            {
                list.Where(o => o.Age > 100).Single();
            } catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Single 抛出异常, 因为没有满足 Age > 100 的数据");
                Console.ForegroundColor = ConsoleColor.White;
            }
            try
            {
                list.Where(o => o.Age > 10).Single();
            } catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Single 抛出异常, 因为有多条 Age > 10 的数据");
                Console.ForegroundColor = ConsoleColor.White;
            }
            try
            {
                Person person = list.Where(o => o.Name == "zhangsi").Single();
                Console.WriteLine("Single 有且仅有返回一条数据 " + person.Name + ", " + person.Age + ", " + person.Salary);
            }
            catch (Exception e)
            {
            }

            // SingleOrDefault
            try
            {
                Person person = list.Where(o => o.Age > 10).OrderByDescending(o => o.Age).SingleOrDefault();
                Console.WriteLine(person.Name + ", " + person.Age + ", " + person.Salary);
            }
            catch (Exception e)
            {
                Console.WriteLine("SingleOrDefault 抛出异常, 因为有多条 Age > 10 的数据");
            }

            try
            {
                Person person = list.SingleOrDefault(o => o.Age > 100);
                if (person != null)
                {
                    Console.WriteLine(person.Name + ", " + person.Age + ", " + person.Salary);
                }
                else
                {
                    Console.WriteLine("SingleOrDefault 没有查到数据, 默认值: null");
                }
            }
            catch (Exception e)
            {
            }


            // First
            try
            {
                Person person = list.Where(o => o.Age > 10).OrderByDescending(o => o.Age).First();
                Console.WriteLine("First 返回第一条数据: " + person.Name + ", " + person.Age + ", " + person.Salary);
            }
            catch (Exception e)
            {
            }

            try
            {
                Person person = list.Where(o => o.Age > 1000).First();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First 抛出异常, 因为有多条 Age > 10 的数据");
                Console.ForegroundColor = ConsoleColor.White;
            }


            // FirstOrDefault
            // 真是构思, 眼睛都看瞎了, 根本没有必要一个一个测试
        }


        /**
         * Linq 排序
         */
        public void Test09()
        {
            // 参考 MyExtends.Sort()方法
            // 这是一种什么强迫症啊, 非得把教学中教的得测试一边, 明明是知道得

            // 需要注意的是 排序一次用 OrderBy 后面是 ThenBy

            list.OrderByDescending(o => o.Age).ThenByDescending(o => o.Salary);// 按年龄降序, 年龄一致按工资降序


            list.OrderBy(o => o.Age).ThenBy(o => o.Salary);// 按年龄升, 年龄一致按工资升序

        }


        /**
         * Linq Skip Take
         */
        public void Test10()
        {
            // 按年龄降序, 跳过前3条
            IEnumerable<Person> enumerable = list.OrderByDescending(o => o.Age).Skip(3);
            Console.WriteLine($"升序后: \n[\n{string.Join(",\n", enumerable.Select(o => o.ToString()))}\n]");

            // 按年龄降序, 获取一条数据
            IEnumerable<Person> enumerable1 = list.OrderByDescending(o => o.Age).Take(1);
            Console.WriteLine($"升序后: \n[\n{string.Join(",\n", enumerable1.Select(o => o.ToString()))}\n]");


            // 类似分页, 每页2条数据, 第3页 (实际还是得先查出全部, 再分页)
            int pageIndex = 3;
            int pageSize = 2;
            IEnumerable<Person> enumerable2 = list.Skip((pageIndex-1) * pageSize).Take(pageSize);
            Console.WriteLine($"分页后: \n[\n{string.Join(",\n", enumerable2.Select(o => o.ToString()))}\n]");
            // 1,2  3,4  5,6
            // (3-1) * 2 = 4; 第三页 5,6
        }

        /**
         * Linq 聚合函数 Max Min Avg Sum Count
         */
        public void Test11()
        {

            Console.WriteLine("最大年龄是: " + list.Max(o => o.Age));
            Console.WriteLine("最小年龄是: " + list.Min(o => o.Age));

            Console.WriteLine("平均年龄是: " + list.Average(o => o.Age));
            Console.WriteLine("年龄合计为: " + list.Sum(o => o.Age));
            Console.WriteLine("人数合计为: " + list.Count());

            Console.WriteLine("年龄大于等于30的用户中, 工资最高者: " + list.Where(o => o.Salary == list.Where(o => o.Age >= 30).Max(o => o.Salary)).FirstOrDefault());
            Console.WriteLine("年龄大于等于30的用户中, 工资最高者: " + list.Where(o => o.Age >= 30).OrderByDescending(o => o.Salary).Take(1).ToList()[0]);
        }

        /**
         * Linq group
         */
        public void Test12()
        {
            IEnumerable<IGrouping<bool, Person>> enumerable = list.GroupBy(o => o.Gender);

            foreach(IGrouping<bool, Person> groupItem in enumerable)
            {
                Console.WriteLine($"分组{groupItem.Key}: [{string.Join(",\n", groupItem.Select(o => o.ToString()))}]");
                Console.WriteLine($"分组{groupItem.Key}的人数: {groupItem.Count()}");
                Console.WriteLine($"分组{groupItem.Key}的工资最高者: {groupItem.OrderByDescending(o => o.Salary).FirstOrDefault()}");
                Console.WriteLine();
            }
        }

        /**
         * Linq 投影 select
         */
        public void Test13()
        {

        }
    }
}
