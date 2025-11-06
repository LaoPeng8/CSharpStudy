using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thirdlySeasonTankBattle.Entity
{
    /// <summary>
    /// 坦克大战游戏中的 Object, 游戏中所有的实体都有的属性 X, Y
    /// </summary>
    internal abstract class GameObject
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 获取图片, 抽象方法子类必须都实现
        /// </summary>
        /// <returns></returns>
        public abstract Image GetImage();

        public void DrawSelf()
        {
            Graphics graphics = GameFramework.graphics;
            graphics.DrawImage(GetImage(), X, Y);// 那么此处绘制时, 实际都是子类对象, 必然都实现了 GetImage()
        }
    }
}
