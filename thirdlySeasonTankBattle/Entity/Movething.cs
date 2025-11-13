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
    /// 会移动的物体, 构造Movething时, 注意前赋值上下左右的图片, 之后再赋值方向(需保证顺序, 否则设置方向时, 获取的物体的宽高会错误)
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
        /// 是否移动
        /// </summary>
        public bool IsMoving { get; set; } = false;


        /// <summary>
        /// 物体的方向
        /// </summary>
        private Direction _direction;
        public Direction Direction {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;

                Width = 0;// 默认值
                Height = 0;
                if(Direction == Direction.Up && BitmapUp != null)
                {
                    Width = BitmapUp.Width;
                    Height = BitmapUp.Height;
                }
                if (Direction == Direction.Down && BitmapDown != null)
                {
                    Width = BitmapDown.Width;
                    Height = BitmapDown.Height;
                }
                if (Direction == Direction.Left && BitmapLeft != null)
                {
                    Width = BitmapLeft.Width;
                    Height = BitmapLeft.Height;
                }
                if (Direction == Direction.Right && BitmapRight != null)
                {
                    Width = BitmapRight.Width;
                    Height = BitmapRight.Height;
                }
            }
        }

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
