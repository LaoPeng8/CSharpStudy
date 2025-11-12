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
        /// 宽
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 获取图片, 抽象方法子类必须都实现
        /// </summary>
        /// <returns></returns>
        public abstract Image GetImage();

        public virtual void Update()
        {
            DrawSelf();
        }

        public void DrawSelf()
        {
            Graphics graphics = GameFramework.graphics;
            graphics.DrawImage(GetImage(), X, Y);// 那么此处绘制时, 实际都是子类对象, 必然都实现了 GetImage()
        }

        /// <summary>
        /// 获取当前物体的矩形 (当前物体在窗体上所占的一个矩形范围)
        /// 
        /// Rectangle 结构体 表示一个矩形范围, 传入坐标(物体左上角), 宽高
        /// 
        /// 自己实现判断 当前物体, 是否在另一个物体的范围内还是很麻烦的, Rectangle 内部实现了相关方法
        /// </summary>
        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }

}
