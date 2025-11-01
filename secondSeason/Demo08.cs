using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    /**
     * 泛型
     * 在Java泛型中，虽然可以使用任意标识符作为类型参数，但业界形成了一套约定俗成的命名规范来增强代码的可读性
     * 常用泛型类型参数规范
     * T (Type)‌ - 表示具体类型，最常用的泛型参数
     * E (Element)‌ - 表示集合中的元素类型
     * K (Key)‌ - 表示键值对中的键
     * V (Value)‌ - 表示键值对中的值
     * N (Number)‌ - 表示数值类型
     */
    public class ClassA<T>
    {
        private T A;
        private T B;

        private ClassA()
        {
        }

        public ClassA(T a, T b)
        {
            A = a;
            B = b;
        }

        public T GetSum()
        {
            dynamic num1 = A;
            dynamic num2 = B;
            dynamic result = num1 + num2;

            return (T)result;
        }
    }

    public class ClassB
    {
        public int A { get; set; }
        public int B { get; set; }

        public ClassB() { }
        public ClassB(int a, int b)
        {
            this.A = a;
            this.B = b;
        }
    }

    public class ClassC
    {
        public int A { get; set; }
        public int B { get; set; }

        public ClassC() { }
        public ClassC(int a, int b)
        {
            this.A = a;
            this.B = b;
        }

        //public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        public override string? ToString()
        {
            return $"A = {this.A}, B = {this.B}";
        }
    }

    public class AddTools
    {
        /**
         * 泛型方法
         * 泛型可以不用一定定义在类上, 也可以作用与单个方法指定泛型
         * 
         * params T[] objs 相当于 params int[] objs , 参数数组, 也就相当于是可变参数, 必须位于方法参数的最后一个参数, 定义为数组, 输入时实际是 多个 int变量
         * 
         * 在C#中，out关键字用于通过引用传递参数，特别适用于需要从方法返回多个值的场景
         * 与按值传递不同，out参数传递的是变量的内存地址，使得方法能够直接修改调用方的变量值
         * 使用out参数时，方法定义和调用都必须显式使用out关键字
         * 调用前变量无需初始化，但方法必须在返回前为out参数赋
         * 
         * 
         */
        public static int GetSum<T>(out int count, params T[] objs)
        {
            int result = 0;
            count = 0;
            foreach (T obj in objs)
            {
                result = result + Convert.ToInt32(obj);
                count++;
            }

            return result;
        }
    }

    public class Demo08
    {

        public static void Test01()
        {
            List<int> list = new List<int>();
            List<int> list1 = new List<int>(new int[] {1,2,3,4,5});
            List<int> list2 = new List<int>() { 10, 20, 30, 40, 50, 60 };// 为什么可以像数组一样初始化, 如果要这种形式, 老老实实从构造方法中传个数组, 或多个数组元素感觉还是好一些
            List<int> list3 = new List<int>(100);// 指定初始化长度

            list.Add(100);
            list.Add(200);
            list.Add(300);

            list[2] = 305;
            Console.WriteLine(list[2]);
            Console.WriteLine(string.Join(", ", list));
        }

        public static void Test02() {

            List<int> list = new List<int>(new int[] {10, 20, 30, 40, 50, 60});

            Console.WriteLine("此时List内维护的数组的长度: " + list.Capacity);
            Console.WriteLine("此时List的元素个数: " + list.Count);
            Console.WriteLine("此时List: " + string.Join(", ", list));


            Console.WriteLine();
            list.Insert(3, 35);// 插入元素至List的下标为3的位置, 值 35
            Console.WriteLine("此时List: " + string.Join(", ", list));


            Console.WriteLine();
            list.Insert(0, 100);
            list.Insert(3, 100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            Console.WriteLine("此时List内维护的数组的长度: " + list.Capacity);
            Console.WriteLine("此时List的元素个数: " + list.Count);
            Console.WriteLine("此时List: " + string.Join(", ", list));

            list.Remove(100);// 删除100这个元素, 删除的是第一次出现的100, 只会删除一个 (如果删除的数字在List中找不到, 也不会报错, 但会return false)
            Console.WriteLine("执行: list.Remove(100);");
            Console.WriteLine("此时List: " + string.Join(", ", list));

            list.RemoveAt(5);// 根据下标删除
            Console.WriteLine("执行: list.RemoveAt(5);");
            Console.WriteLine("此时List: " + string.Join(", ", list));


            // 根据条件删除
            //int removeCount = list.RemoveAll(x => x >= 100);

            // 查找List中该数据首次出现的位置(从前向后找), 找不到就是 -1
            Console.WriteLine();
            Console.WriteLine(list.IndexOf(100000));

            // 查找List中该数据最后一次出现的位置(从后向前找)
            Console.WriteLine();
            Console.WriteLine(list.LastIndexOf(100000));


            Console.WriteLine();
            ClassA<double> classA = new ClassA<double>(3.14, 3.16);
            Console.WriteLine(classA.GetSum());
            ClassA<float> classAA = new ClassA<float>(3.14f, 3.16f);
            Console.WriteLine(classAA.GetSum());

            /**
             * ToString() 默认是打印这个类的 namespace.类名 也就是这个类的完整路径 (这个ToString是继承至Object的)
             */
            Console.WriteLine();
            Console.WriteLine(new ClassA<int>(1, 2).ToString());// secondSeason.ClassA`1[System.Int32]
            Console.WriteLine(new ClassB().ToString());// secondSeason.ClassB
            Console.WriteLine(new ClassB(1, 2).ToString());// secondSeason.ClassB
            Console.WriteLine(new ClassC(1, 2).ToString());// A = 1, B = 2 (重写了ToString方法)
            Console.WriteLine(new ClassC(1, 2));// A = 1, B = 2 (和Java一样, 打印这个类, 默认就是调ToString)

            Console.WriteLine();
            int count = 0;
            Console.WriteLine("AddTools.GetSum(out count, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)");
            Console.WriteLine("结果为: " + AddTools.GetSum(out count, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
            Console.WriteLine("out count(参数个数): " + count);
        }


    }
}
