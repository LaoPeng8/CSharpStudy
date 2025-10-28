using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    /**
     * 一般情况下, 接口只能包含方法, 属性, 索引器, 事件 的声明
     * 接口不允许有访问权限修饰符, private等, 接口成员都是公有的 public
     * 
     * 接口可以继承, 与类的继承一致
     * 
     * 接口常常以 I 开头, 表示是一个接口而非类
     * 
     * 类在继承父类 和 实现接口时 都是使用 :
     * 那么问题来了 同时需要继承父类, 实现接口时, 规则是: 先继承后实现即  public class childClass : ParentClass, IFly
     */
    public interface IFly
    {
        public void Fly();

        public void FlyAttack();
    }

    public class Plane : IFly
    {
        public void Fly()
        {
            Console.WriteLine("飞机在飞...");
        }

        public void FlyAttack()
        {
            Console.WriteLine("飞机在空中攻击, 发射导弹...");
        }
    }

    public class Bird : IFly
    {
        public void Fly()
        {
            Console.WriteLine("小鸟在飞...");
        }

        public void FlyAttack()
        {
            Console.WriteLine("小鸟在空中攻击, 用嘴咬...");
        }
    }




    public interface IParent
    {
        public void showParent();
    }

    public interface IChild : IParent
    {
        public void showChild(); 
    }

    /**
     * 接口的继承
     * 
     * IChild 继承了 IParent
     * 
     * 所以实现 IChild 接口时, 出现了 IChild 里面继承自父类Iparent 的方法, 也需要实现
     * 
     */
    public class Test02 : IChild
    {
        public void showChild()
        {
            throw new NotImplementedException();
        }

        public void showParent()
        {
            throw new NotImplementedException();
        }
    }



    class Demo04
    {
        public static void Test01()
        {
            IFly plane = new Plane();
            plane.Fly();
            plane.FlyAttack();
            Console.WriteLine();

            IFly bird = new Bird();
            bird.Fly();
            bird.FlyAttack();
        }
    }
}
