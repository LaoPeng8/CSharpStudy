using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Entity
{
    /// <summary>
    /// 自己操作的坦克
    /// </summary>
    internal class MyTank : Movething
    {

        public bool IsMoving { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed">每一帧移动多少个像素</param>
        /// <param name="dir"></param>
        public MyTank(int x, int y, int speed, Direction direction = Direction.Up)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Direction = direction;
            this.BitmapDown = Resources.MyTankDown;
            this.BitmapUp = Resources.MyTankUp;
            this.BitmapLeft = Resources.MyTankLeft;
            this.BitmapRight = Resources.MyTankRight;
        }

        /// <summary>
        /// 按下键盘后触发
        /// </summary>
        /// <param name="args"></param>
        public void KeyDown(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    {
                        this.Direction = Direction.Up;
                        IsMoving = true;
                        break;
                    }
                case Keys.Up:
                    {
                        this.Direction = Direction.Up;
                        IsMoving = true;
                        break;
                    }
                case Keys.S:
                    {
                        this.Direction = Direction.Down;
                        IsMoving = true;
                        break;
                    }
                case Keys.Down:
                    {
                        this.Direction = Direction.Down;
                        IsMoving = true;
                        break;
                    }
                case Keys.A:
                    {
                        this.Direction = Direction.Left;
                        IsMoving = true;
                        break;
                    }
                case Keys.Left:
                    {
                        this.Direction = Direction.Left;
                        IsMoving = true;
                        break;
                    }
                case Keys.D:
                    {
                        this.Direction = Direction.Right;
                        IsMoving = true;
                        break;
                    }
                case Keys.Right:
                    {
                        this.Direction = Direction.Right;
                        IsMoving = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// 松开键盘后触发
        /// </summary>
        /// <param name="args"></param>
        public void KeyUp(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                case Keys.S:
                case Keys.Down:
                case Keys.A:
                case Keys.Left:
                case Keys.D:
                case Keys.Right:
                    {
                        IsMoving = false;
                        break;
                    }
            }
        }

        public override void Update()
        {
            Move();
            base.Update();
        }

        public void Move()
        {
            if (!IsMoving)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.Up:
                    {
                        this.Y -= Speed;
                        break;
                    }
                case Direction.Down:
                    {
                        this.Y += Speed;
                        break;
                    }
                case Direction.Left:
                    {
                        this.X -= Speed;
                        break;
                    }
                case Direction.Right:
                    {
                        this.X += Speed;
                        break;
                    }
            }
        }
    }
}
