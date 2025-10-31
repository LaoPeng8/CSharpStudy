using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    public class Coke
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Coke()
        {
        }
        public Coke(long id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }


        /**
         * 运算符重载
         * 
         * 当我们重载 == 后, IDE会提示我们编译报错, 让我们重载 == 的同时 也需要重载 !=
         * 
         * 还有很多运算符可以重载
         * 
         */
        public static bool operator ==(Coke c1, Coke c2)
        {
            /**
             * System.StackOverflowException:“Exception of type 
             * 直接抛异常了, 栈溢出
             * 应该是 此处 c1 == null 中的 == 已经是重载的 == 了调用的还是本方法, 直接递归了
             * 所以重写的 == 中, 不能使用 ==, 那应该不会有null吧, 如果 c1 为null了, c1.Id 岂不是要空指针异常了
             */
            //if(c1 == null || c2 == null)
            //{
            //    return false;
            //}


            // 百度给出的结果是可以用 ReferenceEquals (System.Object 中的方法, 比较两个对象引用是否指向内存中的同一个实例)
            if (ReferenceEquals(c1, c2))
            {
                return true; 
            }

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false; 
            }



            if ((c1.Id > 0 && c1.Id == c2.Id) && (c1.Name != null && c1.Name ==  c2.Name) && (c1.Age == c2.Age))
            {
                return true;
            }


            return false;
        }

        public static bool operator !=(Coke c1, Coke c2)
        {
           
            return !(c1 == c2);// 可以直接调用 上方重载的 == 将结果取反
        }


    }

    public class Demo06
    {

        public static void Test01()
        {
            Coke coke1 = new Coke(1, "可乐一号", 60);
            Coke coke2 = new Coke(1, "可乐一号", 60);

            coke1 = null;
            Console.WriteLine("coke1 == coke2 : " + (coke1 == coke2));
        }

    }
}
