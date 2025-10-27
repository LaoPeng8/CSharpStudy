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
