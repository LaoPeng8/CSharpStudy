using System;
using System.Collections.Generic;
using System.Text;

namespace fourthlySeason.myAttribute
{
    /// <summary>
    /// 自定义特性时, 一般使用 XXXAttribute 格式来命名(调用该特性时, 只用[XXX]而不用[XXXAttribute]), 一般使用 sealed 表示该类不能被继承
    ///     1. 需要继承 Attribute 类, 表明这是一个特性类
    ///     2. 需要通过注解 [AttributeUsage(AttributeTargets.Class)] 来表示, 该特性是用于 类/方法/变量 (还有很多特性, 这是最基本的特性) (这是描述特性的特性, 普通的特性就是描述 类/方法/变量)
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class InfoAttribute : Attribute
    {
        public string developer;
        public string version;
        public string description;

        // 使用该特性时的参数, 实际上就是调用特性类的构造方法, 所以要特性的参数可变, 可以灵活的定义几个构造方法
        public InfoAttribute(string developer, string version, string description)
        {
            this.developer = developer;
            this.version = version;
            this.description = description;
        }
    }
}
