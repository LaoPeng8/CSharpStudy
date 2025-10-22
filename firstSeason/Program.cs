using System;
using System.Collections.Generic;
using System.Text;

namespace firstSeason
{
    /**
     * 一个项目中貌似只能直接运行一个文件...
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Demo01 demo01 = new Demo01();
            //demo01.Show();

            Demo02 demo02 = new Demo02();
            //demo02.Show();
            //demo02.Sum();
            //demo02.Avg();
            //demo02.DivideMoney();
            //demo02.Swap();
            //demo02.Print();
            //demo02.SplitInt();

            Demo03 demo03 = new Demo03();
            //demo03.ShowYouth();
            //demo03.buyGoods();
            //demo03.buyGoods2();
            //demo03.WriteNumber();
            //demo03.WriteEvenNumber();
            //demo03.WriteThreeNProblem();
            //demo03.WriteBounce();
            //demo03.WriteGraph();

            Demo04 demo04 = new Demo04();
            //demo04.testArray();
            //demo04.testString();
            //demo04.DrinkCoke();
            //demo04.CharEncode();
            //demo04.TestSort();
            //demo04.TestSort2();
            //demo04.Operation(OperationType.加, 10, 20, 30, 40, 50);
            //demo04.TestEnum();

            Demo05 demo05 = new Demo05();
            demo05.TestStruct();
        }
    }
}
