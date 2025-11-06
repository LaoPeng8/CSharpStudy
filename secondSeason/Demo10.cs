using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{
    public class Demo10
    {
        public static void Test01()
        {
            Random random = new Random();
            bool flag = true;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                while(flag)
                {
                    Console.WriteLine("这里是Lambad内部, 线程: " + Thread.CurrentThread.Name);
                    int v = random.Next(1, 100);
                    if(v >= 50)
                    {
                        Thread.Sleep(200);
                    }
                }
            }));
            thread.Name = "调用Lambad的线程";
            thread.Start();// 启动线程, 等待CPU调度


            while(true)
            {
                Console.WriteLine("这里是Test01, 线程: " + Thread.CurrentThread.Name);
                int v = random.Next(1, 100);
                if (v >= 50)
                {
                    Thread.Sleep(200);
                }

                if(v == 99)
                {
                    Console.WriteLine("将两个线程都终止");
                    flag = false;// 通过标志位结束 thread 线程
                    Thread.CurrentThread.Abort();// 通过 Abort()方法 强制终止 当前线程
                }
            }


        }
    }
}
