using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{
    public class Cat
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Cat(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return $"{{Id: {Id}, Name: {Name}, Description: {Description}}}";
        }
    }

    public struct Parrot
    {
        public long Id { get; set; }// 结构体居然也有访问器
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Parrot(long id, string name, string description)// 结构体居然也有构造方法
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string? ToString()// 结构体居然也能重写ToString()
        {
            return $"{{Id: {Id}, Name: {Name}, Description: {Description}}}";
        }
    }


    public class Demo07
    {

        /**
         * 
         * 结构体 和 类 的区别
         * 
         * 类是引用类型
         * 赋值是将引用赋值过去, 原 cat1 的地址 因为没有被任何一个变量引用, 会被GC
         * 
         * 给 cat2.Description 赋值, 打印cat1却打印出了赋的值, 就因为是赋值的引用 (或者说都指向了同一个对象/实例/地址)
         * 
         */
        public static void Test01()
        {
            Cat cat1 = new Cat(1, "小橘", "肥不拉基的小猫");
            Cat cat2 = new Cat(2, "耄耋", "技能是哈气");

            cat1 = cat2;

            cat2.Description = cat2.Description + ", 脑袋是没有耳朵的";
            Console.WriteLine(cat1);// {Id: 2, Name: 耄耋, Description: 技能是哈气, 脑袋是没有耳朵的}
        }

        /**
         * 
         * 结构体 和 类 的区别
         * 
         * 结构体是值类型
         * 赋值是将, 各个值赋值过去 (就像是一个综合/批量 的变量)
         * 
         * parrot1 = parrot2;
         * 等同于
         * parrot1.Id = parrot2.Id;
         * parrot1.Name = porrot2.Name;
         * parrot1.Description = parrto2.Description
         * 
         * 所以 打印 parrot1 时并没有打印出, 后来给parrot2赋的值, 因为本质上 parrot1 和 parrot2 不是同一个对象, 地址不同
         * 
         */
        public static void Test02() {
            Parrot parrot1 = new Parrot(1, "虎皮", "便宜, 新手入门嘎嘎造");
            Parrot parrot2 = new Parrot(2, "牡丹", "稍贵, 飞天老虎钳, 咬人嘎嘎疼");

            parrot1 = parrot2;

            parrot2.Description = parrot2.Description + ", 颜色有紫伊莎/紫熏/等等...";
            Console.WriteLine(parrot1);// {Id: 2, Name: 牡丹, Description: 稍贵, 飞天老虎钳, 咬人嘎嘎疼}
        }
    }
}
