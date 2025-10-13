using System;// 引入命名空间, 类似包名

namespace firstSeason// 命名空间, 默认是项目名称, 应该也是可以随意修改
{
    // 注释

    /**
     * 注
     * 
     * 释
     */

    /// <summary>
    /// 第一个 C# 程序, 主要是熟悉了下 VisualStudio 的界面
    /// </summary>
    /// <remarks>
    ///     <author>PengJiaJun</author>
    ///     <date>2025-10-14 00:02</date>
    /// </remarks>
    class Demo01
    {
        static void Main(string[] args)
        {
            //Ctrl + k + c 了解即可, 正常的 Ctrl + / , Ctrl + Shift + / 也可以用
            Console.WriteLine("HelloWord!");
            Console.WriteLine("C#学习第一天");
            Console.WriteLine("Visual Studio 快捷键和IDEA还是差很多");
            Console.WriteLine("为什么TAB后这个方法只出来半个括号( , 为什么 Main 后没有出来提示直接生成Main方法");
            Console.WriteLine("namespace 是项目名称吗, 为什么文件初始化出来后只有一个 Console.WriteLine(\"HelloWorld!\")");
            Console.WriteLine("吐槽 Visual Studio 各类选项卡, 代码提示, 感觉都好小");
            Console.WriteLine("git commit 到底在哪里啊, IDEA是有设置修改的代码默认都是暂存的(省去了git add .这一步), 找不到 commit 啊, 只有推送, 拉取");
            Console.WriteLine("找到了 [提交临时数据] 就是的. Ctrl + Entenr");
            Console.WriteLine("每次修改文件后记得 点那个 + 也就是 git add , 不然commit时是上次+时的文件");
            Console.WriteLine("还有一个问题, 解决方案资源管理器, 就是查看项目结构的, 最顶级就是firstSeason也就是这个项目, 那么解决方案下的 .gitignore .readme 文件, 根本找不到");
        }
    }
}