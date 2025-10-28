using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    // abstract 定义抽象类
    public abstract class EnemyTwo
    {
        // 抽象类可以拥有正常的属性
        private int Hp { get; set; }
        private int Speed { get; set; }

        // 抽象类可以拥有正常的方法
        public void Move()
        {
            Console.WriteLine("移动中...");
        }

        // 通过 abstract 定义抽象方法, 子类必须实现
        public abstract void Attack();
    }

    public class Boss2 : EnemyTwo
    {
        // 子类必须重写抽象类的抽象方法
        public override void Attack()
        {
            Console.WriteLine("Boss攻击...");
        }
    }
    

    /**
     * 通过 sealed 声明密封类
     */
    public sealed class Base
    {

    }

    /**
     * 直接报错, "Child":无法从密封类型"Base"派生
     */
    //public class Child : Base
    //{

    //}



    public class BaseTwo
    {
        //public sealed void Move() 会报错, 因为BaseTwo.Move()不是重写,所以无法密封, 也就是说 sealed 作用于方法时, 只能作用在重写的方法上, 使这个重写方法不能再次被重写
        public virtual void Move()
        {
            Console.WriteLine("BaseTwo.Move()...");
        }
    }

    
    public class Child2 : BaseTwo
    {
        public sealed override void Move()// sealed 密封方法, 这个Move()是重写的父类的Move(), 此时加上sealed后, 密封方法, 如由其他类继承 Child2 后, 即不能重写这个Move()方法了
        {
            Console.WriteLine("Child2.Move()...");
        }
    }


    public class Car
    {

        public int Speed { get; set; }

        public int Hp { get; set; }

        public Car()
        {
            Console.WriteLine("无参构造: Car()");
        }

        public Car(int speed, int hp)
        {
            Console.WriteLine("有参构造: Car(int speed, int hp)");
            Speed = speed;
            Hp = hp;
        }
    }

    public class AudiCar : Car
    {
        private int Light { get; set; }

        //public new int Speed { get; set; } //和重写方法一样, 子类定义与父类重名的属性时, 父类声明子类引用时,子类是通过new隐藏了该属性时, 调用Speed实际上就是调用的父类的Speed

        public AudiCar()// 如果不以 : base(参数) 这种形式调用父类构造的话, 子类构造是会默认调用父类构造的, 也就是 : base()
        {
            Console.WriteLine("无参构造: AudiCar()");
        }

        public AudiCar(int speed, int hp) : base(speed, hp)// 以: base(参数1,参数2)方式, 调用父类有参构造
        {
            Console.WriteLine("无参构造: AudiCar(int speed, int hp)");
        }

        public AudiCar(int light, int speed, int hp) : base(speed, hp)
        {
            Console.WriteLine("无参构造: AudiCar(int light, int speed, int hp)");
            Light = light;
        }
    }

    /**
     * public: 同一程序集(dll,exe)中的任何其他代码或引用该程序集的其他程序集都可以访问该成员
     * private: 只有同一类或结构中的代码可以访问该成员
     * protected: 只有同一类或结构或子类中的代码才可以访问该成员
     * internal: 同一程序集中的任何代码都可以访问该类型或成员, 但别的代码(其他代码引用该程序集)不可以
     * protected internal: 在同一程序集中, protected internal 体现的是 internal 的性质; 在其他程序集中 体现的是 protected 的性质;
     * 
     * public, private 修饰字段和方法时, 表示该字段或方法能不能通过对象去访问, 只有public才可以通过对象访问, private只能在类内部访问
     * 
     * public class 可以在别的项目中访问 (一个解决方案下有多个项目)
     * class 不能在别的项目访问
     * 
     * new 隐藏继承的成员 Demo02 36行有介绍, 使用 new隐藏子类重写的父类方法, new不仅可以隐藏方法,也可隐藏属性. 通过父类声明子类引用时调用即调用的父类的同名属性/方法, 而不是子类重写的
     * 
     * abstract 用来修饰类, 表示抽象类, 抽象类只能是其他类的基类(父类), 不能与 sealed,static 一起使用.
     * abstract 修饰方法时表示抽象方法, 无方法体, 访问级别不能为私有
     * 
     * sealed 修饰类时表示 密封类, 无法被继承, 不能和 abstract,static 一起使用.
     * sealed 修饰方法/属性 时表示 密封方法/属性 不能被继续重写(修饰方法/属性时 必须和 override 一起使用, 即重写父类的方法/属性, 同时通过 sealed 表示该方法发不能被子类继承父类后重写)
     * 
     * static 修饰类时表示静态类, 静态类所有成员必须是静态的, 不能和 abstract,sealed一起使用
     * static 可以修饰方法,字段,属性,事件, 始终通过类名而不是实例名称访问静态成员, 静态字段只有一个副本
     * 
     * const 用来声明常量, 常量需在声明时候赋初始值, 不能和 static 一起使用, 常量默认是static的, 如果没记错, 声明常量一般是全大写
     * 
     * readonly 用来声明自读字段, 只读字段可以在声明时 或 构造函数中赋值, 每个类或结构的实例都有一个独立的副本, 可以与static共同使用, 表示 静态只读变量
     * 
     * virtual 修饰方法,属性,索引器,事件声明, 并使它们可以在子类中被重写 (默认情况下, 方法是非虚拟的(非 virtual) 不能重写非虚拟方法) virtual不能和 static,abstract,private,override一起使用
     * 
     * override 要扩展或修改继承(重写)的方法, 属性, 索引器, 事件的抽象实现或虚实现, 必须使用override修饰符 (重写的成员必须是 virtual, abstract, override)
     */
    public class Demo03
    {
        /**
         * 测试抽象类
         */
        public static void Test01()
        {
            EnemyTwo enemyTwo = new Boss2();
            enemyTwo.Attack();
        }

        /**
         * 测试密封类
         */
        public static void Test02()
        {

        }

        /**
         * 测试子类构造函数调用父类构造函数
         */
        public static void Test03()
        {
            /**
             * 打印: 先调用了父类无参构造, 再是 new AudiCar()自己的无参构造
             * 无参构造: Car()
             * 无参构造: AudiCar()
             */
            new AudiCar();
            Console.WriteLine();

            /**
             * 打印: 都是先调用父类构造, 没有通过 : base() 调用, 就会默认调父类无参构造
             * 有参构造: Car(int speed, int hp)
             * 无参构造: AudiCar(int speed, int hp)
             */
            Console.WriteLine();
            new AudiCar(120, 100);

            /**
             * 打印: 
             * 有参构造: Car(int speed, int hp)
             * 无参构造: AudiCar(int light, int speed, int hp)
             */
            new AudiCar(800, 120, 100);
        }
    }
}
