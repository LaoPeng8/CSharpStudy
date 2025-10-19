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
    }
}
