using System;
using System.Collections.Generic;
using System.Text;

namespace fourthlySeason
{
    internal class Demo05
    {

        public delegate void MyDelegate();

        public void TestAsyncDelegate()
        {
            Console.WriteLine("进入TestAsyncDelegate()方法...");

            Thread.Sleep(3000);
            Console.WriteLine("执行TestAsyncDelegate()方法...");
            Thread.Sleep(3000);

            Console.WriteLine("结束TestAsyncDelegate()方法...");
        }

        /**
         * 测试异步委托
         */
        public void Test01()
        {
            /**
             * 这样调用 在执行委托时, 会阻塞当前线程, 打印结果如下
             * Demo05.Test01()开始执行...
             * 调用 测试异步委托...
             * 进入TestAsyncDelegate()方法...
             * 执行TestAsyncDelegate()方法...
             * 结束TestAsyncDelegate()方法...
             * Demo05.Test01()结束执行...
             */
            Console.WriteLine("Demo05.Test01()开始执行...");
            MyDelegate myDelegate = TestAsyncDelegate;

            Console.WriteLine("调用 测试异步委托...");
            myDelegate();

            Console.WriteLine("Demo05.Test01()结束执行...");
        }

        /**
         * 测试异步委托
         * 
         * 执行后抛出异常:
         *  System.PlatformNotSupportedException:“Operation is not supported on this platform.”
         *  
         * 原因:
         *  平台不支持‌: 在 .NET Core 2.0+ 及 .NET 5+ 中，BeginInvoke 和 EndInvoke 方法在某些平台上 (如 Linux 或 macOS)不被支持.
         *  这些方法依赖于特定的 Windows 平台特性,导致跨平台应用时抛出此异常.
         *  
         * 解释一下:
         *  起初版本为 .NET Framework x.x 不能跨平台, 只能在Windows上运行 (此时异步委托应该就是可以用的)
         *  后面版本为 .NET Core x.x 为跨平台, Windows, Linux, macOs (之后异步委托可能就不能用了, 因为Linux maxOS不支持)
         *  后面版本为 .NET x 统一 .NET Core / .NET Framework
         *  
         *  了解之后发现 现在都是用 async/await 来完成异步操作, 后续本课程结束后再去学习异步编程 https://www.bilibili.com/video/BV1Fw411F71A/
         */
        public void Test02()
        {
            Console.WriteLine("Demo05.Test02()开始执行...");
            MyDelegate myDelegate = TestAsyncDelegate;

            Console.WriteLine("调用 测试异步委托...");
            object result = null;
            myDelegate.BeginInvoke(o => { Console.WriteLine("这是异步委托的回调函数, 异步委托执行后会调用该回调函数"); }, result);

            Console.WriteLine("Demo05.Test02()结束执行...");
        }


    }
}
