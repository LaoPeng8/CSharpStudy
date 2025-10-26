using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{
    public class Enemy
    {
        public virtual void Move()
        {
            Console.WriteLine("敌人正在移动...");
        }

        public void AI()
        {
            Console.WriteLine("敌人的普通AI...");
        }
    }

    public class Boss:Enemy
    {
        /**
         * Boss.Move() 继承成员 Enemy.Move() 未被标记为 virtual, abstract, override 无法进行重写 
         * 
         */
        public override void Move() 
        {
            Console.WriteLine("Boss正在移动...");
        }

        public void BossSkill()
        {
            Console.WriteLine("Boss特有技能...");
        }

        public new void AI()
        {
            Console.WriteLine("Boss的AI...");
        }
    }

    class Demo02
    {
        public static void Test01()
        {
            Boss boss = new Boss();
            boss.Move();

            Enemy enemy = new Enemy();
            enemy.Move();

            // 父类声明, 子类引用
            Enemy boss2 = new Boss();
            //boss2.BossSkill(); 声明的是 Enemy, Enemy中是没有 BossSkill()方法的 (虽然 new Boss()确实存在)
            boss2.Move();// Boss正在移动... Move()方法在父类中声明的 virtual 表示(子类重写用 override), 该方法可能被子类重写, 在调用时需要检查是否有子类的方法, 实际调用子类的方法 (virtual 虚方法)
            boss2.AI();// 敌人的普通AI...  AI()方法在父类中正常声明, 子类重写时用 new, 在父类声明,子类引用时, 会直接调用父类的AI()方法,子类的AI()相当于被隐藏了(因为父类没有用 virtual 所以不会检查是否有子类重写) (new 隐藏方法)

        }
    }
}
