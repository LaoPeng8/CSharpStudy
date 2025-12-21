// See https://aka.ms/new-console-template for more information
// 和正常的类一样是拥有 namespace 和 main方法的, 只是单一个打印不需要namespace 而main方法被省略了, 因为Program.cs是一个程序的入口
//Console.WriteLine("Hello, World!");

using fourthlySeason;

Demo01 demo01 = new Demo01();
//demo01.Test01();
//demo01.Test02();
//demo01.Test03();
//demo01.Test04();
//demo01.Test05();

Demo02 demo02 = new Demo02();
//demo02.Test01();
//demo02.Test02();
//demo02.Test03();
//demo02.Test04();
//demo02.Test04Plus();
//demo02.Test05();

Demo03 demo03 = new Demo03();
//demo03.Test01();

Demo04 demo04 = new Demo04();
//demo04.Test01();
//demo04.Test02();// 没有报错, 但会给出提示, 已过时
//demo04.Test03();
//demo04.Test04("人有悲欢离合, 月有阴晴圆缺, 此事古难全");
//demo04.Test04("但愿人长久, 千里共婵娟");
//demo04.Test05();

Demo05 demo05 = new Demo05();
//demo05.Test01();
//demo05.Test02();

Demo06 demo06 = new Demo06();
//demo06.Test01();
//demo06.Test02();
//demo06.Test03();
//demo06.Test04();
//demo06.Test05();
//demo06.Test06();
//demo06.Test07();
//demo06.Test08();
//demo06.Test10();

Demo07 demo07 = new Demo07();
//demo07.Test01();
//demo07.Test02();
//demo07.Test03();
//demo07.Test04();
//demo07.Test05();
//demo07.Test06();
//demo07.Test07();
//demo07.Test08();
//demo07.Test09();
//demo07.Test10();
//demo07.Test11();

/**
 * Visual Studio 或者说C# 项目, 只能运行一个Main方法, 即Program.cs, 老师给出的方案是打开两个Visual Studio, 并且是俩个项目分别运行 Server, Client
 * 我打开两个 Visual Studio 运行同一个项目的不同两个方法, 会提示某文件被占用...
 * Debug目录下是已经编译的文件, 可以先执行 TestServer(); 后将编译后的文件复制放在其他地方, 后再执行TestClient()就不会冲突了, 不通过Visual Studio执行, 单独执行两个编译后的文件
 */
Demo08 demo08 = new Demo08();
//demo08.TestServer();
//demo08.TestClient();
//demo08.TestUpdServer();
//demo08.TestUpdClient();

Demo09 demo09 = new Demo09();
//demo09.Test01();
//demo09.Test02();
//demo09.Test03();
//demo09.Test04();

Demo10 demo10 = new Demo10();
//demo10.Test01();
//demo10.Test02();
//demo10.Test03();
//demo10.Test04();
//demo10.Test05();
//demo10.Test06();
//demo10.Test07();
//demo10.Test08();
//demo10.Test09();
//demo10.Test10();
//demo10.Test11();
demo10.Test12();



