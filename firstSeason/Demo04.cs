using System;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    class Demo04
    {
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
    }
}
