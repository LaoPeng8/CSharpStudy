using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    class Demo03
    {
        private bool IsYouth(int age)
        {
            return age >= 18 && age <= 60;
        }

        public void ShowYouth()
        {
            Console.Write("请输入年龄:");
            int age = Convert.ToInt16(Console.ReadLine());

            if (IsYouth(age))
            {
                Console.WriteLine("是的, 是青年");
            }
            else
            {
                Console.WriteLine("NONONO, 这不是青年");
            }
        }

        /// <summary>
        /// 注意, C#的 switch 不允许case穿透(case省略 break 时, 会继续执行后续case), 每个case必须 break 或 return, 否则编译报错
        /// </summary>
        public void buyGoods()
        {
            Console.Write("请输入数字(1~5):");
            int type = Convert.ToInt16(Console.ReadLine());

            switch (type)
            {
                case 1:
                    {
                        Console.WriteLine("可口可乐");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("百事可乐");
                        break;
                    }
                case 3:
                    Console.WriteLine("雪碧");// 好像 case 内不用加 {}
                    Console.WriteLine("+");
                    Console.WriteLine("雷碧");
                    break;
                case 4:
                    {
                        Console.WriteLine("果粒橙");
                        break;
                    }
                 case 5:
                    {
                        Console.WriteLine("鲜橙多");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("卖完了");
                        break;
                    }
            }
        }



        public void buyGoods2()
        {
            Console.Write("请输入数字(1~5):");
            int type = Convert.ToInt16(Console.ReadLine());

            switch (type)
            {
                // 这表示 当 type = 1 或 2 时, 都会打印 "百事可乐"
                case 1:
                case 2:
                    {
                        Console.WriteLine("可口可乐");
                        break;
                    }
                case 3:
                    Console.WriteLine("雪碧");
                    break;
                case 4:
                case 5:
                    {
                        Console.WriteLine("鲜橙多");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("卖完了");
                        break;
                    }
            }
        }

        public void WriteNumber()
        {
            Console.Write("请输入数字:");
            int number = Convert.ToInt16(Console.ReadLine());

            if (number <= 1) {
                number = 1;
            }

            int index = 1;
            while (index <= number)
            {
                Console.WriteLine($@"Console.WriteLine(""{index++}"")");
                Thread.Sleep(100);
            }
        }

        public void WriteEvenNumber()
        {
            Console.Write("请输入数字:");
            int number = Convert.ToInt16(Console.ReadLine());

            if (number <= 2)
            {
                number = 2;
            }

            int index = 1;
            List<int> list = new List<int>();
            while (index++ <= number)
            {
                if(index % 2 == 0)
                {
                    list.Add(index);
                }
            }

            Console.WriteLine($"0 ~ {number} 之间的偶数有: [" + string.Join(", ", list) + "]");
        }

        /**
         * 对于一个 大于1 的自然数n, 如果是奇数则 3n + 1, 如果是偶数 则变成n的一半, n最后会变成1, 记录其过程
         */
        public void WriteThreeNProblem()
        {
            Console.Write("请输入数字:");
            int number = Convert.ToInt16(Console.ReadLine());

            if (number <= 1)
            {
                number = 1;
            }

            List<int> list = new List<int>();
            list.Add(number);

            while(number != 1)
            {
                if(number % 2 == 0)
                {
                    number = (number * 3) + 1;
                }else
                {
                    number /= 2;
                }

                list.Add(number);
            }

            Console.WriteLine("[" + string.Join(" -> ", list) + "]");
        }


        /**
         * 一个球, 从某一高度落下来, 每次落地后反弹原来高度的一半, 求第十次反弹多高? 共经过了多少米?
         */
        public void WriteBounce()
        {
            Console.Write("请输入球的高度:");
            int number = Convert.ToInt16(Console.ReadLine());
            double height = number;

            int count = 0;
            List<double> heightList = new List<double>();
            while (height > 0)
            {
                heightList.Add(height);// 记录高度
                height = height / 2;// 反弹后的高度

                if(count++ > 100)
                {
                    break;
                }
            }


            Console.WriteLine("球的高度: [" + string.Join(" -> ", heightList.Take(10)) + "]");

            if(heightList.Count < 10)
            {
                Console.WriteLine("第十次反弹的高度: 没有反弹10次");
                return;
            }

            double height10 = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    height10 = heightList[0];// 第一次下降
                }
                else
                {
                    height10 = height10 + (heightList[i] * 2);// 完整的一次弹起再下降的高度(多计算了最后一次弹起的高度) (实际上, 下降弹起是一次)
                }
            }
            height10 -= heightList[9];// 减去最后一次弹起的高度


            Console.WriteLine("第十次反弹后的高度: " + heightList[10]);// 注意第一次根本就没有反弹
            Console.WriteLine("第十次反弹经过的米数: " + height10);
        }


        public void WriteGraph()
        {
            Console.Write("请输入N:");
            int number = Convert.ToInt16(Console.Read());
            number = number - '0';
            Console.WriteLine($"=============={number}==============");

            for(int i = 0; i < number; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }

            Console.WriteLine("\n=====================================================\n");

            for (int i = number-1; i >= 0; i--)
            {
                for (int j = i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }

            Console.WriteLine("\n=====================================================\n");

            for(int i = 0; i < number; i++)
            {
                for(int z = 0; z < i; z++)
                {
                    Console.Write(" ");
                }
                for(int j = 0; j < number; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=====================================================\n");

            for(int i = 0; i < number; i++)
            {
                for(int j = number - i - 1; j > 0; j--)
                {
                    Console.Write(" "); 
                }
                for(int z = 0; z < i + 1; z++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=====================================================\n");

            for(int i = 0; i < number; i++)
            {
                for(int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for(int z = 0; z < i + i + 1; z++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=====================================================\n");

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int z = 0; z < i + i + 1; z++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = number-1-1; i >= 0; i--)
            {
                for (int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int z = 0; z < i + i + 1; z++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < number - i - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=====================================================\n");

            for(int i = 1; i <= 9; i++)
            {
                for(int j=1; j <= i; j++)
                {
                    Console.Write($"{j} * {i} = {(i * j).ToString("D2 ")}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=====================================================\n");
        }


    }
}
