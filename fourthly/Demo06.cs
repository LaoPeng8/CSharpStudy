using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace fourthlySeason
{
    public struct Data
    {
        public long Id;
        public string Name;
        public string Description;

        public Data()
        {
            Id = 0;
            Name = "";
            Description = "";
        }
        public Data(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

    public enum DownloadStatus
    {
        未下载 = 0,
        下载中 = 1,
        已下载 = 2,
        下载fail = 3
    }

    public class DownloadTool
    {
        public DownloadTool()
        {
        }
        public DownloadTool(string url, string filePath, string fileName, string message)
        {
            Url = url;
            FilePath = filePath;
            FileName = fileName;
            Message = message;
        }

        public string Url { get; private set; }
        public string FilePath { get; private set; } = "C:/Users/PengJiaJun/Desktop";
        public string FileName { get; private set; }
        public string Message { get; private set; }
        public DownloadStatus IsSuccess { get; private set; } = DownloadStatus.未下载;

        public void Download()
        {
            Console.WriteLine("正在从" + Url + " 下载文件...");
            Thread.Sleep(2000);
            Console.WriteLine("正在从" + Url + " 下载文件...");
            Thread.Sleep(2000);
            Console.WriteLine("正在从" + Url + " 下载文件...");
            IsSuccess = DownloadStatus.已下载;
        }
    }

    public class CountTest
    {
        public int count = 0;
        public int aCount = 0;
        public int bCount = 0;
        public bool IsBreak = false;

        public void ATest()
        {
            while (true)
            {
                count++;
                aCount++;
                Console.Write("A");
                if (count > 1000000)
                {
                    break;
                }
                if (IsBreak)
                {
                    break;
                }
            }
        }

        public void BTest()
        {
            while (true)
            {
                count++;
                bCount++;
                Console.Write("B");
                if (count > 1000000)
                {
                    break;
                }
                if (IsBreak)
                {
                    break;
                }
            }
        }

        public override string ToString()
        {
            return $"{{ count = {count}, aCount = {aCount}, bCount = {bCount} }}";
        }
    }

    internal class Demo06
    {
        public void Test01()
        {
            Console.WriteLine("Test01 Start...");
            //Thread thread = new Thread(new ThreadStart(() => { Console.WriteLine("Hello"); }));
            //Thread thread = new Thread(() => { Console.WriteLine("Hello"); });
            //Thread thread = new Thread(new ThreadStart(PrintHello));
            Thread thread = new Thread(PrintHello);
            thread.Start();
            Console.WriteLine("Test01 End..." + Thread.CurrentThread.ManagedThreadId);
        }
        private void PrintHello()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hello");
            Thread.Sleep(5000);
            Console.WriteLine("Hello: " + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// Thread传递参数
        /// 
        /// Thread在传入执行的方法时, 是可以传入 无参无返回值的方法的 构造函数中接收一个 这个类型的方法 public delegate void ThreadStart();
        ///     也可以传入 一个参数无返回值的方法的 构造函数中接收 public delegate void ParameterizedThreadStart(object? obj);
        ///     在调用 .Start 方法时候将参数传入
        ///     
        /// 传入传入时只能传入一个 object 类型的数据, 如果要传入多个数据如何?
        ///     可以使用结构体, 或者类应该也是可以的
        /// </summary>
        public void Test02()
        {
            Thread thread = new Thread(Download);
            thread.Start("https://www.baidu.com/Test/a.mp4");
            Console.WriteLine("Demo06.Test02()...");

            Thread thread2 = new Thread(Download2);
            thread2.Start(new Data(1, "张三", "来自高三303"));
        }

        private void Download(Object url)
        {
            if(url == null)
            {
                return;
            }

            string urlString = url as string;
            Console.WriteLine("正在从" + url + " 下载文件...");
            Thread.Sleep(2000);
            Console.WriteLine("正在从" + url + " 下载文件...");
            Thread.Sleep(2000);
            Console.WriteLine("下载完成...");
        }

        private void Download2(Object obj)
        {
            if (obj == null)
            {
                return;
            }

            Data data = (Data)obj;
            Console.WriteLine($"正在下载用户信息: {{ Id:{data.Id}, Name:{data.Name}, Desc:{data.Description} }}");
        }

        /// <summary>
        /// Thread传递参数
        ///     因为传入的是一个实例方法, 而实例方法是可以访问类中的资源的, 所以这个方法也是可以访问到这个类中的各个变量等, 也相当是传递参数了
        /// </summary>
        public void Test03()
        {
            Console.WriteLine("Demo06.Test03()...");
            var downloadTool = new DownloadTool("https://www.baidu.com", "C:/Users/Desktop", "Java从入门到精通.mp4", "这是备注");
            Thread thread = new Thread(downloadTool.Download);
            thread.Start();
            while(true)
            {
                if(downloadTool.IsSuccess == DownloadStatus.已下载)
                {
                    string filePath = downloadTool.FilePath[downloadTool.FilePath.Length - 1] == '/' ? downloadTool.FilePath : downloadTool.FilePath + "/";
                    Console.WriteLine($"下载成功, 以将 {downloadTool.Url} 下载至 {filePath}{downloadTool.FileName}");
                    break;
                }
                if (downloadTool.IsSuccess == DownloadStatus.下载fail)
                {
                    Console.WriteLine($"下载失败, 可能的原因为{downloadTool.Message}");
                    break;
                }
                Thread.Sleep(1000);
            }
            Console.WriteLine("Demo06.Test03()...end...");
        }

        /// <summary>
        /// 前台线程 和 后台线程
        ///     只要有一个前台线程, 应用程序的进程就在运行
        ///     如果多个前台线程在运行, 但是Main方法结束了, 应用程序的进程仍然是运行的. 知道所有前台线程完成其任务为止.
        ///     默认情况下, 用Thread类创建的线程都是前台线程. 线程池中的线程总是后台线程.
        ///     在用Thread类创建线程的时候, 可以设置IsBackground属性, 表示它是一个前台线程/后台线程.
        /// 
        /// 当 IsBackground = false; 时说明这个线程 是前台线程, 打印时发现, 即使Main线程接收了, 依旧是执行完了子线程
        ///     Test04.Main线程 start...
        ///     Test04.Main线程 end...
        ///     Test04.前台线程 start...
        ///     Test04.前台线程 ing...
        ///     Test04.前台线程 ing...
        ///     Test04.前台线程 end...
        /// 
        /// 当 IsBackground = true; 时说明这个线程 是后台线程, 打印时发现, 还没有打印 Test.04.前台线程 end... 时程序就结束了
        /// (为什么打印了 Test04.Main线程 end... 后依旧打印了部分 子线程的内容, 因为Main线程结束时会扫描子线程然后再关闭, 有一定延时)
        /// Test04.Main线程 start...
        /// Test04.Main线程 end...
        /// Test04.前台线程 start...
        /// Test04.前台线程 ing...
        /// 
        /// Thread thread = new Thread(){ IsBackground = true }; 通过这种 {} 赋值的方式, 并不是构造函数,
        /// 此处实际是 new了一个空构造, 然后 thead.IsBackgroun = true; 所以需要 IsBackgroun属性的 set 方法存在且不是private能够访问
        /// </summary>
        public void Test04()
        {
            Console.WriteLine("Test04.Main线程 start...");
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Test04.前台线程 start...");
                Console.WriteLine("Test04.前台线程 ing...");
                Thread.Sleep(2000);
                Console.WriteLine("Test04.前台线程 ing...");
                Thread.Sleep(2000);
                Console.WriteLine("Test04.前台线程 end...");
            }){ IsBackground = true };
            thread.Start();

            Console.WriteLine("Test04.Main线程 end...");
        }


        /// <summary>
        /// 线程的优先级
        ///     线程的执行都是由CPU调度的, 可以通过 枚举ThreadPriority 设置优先级, 优先级高就更有可能获得CPU调度, 但不是绝对的
        /// 
        /// 线程的状态
        ///     1.获取线程的状态(Running还是Unstarted,...), 当我们通过调用Thread对象的Start方法后其实不是直接开始执行线程, 而是将该线程进入等待CPU调度的状态,
        ///       调用Start方法后不是进入Running状态, 而是进入Unstarted状态, 只有操作系统的线程调度器选择了要运行的线程, 这个线程的状态才会修改为Running状态.
        ///       我们使用Thread.Sleep()方法可以让当前线程休眠进入WaitSleepJoin状态.
        ///     2.使用Thread对象的Abort()方法可以停止线程, 调用这个方法, 会在终止的线程中抛出一个ThreadAbortException类型的异常, 我们可以try catch这个异常,
        ///       然后在线程结束前做一些清理的工作.
        ///     3.如果需要等待线程的结束, 可以调用Thread对象的Join方法, 表示把Thread加入进来, 停止当前线程, 并把它设置为WaitSleepJoin状态, 直到加入的线程完成为止.
        /// 
        /// 
        /// </summary>
        public void Test05()
        {
            CountTest countTest = new CountTest();
            Thread aThread = new Thread(countTest.ATest);
            Thread bThread = new Thread(countTest.BTest);

            //aThread.Priority = ThreadPriority.BelowNormal;
            //bThread.Priority = ThreadPriority.Highest;
            // 注释时都差不多 { count = 336002, aCount = 169171, bCount = 166832 } 

            aThread.Priority = ThreadPriority.BelowNormal;
            bThread.Priority = ThreadPriority.Highest;
            // { count = 316710, aCount = 24853, bCount = 291859 }

            aThread.Start();
            bThread.Start();

            Thread.Sleep(1000 * 30);
            countTest.IsBreak = true;
            Console.WriteLine(countTest);
        }
    }
}
