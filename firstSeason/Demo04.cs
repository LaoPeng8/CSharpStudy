using System;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    // 枚举
    enum OperationType
    {
        加 = 1,
        减 = 2,
        乘 = 3,
        除 = 4,
    }


    /**
     * 枚举每一个符号代表一个整数值, 一个比他前面的符号大的整数值.
     * 默认情况下, 第一个枚举符号的值是 0 (后续依次就是 1,2,3...), 可以修改默认值
     */
    enum Week
    {
        Sum,// 0
        Mon,// 1
        Tue,// 2
        Wed,// 3
        Thu,// 4
        Fri,// 5
        Sat// 6
    }

    enum WeekTwo
    {
        Sum = 5,// 5
        Mon,// 6
        Tue,// 7
        Wed = 15,// 15
        Thu,// 16
        Fri,// 17
        Sat// 18
    }

    class Demo04
    {
        // 常量
        private const double PI = 3.1415926;

        public void testArray()
        {
            int[] ageArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ageArray = new int[] { 1, 2, 3 };

            ageArray = new int[10];


            for (int i = 0; i < ageArray.Length; i++)
            {
                ageArray[i] = (i + 1) * 100;
            }


            foreach (int ageItem in ageArray)
            {
                Console.WriteLine(ageItem);
            }

        }

        public void testString()
        {

            string str = "abcdef";

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i] + " -> ");
            }
            Console.WriteLine();

            Console.WriteLine("\n=====================================================\n");

            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i] + " -> ");
            }
            Console.WriteLine();

        }


        /**
         * 喝可乐, 3个可乐瓶 兑换 1瓶可乐, 现在有364瓶可乐, 问一共可以喝多少瓶可乐, 剩下多少个空瓶
         */
        public void DrinkCoke()
        {
            Console.Write("请输入可乐的数量:");
            int number = Convert.ToInt16(Console.ReadLine());
            if(number <= 0)
            {
                number = 1;
            }

            int cokeNumber = number;// 已喝的数量
            int cokeEmptyNumber = number;// 空瓶的数量

            while(cokeEmptyNumber > 2)
            {
                cokeNumber += (cokeEmptyNumber / 3);
                cokeEmptyNumber = (cokeEmptyNumber / 3) + (cokeEmptyNumber % 3);
            }

            Console.WriteLine($"喝了{cokeNumber}瓶可乐, 剩下空瓶{cokeEmptyNumber}个");
        }

        public void CharEncode()
        {
            Console.Write("请输入需要加密的字符串:");
            string str = Console.ReadLine();
            if(string.IsNullOrEmpty(str))
            {
                str = "";
            }

            char[] result = str.ToCharArray();
            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case 'a':
                        {
                            result[i] = 'd';
                            break;
                        }
                    case 'b':
                        {
                            result[i] = 'e';
                            break;
                        }
                    case 'w':
                        {
                            result[i] = 'z';
                            break;
                        }
                    case 'x':
                        {
                            result[i] = 'a';
                            break;
                        }
                    case 'y':
                        {
                            result[i] = 'b';
                            break;
                        }
                    case 'z':
                        {
                            result[i] = 'c';
                            break;
                        }
                    case 'A':
                        {
                            result[i] = 'D';
                            break;
                        }
                    case 'B':
                        {
                            result[i] = 'E';
                            break;
                        }
                    case 'W':
                        {
                            result[i] = 'Z';
                            break;
                        }
                    default:
                        {
                            break;
                        }
                    }
            }
            Console.WriteLine(string.Join("", result));

        }

        /**
         * 用户输入一组数字, 按空格隔开, 对用户输入的数字按从小到大排序
         * 
         */
        public void TestSort()
        {
            Console.Write("请输入需要排序的数字(空格隔开):");
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                str = "";
            }

            string[] strings = str.Split(' ');
            int[] array = strings.Select(s => Convert.ToInt32(s)).ToArray<int>();

            Array.Sort(array);// 升序 (没有返回值, 直接修改数组)


            // 升序后再反转, 实现降序
            //Array.Sort(array);
            //Array.Reverse(array);

            // LINQ 降序
            //int[] ints = array.OrderByDescending(x => x).ToArray<int>();

            Console.WriteLine("原字符串: " + str);
            Console.WriteLine("排序过后: " + string.Join(" ", array));
        }

        public void TestSort2()
        {
            Console.Write("请输入需要排序的数字(空格隔开):");
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                str = "";
            }

            string[] strings = str.Split(' ');
            int[] array = strings.Select(s => Convert.ToInt32(s)).ToArray<int>();

            BubbleSort(array);
            Console.WriteLine("原字符串: " + str);
            Console.WriteLine("冒泡排序: " + string.Join(" ", array));
            Console.WriteLine("==============================================");


            array = strings.Select(s => Convert.ToInt32(s)).ToArray<int>();
            SwopSort(array);
            Console.WriteLine("原字符串: " + str);
            Console.WriteLine("交换排序: " + string.Join(" ", array));
        }

        /// <summary>
        /// 冒泡排序 升序
        /// </summary>
        /// <param name="array"></param>
        private void BubbleSort(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        array[j] = array[j] + array[j + 1];
                        array[j + 1] = array[j] - array[j + 1];
                        array[j] = array[j] - array[j + 1];
                    }
                }
            }
        }

        /// <summary>
        /// 交换排序 升序
        /// </summary>
        /// <param name="array"></param>
        private void SwopSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minValue = array[i];
                int minIndex = i;
                for (int j = 0 + i; j < array.Length; j++)
                {
                    if (array[j] < minValue)
                    {
                        minValue = array[j];
                        minIndex = j;
                    }
                }

                array[minIndex] = array[i];
                array[i] = minValue;
            }
        }

        /// <summary>
        /// 参数数组, 相当于形参并不是数组, 而是 int 类型的参数, 但个数不确定
        /// 参数数组, 只能是形参的最后一个
        /// </summary>
        /// <param name="array"></param>
        public void Operation(OperationType type, params int[] array)
        {
            int result = 0;
            string typeString = "";
            foreach(int item in array)
            {
                if(type == OperationType.加)
                {
                    result += item;
                    typeString = "加";
                }

                if(type == OperationType.减)
                {
                    result -= item;
                    typeString = "减";
                }

                if(type == OperationType.乘)
                {
                    typeString = "乘";
                    if (result == 0)
                    {
                        result = item;
                    }
                    else
                    {
                        result *= item;
                    }
                }

                if(type == OperationType.除)
                {
                    typeString = "除";
                    if (result == 0)
                    {
                        result = item;
                    }
                    else
                    {
                        result /= item;
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
            Console.WriteLine($"相{typeString}后的结果为: " + result);
        }

        public int MaxValue(params int[] array)
        {
            int max = int.MinValue;
            foreach(int item in array)
            {
                if(item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        /**
         * 方法的重载
         * 参数列表必须不同(参数个数不同 或 参数类型不同)
         * 方法返回值不相关
         */
        public double MaxValue(params double[] array)
        {
            double max = double.MinValue;
            foreach (double item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        /**
         * 递归
         */
        public int F(int n)
        {
            if(n == 0)
            {
                return 2;
            }
            if(n == 1)
            {
                return 3;
            }

            return F(n - 1) + F(n - 2);
        }

        /// <summary>
        /// 测试枚举
        /// </summary>
        public void TestEnum()
        {
            int number = (int)WeekTwo.Sum;
            Console.WriteLine("枚举类型强转int后: "+ number);// 枚举类型强转int后: 5
            Console.WriteLine("直接打印枚举类型: " + WeekTwo.Sum);// 直接打印枚举类型: Sum

        }
    }
}
