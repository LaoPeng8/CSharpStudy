using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ESeason
{
    /// <summary>
    /// C# 多线程入门概念及技巧
    /// </summary>
    internal class Demo01
    {

        /// <summary>
        /// 同步机制: 保证线程安全(互斥 就是加锁, 改并行为串行)
        /// </summary>
        public void Test01_1()
        {
            const int total = 100_000;
            int count = 0;
            object _lock = new object();

            var thread1 = new Thread(ThreadMethod);
            var thread2 = new Thread(ThreadMethod);


            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Count: {count}");

            void ThreadMethod()
            {
                for (int i = 0; i < total; i++)
                {
                    lock (_lock)
                    {
                        count++;
                    }
                }
            }
        }


        /// <summary>
        /// 原子操作: 保证线程安全 (底层提供的原子类实现的 ++ --)
        /// </summary>
        public void Test01_2()
        {
            const int total = 100_000;
            int count = 0;

            var thread1 = new Thread(ThreadMethod);
            var thread2 = new Thread(ThreadMethod);


            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Count: {count}");

            void ThreadMethod()
            {
                for (int i = 0; i < total; i++)
                {
                    Interlocked.Increment(ref count);
                }
            }
        }


        /// <summary>
        /// 常规方法, 串行
        /// </summary>
        public void Test02_1()
        {
            var inputs = Enumerable.Range(1, 20).ToArray();
            var outputs = new int[inputs.Length];

            var sw = Stopwatch.StartNew();

            for(int i = 0; i < inputs.Length; i++)
            {
                outputs[i] = HeavyJob(inputs[i]);
            }

            Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds}ms");// Elapsed time: 2020ms
            Console.WriteLine(string.Join(", ", outputs));

            /**
             * 耗时操作
             */
            T HeavyJob<T>(T i)
            {
                Thread.Sleep(100);
                return i;
            }
        }


        /// <summary>
        /// 并行, Java里面也有,叫并行流/串行流
        /// </summary>
        public void Test02_2()
        {
            var inputs = Enumerable.Range(1, 20).ToArray();
            var outputs = new int[inputs.Length];

            var sw = Stopwatch.StartNew();

            //Parallel.For(0, inputs.Length, i => outputs[i] = HeavyJob(inputs[i]));//
            outputs = inputs.AsParallel().Select(x => HeavyJob(x)).ToArray();//

            Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds}ms");// Elapsed time: 337ms
            Console.WriteLine(string.Join(", ", outputs));

            /**
             * 耗时操作
             */
            T HeavyJob<T>(T i)
            {
                Thread.Sleep(100);
                return i;
            }
        }


        /// <summary>
        /// 线程的创建
        /// 
        /// 后台线程会在主线程结束后, 立即结束
        /// 前台线程会在主线程结束后(阻塞主线程), 继续运行
        /// </summary>
        public void Test03_1()
        {
            var thread = new Thread((paramObj) =>
            {
                Console.WriteLine(paramObj);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Thread is still running...");
                }

                Console.WriteLine("Thread is finished!");
            }){ IsBackground = true, Priority = ThreadPriority.Normal };// 是否后台线程, 线程优先级

            thread.Start(123);// 传递参数
            Console.WriteLine("In main thread, waiting for thread to finish...");// 先于 Thread is finished! 输出
            thread.Join();// 阻塞的等待, thread线程结束
            Console.WriteLine("Done.");
        }


        /// <summary>
        /// 使用Abort方法来强制终止线程可能导致一些严重的问题, 包括资源泄露和不可预测的行为
        /// 较新版本的 .NET 中如果使用这个方法, 会报 System.PlatformNotSupportedException
        /// </summary>
        public void Test03_2()
        {
            var thread = new Thread((paramObj) =>
            {
                Console.WriteLine(paramObj);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Thread is still running...");
                }

                Console.WriteLine("Thread is finished!");
            })
            { IsBackground = true, Priority = ThreadPriority.Normal };

            thread.Start(123);
            Console.WriteLine("In main thread, waiting for thread to finish...");
            thread.Abort();// System.PlatformNotSupportedException:“Thread abort is not supported on this platform.”
            Console.WriteLine("Done.");
        }


        /// <summary>
        /// 使用 Interrupt 退出线程
        /// </summary>
        public void Test03_3()
        {
            var thread = new Thread((paramObj) =>
            {
                Console.WriteLine(paramObj);
                try
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine("Thread is still running...");
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    // 甚至什么都不需要做, 调用 Interrupt() 后会抛出该异常, 捕获后就退出了
                    Console.WriteLine("captured ThreadInterruptedException");
                }
                finally
                {
                    Console.WriteLine("Thread is finished!");
                }

            })
            { IsBackground = true, Priority = ThreadPriority.Normal };

            thread.Start(123);
            Console.WriteLine("In main thread, waiting for thread to finish...");
            Thread.Sleep(500);
            thread.Interrupt();
            thread.Join();
            Console.WriteLine("Done.");
        }


        /// <summary>
        /// 使用 Interrupt 退出线程
        ///     如果线程中包含一个while(true)循环, 那么需要保证包含等待方法, 如IO操作, Thread.Sleep等
        ///     否则 只有一个 while(true) 可以立即为它太忙了, 根本执行不到 Interrupt()的抛出异常
        /// </summary>
        public void Test03_4()
        {
            var thread = new Thread((paramObj) =>
            {
                Console.WriteLine(paramObj);
                try
                {
                    while(true)
                    {
                        //Console.WriteLine("index"); 测试打印依旧停不下来, 看来是需要一些能够阻塞的方法才能停下
                        //Thread.Sleep(0);// 可以停下
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    // 甚至什么都不需要做, 调用 Interrupt() 后会抛出该异常, 捕获后就退出了
                    Console.WriteLine("captured ThreadInterruptedException");
                }
                finally
                {
                    Console.WriteLine("Thread is finished!");
                }

            })
            { IsBackground = true, Priority = ThreadPriority.Normal };

            thread.Start(123);
            Console.WriteLine("In main thread, waiting for thread to finish...");
            Thread.Sleep(500);
            thread.Interrupt();
            thread.Join();
            Console.WriteLine("Done.");
        }
    }
}
