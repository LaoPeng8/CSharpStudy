using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thirdlySeasonTankBattle.Entity
{
    internal enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    /// <summary>
    /// 会移动的物体
    /// </summary>
    internal class Movething : GameObject
    {
        /// <summary>
        /// 物体的图片 (朝向上的时候的图片)
        /// </summary>
        public Bitmap BitmapUp { get; set; }

        /// <summary>
        /// 物体的图片 (朝向下的时候的图片)
        /// </summary>
        public Bitmap BitmapDown { get; set; }

        /// <summary>
        /// 物体的图片 (朝向左的时候的图片)
        /// </summary>
        public Bitmap BitmapLeft { get; set; }

        /// <summary>
        /// 物体的图片 (朝向右的时候的图片)
        /// </summary>
        public Bitmap BitmapRight { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 物体的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 实现父类的抽象方法, 获取自身的图片
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            Bitmap result = null;
            switch (Direction)
            {
                case Direction.Up:
                    {
                        result = BitmapUp;
                        break;
                    }
                case Direction.Down:
                    {
                        result = BitmapDown;
                        break;
                    }
                case Direction.Left:
                    {
                        result = BitmapLeft;
                        break;
                    }
                case Direction.Right:
                    {
                        result = BitmapRight;
                        break;
                    }
                default:
                    {
                        result = BitmapUp;
                        break;
                    }
            }

            result.MakeTransparent(Color.Black);// 将图片的黑色背景置为透明
            return result;
        }
    }
}
