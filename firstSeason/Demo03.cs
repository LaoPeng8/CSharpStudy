using System;
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


    }
}
