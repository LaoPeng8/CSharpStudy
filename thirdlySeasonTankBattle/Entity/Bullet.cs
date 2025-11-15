using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Manager;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Entity
{
    internal enum Tag
    {
        MyTank = 0,
        EnumyTank = 1,
    }

    /// <summary>
    /// 子弹
    /// </summary>
    internal class Bullet : Movething
    {
        public Tag Tag { get; set; }

        public bool IsDestroy { get; set; }

        public Bullet(int x, int y, int speed, Direction direction, Tag tag)
        {
            this.IsMoving = true;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.BitmapUp = Resources.BulletUp;
            this.BitmapDown = Resources.BulletDown;
            this.BitmapLeft = Resources.BulletLeft;
            this.BitmapRight = Resources.BulletRight;
            this.Direction = direction;
            this.Tag = tag;

            this.X = this.X - Width / 2;
            this.Y = this.Y - Height / 2;

            this.IsDestroy = false;
        }


        /// <summary>
        /// 绘制自己, 并调用Move()
        /// </summary>
        public override void Update()
        {
            if (!IsDestroy)
            {
                MoveCheck();
                Move();
                base.Update();
            }
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
             * 超出窗体需要移除自身
             * 
             * + 3 是因为, 现在是子弹的左上角坐标, + 3是把子弹所占的高度加上
             * 即向上超出边界时, 实际上是子弹的下边(左上角坐标Y+3)超出后才消失, (不+3则是 子弹的头刚超出窗体就消失)
             */
            if (this.Direction == Direction.Up && this.Y + Height / 2 + 3 < 0)
            {
                IsDestroy = true;
                return;
            }
            else if (this.Direction == Direction.Down && this.Y + Height / 2 + 3 > 450) // 目前窗口是固定的 450 * 450
            {
                IsDestroy = true;
                return;
            }
            else if (this.Direction == Direction.Left && this.X + Width / 2 + 3 < 0)
            {
                IsDestroy = true;
                return;
            }
            else if (this.Direction == Direction.Right && this.X + Width / 2 - 3 > 450)
            {
                IsDestroy = true;
                return;
            }
            #endregion


            #region 检测是否和其他元素发生碰撞
            /**
             * 与 检测是否超出窗体一致
             */
            var rectangle = GetRectangle();
            rectangle.X = this.X + Width / 2 - 3;
            rectangle.Y = this.Y + Height / 2 - 3;
            rectangle.Width = 3;
            rectangle.Height = 3;


            int xExplosion = this.X + Width / 2;
            int yExplosion = this.Y + Height / 2;

            NotMovething wall = null;
            if ((wall = GameObjectManager.IsCollideWall(rectangle)) != null)// 子弹与墙发生碰撞
            {
                IsDestroy = true;// 子弹销毁
                GameObjectManager.DestroyWall(wall);// 墙销毁
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);// 创建爆炸效果
                GameSoundManager.PlayBlast();//爆炸音效
                return;
            }
            if (GameObjectManager.IsCollideSteelWall(rectangle) != null)// 子弹与钢墙发生碰撞
            {
                IsDestroy = true;
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                GameSoundManager.PlayBlast();
                return;
            }


            if (Tag == Tag.MyTank)// 如果是我的坦克的子弹
            {
                EnemyTank enemyTank = null;
                if ((enemyTank = GameObjectManager.IsCollideEnemyTank(rectangle)) != null)// 我的坦克子弹与敌方坦克发生碰撞
                {
                    IsDestroy = true;
                    GameObjectManager.DestroyTank(enemyTank);
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    GameSoundManager.PlayBlast();
                }

                // 如果攻击到了boss
                if (GameObjectManager.IsCollideBossTank(rectangle) != null)
                {
                    IsDestroy = true;
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    GameFramework.ChangeToGameOver();
                    GameSoundManager.PlayBlast();
                }
            }

            if(Tag == Tag.EnumyTank)// 如果是敌方坦克的子弹
            {
                MyTank myTank = null;
                if ((myTank = GameObjectManager.IsCollideMyTank(rectangle)) != null)
                {
                    IsDestroy = true;
                    myTank.TankDamage();
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    GameSoundManager.PlayBlast();
                    return;
                }

                // 如果攻击到了boss
                if(GameObjectManager.IsCollideBossTank(rectangle) != null)
                {
                    IsDestroy = true;
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    GameFramework.ChangeToGameOver();
                    GameSoundManager.PlayBlast();
                }
            }
            #endregion
        }




    }
}
