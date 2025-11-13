using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Manager;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Entity
{

    public enum EnumEnemyTankType
    {
        绿坦克 = 0,
        黄坦克 = 1,
        灰坦克 = 2,
        快坦克 = 3,
        慢坦克 = 4,
    }

    /// <summary>
    /// 敌方坦克
    /// </summary>
    internal class EnemyTank : Movething
    {

        private Direction[] directionAll = new Direction[] {Direction.Up, Direction.Down, Direction.Left, Direction.Right};
        Random directionRandom = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed">每一帧移动多少个像素</param>
        /// <param name="dir"></param>
        public EnemyTank(int x, int y, EnumEnemyTankType enumEnemyTankType, Direction direction = Direction.Down)
        {
            IsMoving = true;
            this.X = x;
            this.Y = y;

            selectTank(enumEnemyTankType);
            this.Direction = direction;
        }

        private void selectTank(EnumEnemyTankType enumEnemyTankType)
        {
            switch (enumEnemyTankType)
            {
                case EnumEnemyTankType.绿坦克:
                    {
                        this.Speed = 2;
                        this.BitmapDown = Resources.GreenDown;
                        this.BitmapUp = Resources.GreenUp;
                        this.BitmapLeft = Resources.GreenLeft;
                        this.BitmapRight = Resources.GreenRight;
                        break;
                    }
                case EnumEnemyTankType.黄坦克:
                    {
                        this.Speed = 2;
                        this.BitmapDown = Resources.YellowDown;
                        this.BitmapUp = Resources.YellowUp;
                        this.BitmapLeft = Resources.YellowLeft;
                        this.BitmapRight = Resources.YellowRight;
                        break;
                    }
                case EnumEnemyTankType.灰坦克:
                    {
                        this.Speed = 2;
                        this.BitmapDown = Resources.GrayDown;
                        this.BitmapUp = Resources.GrayUp;
                        this.BitmapLeft = Resources.GrayLeft;
                        this.BitmapRight = Resources.GrayRight;
                        break;
                    }
                case EnumEnemyTankType.快坦克:
                    {
                        this.Speed = 4;
                        this.BitmapDown = Resources.QuickDown;
                        this.BitmapUp = Resources.QuickUp;
                        this.BitmapLeft = Resources.QuickLeft;
                        this.BitmapRight = Resources.QuickRight;
                        break;
                    }
                case EnumEnemyTankType.慢坦克:
                default:
                    {
                        this.Speed = 1;
                        this.BitmapDown = Resources.SlowDown;
                        this.BitmapUp = Resources.SlowUp;
                        this.BitmapLeft = Resources.SlowLeft;
                        this.BitmapRight = Resources.SlowRight;
                        break;
                    }
            }
        }


        /// <summary>
        /// 绘制自己, 并调用Move() 如果在移动状态(EnemyTank一直会在移动状态), 则修改坐标, 每次绘制坐标不一样, 就好像在移动
        /// </summary>
        public override void Update()
        {
            /**
             * MoveCheck() 当检测到超出窗体等不能移动情况下, 修改移动方向
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
        /// 获取一个方向(当前方向除外)
        /// </summary>
        private void ChangeDirection()
        {
            Direction[] directions = directionAll.Where(o => o != this.Direction).ToArray();
            int index = directionRandom.Next(0, 3);
            this.Direction = directions[index];

            MoveCheck();// 改变方向后, 调用移动检测, 如果依旧碰撞则会继续递归调用改变方向, 直到改变方向后移动检测没有碰撞
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
             * 与我的坦克的 移动检测判断方式一致
             *  区别
             *  我的坦克：判断到下一帧要超出窗体后 this.IsMoving = false; 停止移动
             *  敌方坦克：判断到下一帧要超出窗体后 过滤掉当前方向,修改为其他三个方向之一, 继续移动
             */
            if (this.Direction == Direction.Up && this.Y - Speed < 0)
            {
                ChangeDirection();
                return;
            }
            else if (this.Direction == Direction.Down && this.Y + Speed + Height > 450) // 目前窗口是固定的 450 * 450
            {
                ChangeDirection();
                return;
            }
            else if (this.Direction == Direction.Left && this.X - Speed < 0)
            {
                ChangeDirection();
                return;
            }
            else if (this.Direction == Direction.Right && this.X + Speed + Width > 450)
            {
                ChangeDirection();
                return;
            }
            #endregion


            #region 检测是否和其他元素发生碰撞
            /**
             * 与 检测是否超出窗体一致
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
                ChangeDirection();
                return;
            }
            if (GameObjectManager.IsCollideSteelWall(rectangle) != null)
            {
                ChangeDirection();
                return;
            }
            if (GameObjectManager.IsCollideBossTank(rectangle) != null)
            {
                ChangeDirection();
                return;
            }
            #endregion



        }



    }
}
