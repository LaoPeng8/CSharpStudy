using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thirdlySeasonTankBattle.Entity
{
    /// <summary>
    /// 不会移动的物体
    /// </summary>
    internal class NotMovething : GameObject
    {
        /// <summary>
        /// 物体的图片
        /// </summary>
        public Image Img { get; set; }

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
