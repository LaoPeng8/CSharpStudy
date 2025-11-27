using System;
using System.Collections.Generic;
using System.Text;

namespace fourthlySeason
{

    public delegate void DownStairDelegate();

    /// <summary>
    /// 工具人 类
    /// </summary>
    class ToolMan
    {

        public string Name { get; private set; }

        //public DownStairDelegate DownStairDelegate = null;
        public event DownStairDelegate DownStairDelegate = null;

        public ToolMan(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 下楼
        /// 
        /// 在下楼时会调用委托方法
        /// (多播委托, 相当于就是说我只进行下楼, 如果需要我在下楼时做一些什么操作, 不要让我去主动询问你, 反正我只是每次都会去做, 做什么, 就由你来赋值给委托, 你要做什么你来主动告诉我)
        /// </summary>
        public void DownStair()
        {
            Console.WriteLine("工具人 " + Name + " 下楼了");
            if(DownStairDelegate != null)
            {
                DownStairDelegate();
            }
        }
    }

    /// <summary>
    /// 懒人
    /// </summary>
    class LazyMan
    {
        public string Name { get; private set; }

        public LazyMan(string name)
        {
            Name = name;
        }

        public void TakeFood()
        {
            Console.WriteLine("给 " + Name + "拿外卖");
        }

        public void TakePackage()
        {
            Console.WriteLine("给 " + Name + "拿快递");
        }
    }

    /// <summary>
    /// 事件是一种特殊的委托, 或者说是受限制的委托, 是委托的一种特殊应用, 只能施加 += -= 操作, 二者本质上都是一个东西(委托)
    /// 
    /// event 只允许通过 add, remove方法来操作, 这让它不允许在类的外部直接触发, 只能在类的内部适合的时机触发. 委托可以在外部被触发(但是最好别这么用)
    /// 
    /// 使用中, 委托常用来表达回调, 事件表达外发的接口
    /// </summary>
    internal class Demo03
    {
        public void Test01()
        {
            ToolMan toolMan = new ToolMan("小明");

            LazyMan lazyMan1 = new LazyMan("张三");
            LazyMan lazyMan2 = new LazyMan("李四");
            LazyMan lazyMan3 = new LazyMan("王五");

            // 主动给 工具人(发布者) 赋值(订阅), 工具人后续执行某些操作(下楼), 会执行这个委托, 具体委托内容由委托人提供
            toolMan.DownStairDelegate += lazyMan1.TakeFood;
            toolMan.DownStairDelegate += lazyMan1.TakePackage;
            toolMan.DownStairDelegate += lazyMan2.TakeFood;
            toolMan.DownStairDelegate += lazyMan3.TakeFood;

            // 此时, 工具人下楼时, 除自己下楼外, 会去执行委托 (具体委托内容由委托人赋值, 没赋值(委托), 就是没有, 不需要由工具人去主动询问)
            toolMan.DownStair();
            Console.WriteLine();

            // 如果不需要订阅了, 也可由委托人主动取消订阅
            toolMan.DownStairDelegate -= lazyMan1.TakeFood;
            toolMan.DownStairDelegate -= lazyMan1.TakePackage;
            toolMan.DownStair();
            Console.WriteLine();

            // 但是此时会有两个问题
            // 1.订阅 与 取消订阅, 较为灵活, 如果委托人 直接重置了订阅, 会把其他人的订阅给覆盖掉, 非常不安全
            //toolMan.DownStairDelegate = lazyMan1.TakeFood;// 不是 += 或 -= 而是直接 =, 如果其他人也订阅过, 这就被覆盖了

            // 2.如果工具人, 不下楼怎么办 不调用toolMan.DownStair(), 在外部可以直接通过 toolMan.DownStairDelegate() 直接调用委托方法, 略过了中间的方法, 这是不对的
            //toolMan.DownStairDelegate();

            // 所以就出现了事件 event 关键字 定义委托时 使用关键字 event      public event DownStairDelegate DownStairDelegate = null;
            //toolMan.DownStairDelegate = lazyMan1.TakeFood;// 此时, 再执行赋值而非 +=,-= 就会报错, 事件"toolMan.DownStairDelegate" 只能出现在 += 或 -= (从类型 ToolMan 中使用除外)
            //toolMan.DownStairDelegate();// 此时, 直接调用委托方法也会报错, 事件"toolMan.DownStairDelegate" 只能出现在 += 或 -= (从类型 ToolMan 中使用除外)
            
            // 就是说在定义委托时使用 event 关键字, 后会限制该委托的使用, 即在外部不能 赋值=, 不能直接调用委托方法, 更加的安全可靠
        }
    }
}
