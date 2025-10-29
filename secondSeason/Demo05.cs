using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    public class Test01
    {
        /**
         * 索引器, 使得 Test01 类的对象可以以这种方式访问  test01[100]
         */
        public int this[int index]
        {
            get
            {
                int result = index + new Random().Next(index - 1000, index + 1000);
                Console.WriteLine("输入的下标是: " + index);
                Console.WriteLine("输出的值是: " + result);
                return result; 
            }

            set
            {
                Console.WriteLine("输入的下标是: " + index);
                Console.WriteLine("设置进入的值是: " + value);// 之前说了, 在set中, value 就是用户输入的值
            }
        }


        /**
         * 索引器可以有不同类型的参数, (相当于重载?) (好像还可以有多个参数)
         */
        public string this[string index]
        {
            get
            {
                Console.WriteLine("输入的下标是: " + index);
                Console.WriteLine("输入的值是: " + "张三");
                return "张三";
            }

            set
            {
                Console.WriteLine("输入的下标是: " + index);
                Console.WriteLine("设置进入的值是: " + value);// 之前说了, 在set中, value 就是用户输入的值
            }
        }
    }

    /**
     * 索引器就是可以说, 给像ArrayList, HashMap这种, 集合类, 或者普通的类, 提供一种较为方便的访问方式
     * ArrayList可以不用使用 add() get()等方法 使用 list[i] = 10, int value = list[i],
     * HashMap不用使用 get(key), put(key,value) 一样使用索引器 map[key] = value, value = map[key]
     * 
     * C#字典 Dictionary 就可以通过索引设置 key value
     */
    public class ArrayList
    {
        private string[] name = new string[10];

        public string this[int index]
        {
            get
            {
                return name[index];
            }

            set
            {
                name[index] = value;
            }
        }

    }

    public class Demo05
    {
        public static void Test01()
        {
            Test01 test01 = new Test01();

            /**
             * 输入的下标是: 5
             * 输出的值是: 87
             * 输入的下标是: 15
             * 设置进入的值是: 10087
             */
            int value = test01[5];
            test01[15] = value + 10000;

            /**
             * 输入的下标是: 张三
             * 输入的值是: 张三
             * 输入的下标是: 李四
             * 设置进入的值是: 李四
             */
            string name = test01["张三"];
            test01["李四"] = "李四";
        }


        public static void Test02()
        {

            ArrayList list = new ArrayList();
            list[3] = "小明";

            Console.WriteLine("list[3] = " + list[3]);

        }
    }
}
