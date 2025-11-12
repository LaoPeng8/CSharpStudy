using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thirdlySeasonTankBattle.Entity
{
    internal enum drawCallType
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3,
    }

    /// <summary>
    /// 不会移动的物体
    /// </summary>
    internal class NotMovething : GameObject
    {
        /// <summary>
        /// 物体的图片
        /// 
        /// 相当于 实际值存储在 _img 但是 外界是不清楚的, 外界只和 Img 交互,
        /// 虽然实际是赋值给 _img 但是, 外界感知就像赋值给 Img 一样, 相当于通过中间的 Img 交互
        /// </summary>
        private Image _img;
        public Image Img { 
            get
            {
                //return Img;// 会循环引用, 此处return Img 仍然会触发 get
                return _img;
            }
            set 
            { 
                //Img = value;// 会循环引用, 此处赋值 仍然会触发 set
                _img = value;
                Width = _img.Width;
                Height = _img.Height;
            }
        }

        public NotMovething(int x, int y, Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }

        /// <summary>
        /// 实现父类的抽象方法, 获取自身的图片
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            return Img;
        }

    }
}
