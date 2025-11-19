using System;
using System.Collections.Generic;
using System.Text;

namespace fourthlySeason
{
    internal class Demo01
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public void Test01()
        {
            Console.WriteLine("命名空间, 相当于就是包名, 用来管理类的");
            Console.WriteLine("如果需要引用不同命名空间下的类, 需要引入命名空间 using 命名空间, 也可直接通过 命名空间名.类名 使用指定类");
            Console.WriteLine("命名空间可以嵌套, 即namespace 下继续 namespace, 引入嵌套命名空间时需要 using 命名空间.命名空间");
            Console.WriteLine("基础命名空间:");
            Console.WriteLine("System 处理内建数据, 数学计算, 随机数, 环境变量, 垃圾回收器, 常见的异常和特征");
            Console.WriteLine("System.Collections 包含了一些与集合相关的类型, 例如列表, 队列, 位数组, 哈希表和字典等");
            Console.WriteLine("System.Collections.Generic 定义泛型集合的接口和类, 泛型集合允许用户创建强类型集合, 它能提供更好的类型安全和性能");
            Console.WriteLine("System.IO 包含了一些数据流类型并提供了文件和目录同步异步读写");
            Console.WriteLine("System.IO.Comoression 提供基本的流压缩和解压缩服务的类");
            Console.WriteLine("System.IO.Ports 控制串行端口的类");
            Console.WriteLine("System.Text 包含了一些表示字符编码的类型并提供了字符串的操作和格式化");
            Console.WriteLine("System.Reflection 包含了一些提供加载类型, 方法和字段的托管视图以及动态创建和调用类型功能的类型");
            Console.WriteLine("System.Threading 提供启用多线程的类和接口");
            Console.WriteLine("System.Runtime.InteropServices 使得.NET类型可以和非托管代码交互");
            Console.WriteLine("");
            Console.WriteLine("图形命名空间:");
            Console.WriteLine("System.Drawing 这个主要的GDI+命名空间定义了许多类型, 实现基本的绘图类型(字体，钢笔, 基本画笔等)和无所不能的Graphics对象");
            Console.WriteLine("System.Drawing2D 这个命名空间提供高级的二维和矢量图像功能");
            Console.WriteLine("System.Drawing.Imaging 这个命名空间定义了一些类型实现图形图像的操作");
            Console.WriteLine("System.Drawing.Text 这个命名空间提供了操作字体集合的功能");
            Console.WriteLine("System.Drawing.Printing 这个命名空间定义了一些类型实现在打印纸上绘制图像, 和打印机交互以及格式化某个打印任务的总体外观等功能");
            Console.WriteLine("");
            Console.WriteLine("数据命名空间");
            Console.WriteLine("System.Data 包含了数据访问使用的一些主要类型");
            Console.WriteLine("System.Data.Common 包含了各种数据库访问共享的一些类型");
            Console.WriteLine("System.XML 包含了根据标准来支持XML处理的类");
            Console.WriteLine("System.Data.OleDb 包含了一些操作OLEDB数据源的类型");
            Console.WriteLine("System.Data.Sql 能使你枚举安装在当前本地网络的SQLServer实例");
            Console.WriteLine("System.Data.SqlClient 包含了一些操作MSSQLServer数据库的类型, 提供了和System.Data.OleDb相似的功能, 但是针对SQL做了优化");
            Console.WriteLine("System.Data.SqlTypes 包含了一些表示SQL数据类型的类");
            Console.WriteLine("System.Data.Odbc 包含了操作Odbc数据源的类型");
            Console.WriteLine("System.Data.OracleClient 包含了操作Odbc数据量的类型");
            Console.WriteLine("System.Transactions 这个命名空间提供了编写事务性应用程序和资源管理器的一些类");
            Console.WriteLine("");
            Console.WriteLine("语言集成查询");
            Console.WriteLine("System.Linq 支持使用语言集成查询的查询");
            Console.WriteLine("System.Xml.Linq 包含LINQtoXML的类");
            Console.WriteLine("System.Data.Linq 包含支持与LINQtoSQL应用程序中的关系数据库进行交互的类");
            Console.WriteLine("");
            Console.WriteLine("Windows窗体应用程序");
            Console.WriteLine("System.Windows.Froms 创建WinFrom应用程序");
            Console.WriteLine("System.Windows 提供支持WPF属性和事件逻辑的一些基元素类以及其他类型");
            Console.WriteLine("System.Windows.Controlls 创建WPF控件元素, 使用户与应用程序进行交互");
            Console.WriteLine("System.Windows.Shapes 提供对WPFXAML或代码中使用的形状库的访问");
            Console.WriteLine("");
            Console.WriteLine("WEB命名控件");
            Console.WriteLine("System.Web 这个命名空间包含启用浏览器/服务器通信的类和接口. 这些命名空间类用于管理到客户端的HTTP输出和读取HTTP请求. 附加的类则提供了一些功能, 用于服务器段的应用程序以及进程, Cookie管理, 文件传输, 异常信息和输出缓存的控制");
            Console.WriteLine("System.Web.UI 这个命名空间包含Web窗体的类, 包括Page类和用于创建Web用户界面的其他标准类");
            Console.WriteLine("System.Web.UI.HtmlControls 这个命名空间包含用于HTML特定控件的类, 这些控件可以添加到Web窗体中以创建Web用户界面");
            Console.WriteLine("System.Web.UI.WebControls 包含创建ASP.NET服务器控件的类, 当添加到窗体时, 这些控件将呈现浏览器特定的HTML和脚本, 用于创建和设备无关的Web用户界面");
            Console.WriteLine("System.Web.Mobile 包含生成ASP.NET移动应用程序所需要的核心功能, 包括身份验证的错误处理");
            Console.WriteLine("System.Web.UI.MobileControls 包括一组ASP.NET服务器控件, 这些控件可以针对不同的移动设备呈现应用程序");
            Console.WriteLine("System.Web.Services 包含能使你使用和生成XMLWebService的类, 这些服务是驻留在服务器中的可编程实体, 并通过标准Internet协议公开");
            Console.WriteLine("");
            Console.WriteLine("框架服务命名空间");
            Console.WriteLine("System.Diagnostics 这个命名控件所提供的类允许你启动系统进程, 读取和写入事件日志以及使用性能计数器监视系统性能");
            Console.WriteLine("System.DirectoryServices 这个命名控件所提供的类可便于从托管代码中访问 ActiveDirectory. 此命名空间中的类可以与任何ActiveDirectory服务提供程序一起使用");
            Console.WriteLine("System.Management 这个命名空间所提供的类用于管理一些信息和事件, 它们关系到系统, 设备和WMI基础结构所使用的应用程序");
            Console.WriteLine("System.Messaging 这个命名空间提供的类用于连接到网络上的消息队列, 向队列发送消息, 从队列接受或查看消息");
            Console.WriteLine("System.ServiceProcess 这个命名空间提供的类用于安装和运行服务, 服务是长期运行的可执行文件, 它们不通过用户界面来运行.");
            Console.WriteLine("System.Timers 这个命名空间提供基于服务器的计时器组件, 用以按指定的间隔引发事件.");
            Console.WriteLine("");
            Console.WriteLine("安全性命名空间");
            Console.WriteLine("System.Security 这个命名空间提供公共语言运行库安全性系统的基础结构.");
            Console.WriteLine("System.Net.Security 这个命名空间提供用于主机间安全通信的网络流.");
            Console.WriteLine("System.Web.Security 这个命名空间包含的类用于在Web应用程序中实现ASP.NET安全性.");
            Console.WriteLine("");
            Console.WriteLine("网络命名空间");
            Console.WriteLine("System.Net 包含的类可为当前网络上的多种协议提供简单的编程接口.");
            Console.WriteLine("System.Net.Cache 这个命名空间定义了一些类和枚举,用于为使用WebRequest和HttpWebRequest类获取的资源定义缓存策略.");
            Console.WriteLine("System.Net.Configuration 这个命名空间包含了以编程方式访问和更新System.Net命名空间的配置设置的类.");
            Console.WriteLine("System.Net.Mime 这个命名空间包含了用于将电子邮件发送到SMTP服务器进行传送的类.");
            Console.WriteLine("System.Net.Networkinformation 这个命名空间提供对网络流量数据, 网络地址信息和本地计算机的地址更改通知的访问, 还包含实现Ping实用工具的类. 你可以使用Ping和相关的类来检查是否可通过网络访问某台计算机.");
            Console.WriteLine("System.Net.Sockets 这个命名空间为严格控制网络访问的开发人员提供Windows套接字接口的托管实现.");
            Console.WriteLine("");
            Console.WriteLine("配置命名空间");
            Console.WriteLine("System.Configuration 这个命名空间包含用于以编程方式访问.NetFramework配置设置并处理配置文件中错误的类.");
            Console.WriteLine("System.Configuration.Assemblies 这个命名空间包含用于配置程序集的类.");
            Console.WriteLine("System.Configuration.Provider 这个命名空间包含由服务器和客户端应用程序共享, 以支持可插接式模型轻松添加或移除功能的基类.");
            Console.WriteLine("");
            Console.WriteLine("本地化命名空间");
            Console.WriteLine("System.Globalization 包含的类定义与区域性相关的信息,其中包括语言,国家/地区, 所使用的日历, 日期格式的模式, 货币与数字以及字符串的排序顺序.");
            Console.WriteLine("System.Resources 这个命名空间提供一些类和接口, 它们使开发人员得以创建, 存储并管理应用程序中使用的各种区域性特定资源.");
            Console.WriteLine("System.Resources.Tools 这个命名空间包含StronglyTypedResourceBuilder类, 该类提供对强类型资源的支持. 这个编译时功能通过创建包含一组静态只读属性的类封装对资源的访问, 从而使得使用资源变得更加容易.");
            Console.WriteLine("");
            Console.WriteLine("其他命名空间");
            Console.WriteLine("System.ServiceModel 包含生成WCF服务和客户端应用程序所需要的类型.");
            Console.WriteLine("System.Workflow 开发工作流应用程序.");
            Console.WriteLine("System.Media 包含用于播放声音文件和访问系统提供的声音的类.");
        }

        /// <summary>
        /// 字符串
        /// </summary>
        public void Test02()
        {
            /**
             * CompareTo 用于比较调用者 与 参数是否一致, 对于string而言 如果相等返回 0, 长度小于则是-1, 长度大于则是 1
             * 
             * int也是重写了CompareTo方法的, 只能 int 与 int比较, 与其他不兼容类型则会抛出异常
             */
            string str = "https://www.baidu.com";
            Console.WriteLine(str.CompareTo("www.baidu.com"));// -1
            Console.WriteLine(str.CompareTo("这是一个网址 https://www.baidu.com"));// 1
            Console.WriteLine(str.CompareTo("https://www.baidu.com"));// 0

            //int i = 0;
            //Console.WriteLine(i.CompareTo("https://www.baidu.com"));// System.ArgumentException:“Object must be of type Int32.”
            Console.WriteLine("");


            /**
             * 替换
             */
            Console.WriteLine(str.Replace('.', '.'));
            Console.WriteLine(str.Replace(".", "-"));
            Console.WriteLine("");


            /**
             * 分割数组
             */
            string[] strings = str.Split('.');
            for(int i = 0; i < strings.Length; i++)
            {
                Console.Write(strings[i] + " -> ");
            }
            Console.WriteLine("");


            /**
             * 切割字符串
             */
            Console.WriteLine(str.Substring(1));// ttps://www.baidu.com  //从 1往后全部截取
            Console.WriteLine(str.Substring(1, 10));// ttps://www  //从 1往后截取10个字符
            Console.WriteLine("");


            /**
             * 大小写转换
             */
            Console.WriteLine(str.ToUpper());// HTTPS://WWW.BAIDU.COM
            Console.WriteLine(str.ToLower());// https://www.baidu.com
            Console.WriteLine("");


            /**
             * 去除前后空格
             */
            Console.WriteLine(str.Trim());
            Console.WriteLine("");


            /**
             * 合并字符串
             */
            Console.WriteLine(string.Concat(str, "A", "B", "C"));
            Console.WriteLine("");


            /**
             * 拷贝字符串至字符数组
             */
            char[] chars = new char[10];
            str.CopyTo(12, chars, 1, 5);// 拷贝str指定部分至 chars 中, 拷贝str从下标12开始, 拷贝5个元素, 将值拷贝至chars中,从下标1开始存放
            Console.WriteLine(string.Join(", ", chars));// , b, a, i, d, u, , , , (将数组以某参数 ", " 为分割符, 拼接起来)
            Console.WriteLine("");


            /**
             * Format 格式化输出字符串
             */
            int money = 12000;
            Console.WriteLine(string.Format("{0}", money));
            Console.WriteLine(string.Format("{0:C}", money));// 以货币形式打印
            Console.WriteLine(string.Format("{0:F2}", 3.1415926));// 四舍五入保留2位小数打印
            Console.WriteLine(string.Format("{0:P1}", 0.167));// 以百分比形式打印
            Console.WriteLine(string.Format("{0}", DateTime.Now));
            Console.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));// 以格式化日期打印
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("");


            /**
             * IndexOf 获取指定字符串在字符串第一次出现的下标
             * IndexOfAny 获取指定字符数组中的元素 第一次出现的下标
             */
            Console.WriteLine("www.baidu.com".IndexOf("w"));// 0
            Console.WriteLine("www.baidu.com".IndexOfAny(new char[] {'A', 'c'}));// 10 (先找A的下标, 找不到则会找c, 找不到则继续找直到整个字符数组找不到)
            Console.WriteLine("");


            /**
             * Insert 插入指定字符串至指定下标处
             */
            Console.WriteLine("www..com".Insert(4, "baidu"));// www.baidu.com
            Console.WriteLine("");


            /**
             * Join 连接数组为字符串
             */
            Console.WriteLine(string.Join(", ", new char[] { 'a', 'b', 'c', 'd', 'e' }));
            Console.WriteLine("");
        }

        /// <summary>
        /// StringBuilder
        /// </summary>
        public void Test03()
        {
            StringBuilder sb = new StringBuilder("https://www.baidu.com");
            Console.WriteLine(sb.ToString());

            sb.Append(", https://www.bilibili.com/");
            sb.Append(", 1234567890");
            Console.WriteLine(sb.ToString());

            sb.Insert(53, "--AA--");
            Console.WriteLine(sb.ToString());

            sb.Remove(53, 3);
            Console.WriteLine(sb.ToString());

            sb.Replace("tt", "TT");
            Console.WriteLine(sb.ToString());

        }



    }
}
