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
demo04.Test05();

