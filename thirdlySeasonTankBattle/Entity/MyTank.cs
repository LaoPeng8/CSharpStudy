using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Manager;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Entity
{
    /// <summary>
    /// 自己操作的坦克
    /// </summary>
    internal class MyTank : Movething
    {
        private int Hp { get; set; }
        private int originalX = 0;
        private int originalY = 0;

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
            this.originalX = x;
            this.originalY = y;
            this.Speed = speed;
            this.Hp = 3;

            this.BitmapDown = Resources.MyTankDown;
            this.BitmapUp = Resources.MyTankUp;
            this.BitmapLeft = Resources.MyTankLeft;
            this.BitmapRight = Resources.MyTankRight;

            this.Direction = direction;
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
                case Keys.Up:
                    {
                        if (this.Direction != Direction.Up)
                        {
                            this.Direction = Direction.Up;
                        }
                        IsMoving = true;
                        break;
                    }
                case Keys.S:
                case Keys.Down:
                    {
                        if (this.Direction != Direction.Down)
                        {
                            this.Direction = Direction.Down;
                        }
                        IsMoving = true;
                        break;
                    }
                case Keys.A:
                case Keys.Left:
                    {
                        if (this.Direction != Direction.Left)
                        {
                            this.Direction = Direction.Left;
                        }
                        IsMoving = true;
                        break;
                    }
                case Keys.D:
                case Keys.Right:
                    {
                        if (this.Direction != Direction.Right)
                        {
                            this.Direction = Direction.Right;
                        }
                        IsMoving = true;
                        break;
                    }
                case Keys.Space:
                    {
                        Attack();
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

        /// <summary>
        /// 发射子弹
        /// </summary>
        private void Attack()
        {
            int x = this.X;
            int y = this.Y;

            switch (this.Direction)
            {
                case Direction.Up:
                    {
                        x = x + this.Width / 2;
                        break;
                    }
                case Direction.Down:
                    {
                        x = x + this.Width / 2;
                        y = y + this.Height;
                        break;
                    }
                case Direction.Left:
                    {
                        y = y + this.Height / 2;
                        break;
                    }
                case Direction.Right:
                    {
                        x = x + this.Width;
                        y = y + this.Height / 2;
                        break;
                    }
            }

            GameObjectManager.CreateBullet(x, y, Direction, Tag.MyTank);
            GameSoundManager.PlayFire();
        }

        /// <summary>
        /// 绘制自己, 并调用Move() 如果在移动状态(按下方向键则在移动状态,松开反之), 则修改坐标, 每次绘制坐标不一样, 就好像在移动
        /// </summary>
        public override void Update()
        {
            /**
             * MoveCheck() 当检测到超出窗体等不能移动情况下, 会将移动状态改为停止
             * Move() 会判断不能移动会直接return;就不会修改坐标
             * Update() 绘制当前物体
             */
            MoveCheck();
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

        /// <summary>
        /// 移动检测
        ///     检测, 不要超出窗体
        ///     检测, 有没有和其他物体发生碰撞
        /// </summary>
        private void MoveCheck()
        {
            #region 检测是否超出窗体
            /**
             * 如果向上移动, 则判断 Y 坐标 - 速度 不能小于 0 (Y < 0 如果这样判断, 就相当于当前绘制的一帧, 已经超出了窗体, 才停止)
             * 如果向上移动, XY坐标在图片的左上角, 所以向上移动不需要加上物体自身的高度, Y已经是自身的最高了
             * 
             * 如果向下移动, 除 Y + Speed 外, 还需要 + Height, 如果不加就变成了物体的左上角坐标还在窗口内就不会停止(物体的其他部分就超出窗体了)
             * 
             * 其他方向同理
             */
            if (this.Direction == Direction.Up && this.Y - Speed < 0)
            {
                this.IsMoving = false;
                return;
            }
            else if (this.Direction == Direction.Down && this.Y + Speed + Height > 450) // 目前窗口是固定的 450 * 450
            {
                this.IsMoving = false;
                return;
            }
            else if (this.Direction == Direction.Left && this.X - Speed < 0)
            {
                this.IsMoving = false;
                return;
            }
            else if (this.Direction == Direction.Right && this.X + Speed + Width > 450)
            {
                this.IsMoving = false;
                return;
            }
            #endregion

            #region 检测是否和其他元素发生碰撞
            /**
             * 这里和 检测是否超出窗体一样, 需要检测下一帧的位置
             * 如果直接用 var rectangle = GetRectangle(); 去判断是否和墙发生碰撞, 则已经碰撞在一起后才会停止
             * 并且停止后不能再次启动, 因为无论如何运动, 每次碰撞检测都会检测到是已经碰撞了, 则无法移动
             * 
             * 所以需要根据方向, 加上速度, 就是下一帧的位置
             * 那么下一次要碰撞了, 则停止移动, 如何换一个方向走, 由于并没有实际碰撞所以是可以动的,
             * 换一个方向后当下一帧不会碰撞了, 在可以继续移动
             * 
             */
            var rectangle = GetRectangle();
            switch (Direction)
            {
                case Direction.Up:
                    {
                        rectangle.Y -= Speed;
                        break;
                    }
                case Direction.Down:
                    {
                        rectangle.Y += Speed;
                        break;
                    }
                case Direction.Left:
                    {
                        rectangle.X -= Speed;
                        break;
                    }
                case Direction.Right:
                    {
                        rectangle.X += Speed;
                        break;
                    }
            }


            if (GameObjectManager.IsCollideWall(rectangle) != null)
            {
                IsMoving = false;
                return;
            }
            if (GameObjectManager.IsCollideSteelWall(rectangle) != null)
            {
                IsMoving = false;
                return;
            }
            if (GameObjectManager.IsCollideBossTank(rectangle) != null)
            {
                IsMoving = false;
                return;
            }
            
            
            #endregion

        }

        /// <summary>
        /// 被攻击
        /// </summary>
        public void TankDamage()
        {
            this.Hp--;

            if (this.Hp < 1)
            {
                X = originalX;
                Y = originalY;
                this.Hp = 3;
            }
        }



    }
}
