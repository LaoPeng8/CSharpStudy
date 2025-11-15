using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Entity;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Manager
{
    internal class GameObjectManager
    {

        private static List<NotMovething> wallList = new List<NotMovething>();
        private static List<NotMovething> steelList = new List<NotMovething>();
        private static List<NotMovething> bossList = new List<NotMovething>();
        private static List<EnemyTank> enemyTankList = new List<EnemyTank>();
        private static MyTank myTank = null;
        private static List<Bullet> bulletList = new List<Bullet>();
        private static object _bullectLock = new object();
        private static List<Explosion> explosionList = new List<Explosion>();

        private Point[] points = new Point[3];// 敌方坦克创建的坐标
        private static int enemyBornSpeed = 60;// 敌方坦克速度
        private static int enemyBornCount = 60;// 敌方坦克生成计数器, 满60帧生成一个敌方坦克

        public void Update()
        {
            foreach (var wall in wallList)// 绘制红色墙
            {
                wall.Update();
            }

            foreach (var steel in steelList)// 绘制白色墙
            {
                steel.Update();
            }

            foreach (var boss in bossList)// 绘制boss坦克
            {
                boss.Update();
            }

            foreach(var enemyTank in enemyTankList)// 绘制敌方坦克
            {
                enemyTank.Update();
            }

            lock (_bullectLock)
            {
                // 使用 IsShow状态 避免了 一边遍历一边 删除
                foreach (var bullet in bulletList)
                {
                    bullet.Update();// 只会绘制 IsShow = true 的子弹
                }
                bulletList = bulletList.Where(item => item.IsDestroy == false).ToList();// 绘制完后只保留未销毁的子弹
                // 这个 bulletList 赋值的过程 应该和 CreateBullet()中的bulletList.Add有冲突, 所以加锁
            }

            foreach(var explosion in explosionList)
            {
                explosion.Update();
            }
            if(explosionList.Count > 50)
            {
                explosionList = explosionList.Where(item => item.IsNeedDestroy == true).ToList();// 将爆炸效果播放完了需要销毁的爆炸效果剔除掉
            }


            myTank.Update();// 绘制我的坦克

            CreateEnemyBorn();// 创建敌方坦克, 需要不停的创建, 所以和其他的如创建墙不一样(只需要调用一次)
        }

        /// <summary>
        /// 创建敌方坦克坐标
        /// </summary>
        public void CreateEnemyBornPoint()
        {
            points[0].X = 0;
            points[0].Y = 0;

            points[1].X = 7 * 30;
            points[1].Y = 0;

            points[2].X = 14 * 30;
            points[2].Y = 0;
        }

        /// <summary>
        /// 创建敌方坦克
        /// </summary>
        private void CreateEnemyBorn()
        {
            enemyBornCount++;// 每绘制一次(一帧) 计数器+1, 计算器大于速度后, 生成敌方坦克
            if(enemyBornCount < enemyBornSpeed)
            {
                return;
            }

            // 从指定坦克坐标中随机获取一个坐标
            int index = new Random().Next(0, 3);
            Point position = points[index];

            // 从指定坦克类型中随机获取一个坦克类型
            int indexType = new Random().Next(0, 5);
            EnumEnemyTankType enumEnemyTankType = (EnumEnemyTankType)Enum.ToObject(typeof(EnumEnemyTankType), indexType);
            CreateEnemyTank(position.X, position.Y, enumEnemyTankType);
            GameSoundManager.PlayAdd();

            enemyBornCount = 0;
        }

        private void CreateEnemyTank(int x, int y, EnumEnemyTankType enumEnemyTankType)
        {
            EnemyTank tank = new EnemyTank(x, y, enumEnemyTankType);
            enemyTankList.Add(tank);
        }

        /// <summary>
        /// 创建子弹
        /// </summary>
        public static void CreateBullet(int x, int y, Direction direction, Tag tag)
        {
            lock(_bullectLock)
            {
                Bullet bullet = new Bullet(x, y, 5, direction, tag);
                bulletList.Add(bullet);
            }
        }

        /// <summary>
        /// 创建爆炸效果
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void CreateExplosion(int x, int y)
        {
            Explosion explosion = new Explosion(x, y);
            explosionList.Add(explosion);
        }

        /// <summary>
        /// 移除子弹
        /// 从bulletList中移除, 之后遍历bulletList绘制子弹时, 就绘制不到被移除的子弹了
        ///     当子弹在移动过程中超出窗体, 就需要移除子弹
        ///     当子弹与其他物体发生碰撞, 就需要移除子弹
        /// </summary>
        /// <param name="bullet"></param>
        public static void RemoveBullet(Bullet bullet)
        {
            bulletList.Remove(bullet);
        }

        /// <summary>
        /// 销毁墙
        /// </summary>
        /// <param name="wall"></param>
        public static void DestroyWall(NotMovething wall)
        {
            wallList.Remove(wall);
        }

        /// <summary>
        /// 销毁坦克
        /// </summary>
        /// <param name="wall"></param>
        public static void DestroyTank(EnemyTank enemyTank)
        {
            enemyTankList.Remove(enemyTank);
        }

        /// <summary>
        /// 创建地图
        /// </summary>
        public void CreateMap()
        {
            CreateWall(2, 1, 5, Resources.wall, wallList);
            CreateWall(4, 1, 5, Resources.wall, wallList);
            CreateWall(6, 1, 4, Resources.wall, wallList);
            CreateWall(8, 1, 4, Resources.wall, wallList);
            CreateWall(10, 1, 5, Resources.wall, wallList);
            CreateWall(12, 1, 5, Resources.wall, wallList);

            CreateWall(6, 6, 1, Resources.wall, wallList);
            CreateWall(8, 6, 1, Resources.wall, wallList);
            CreateWall(2, 7, 1, Resources.wall, wallList);
            CreateWall(3, 7, 1, Resources.wall, wallList);
            CreateWall(4, 7, 1, Resources.wall, wallList);
            CreateWall(10, 7, 1, Resources.wall, wallList);
            CreateWall(11, 7, 1, Resources.wall, wallList);
            CreateWall(12, 7, 1, Resources.wall, wallList);

            CreateWall(2, 9, 5, Resources.wall, wallList);
            CreateWall(4, 9, 5, Resources.wall, wallList);
            CreateWall(6, 8, 4, Resources.wall, wallList);
            CreateWall(7, 9, 1, Resources.wall, wallList);
            CreateWall(8, 8, 4, Resources.wall, wallList);
            CreateWall(10, 9, 5, Resources.wall, wallList);
            CreateWall(12, 9, 5, Resources.wall, wallList);

            CreateWall(7, 3, 1, Resources.steel, steelList);

            CreateHalfWallRow(0, 7, 1, Resources.steel, steelList, drawCallType.DOWN);
            CreateHalfWallRow(14, 7, 1, Resources.steel, steelList, drawCallType.DOWN);

            CreateQuarterWallCol(6, 13, 4, Resources.wall, wallList, drawCallType.RIGHT, drawCallType.DOWN);
            CreateQuarterWallRow(6, 14, 2, Resources.wall, wallList, drawCallType.RIGHT, drawCallType.UP);
            CreateQuarterWallRow(8, 14, 2, Resources.wall, wallList, drawCallType.LEFT, drawCallType.UP);

            CreateQuarterWallRow(7, 14, 1, Resources.Boss, bossList);// 绘制boss
        }


        /// <summary>
        /// 创建 我的坦克
        /// </summary>
        public void CreateMyTank()
        {
            int x = 7 * 30;
            int y = 12 * 30;
            y += 15;

            myTank = new MyTank(x, y, 2);
        }

        public void KeyDown(KeyEventArgs args)
        {
            myTank.KeyDown(args);
        }

        public void KeyUp(KeyEventArgs args)
        {
            myTank.KeyUp(args);
        }

        /// <summary>
        /// 绘制墙, 从一个点(x,y), 绘制 count 个墙 (竖着绘制)
        /// 此处 x,y 不是像素, 而是第几个格子, 一个格子是30*30, 目前创建窗口是 宽高各15个格子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private void CreateWall(int x, int y, int count, Image img, List<NotMovething> notMovethingList)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 30;

            // 一个格子(墙) 由四个图片组成
            for (int i = yPosition; i < yPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(xPosition, i, img);
                NotMovething wallRight = new NotMovething(xPosition + 16, i, img);

                notMovethingList.Add(wallLeft);
                notMovethingList.Add(wallRight);
            }
        }

        /// <summary>
        /// 绘制小墙(半个) 横着绘制
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <param name="img"></param>
        /// <param name="notMovethingList"></param>
        private void CreateHalfWallRow(int x, int y, int count, Image img, List<NotMovething> notMovethingList, drawCallType type = drawCallType.UP)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 30;
            if(type == drawCallType.UP)
            {
            }
            if(type == drawCallType.DOWN)
            {
                yPosition += 15;
            }

            // 一个格子(墙) 由四个图片组成
            for (int i = xPosition; i < xPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(i, yPosition, img);
                notMovethingList.Add(wallLeft);
            }
        }

        /// <summary>
        /// 绘制小墙(半个) 竖着绘制
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <param name="img"></param>
        /// <param name="notMovethingList"></param>
        private void CreateHalfWallCol(int x, int y, int count, Image img, List<NotMovething> notMovethingList, drawCallType type = drawCallType.LEFT)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 30;
            if(type == drawCallType.LEFT)
            {
            }
            if(type == drawCallType.RIGHT)
            {
                xPosition += 15;
            }

            // 一个格子(墙) 由四个图片组成
            for (int i = yPosition; i < yPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(xPosition, i, img);
                notMovethingList.Add(wallLeft);
            }
        }

        /// <summary>
        /// 绘制小墙(半个) 竖着绘制
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <param name="img"></param>
        /// <param name="notMovethingList"></param>
        private void CreateQuarterWallCol(int x, int y, int count, Image img, List<NotMovething> notMovethingList, drawCallType type = drawCallType.UP, drawCallType type2 = drawCallType.LEFT)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 15;
            if((type == drawCallType.UP && type2 == drawCallType.LEFT) || (type == drawCallType.LEFT && type2 == drawCallType.UP))
            {
            }
            if ((type == drawCallType.UP && type2 == drawCallType.RIGHT) || (type == drawCallType.RIGHT && type2 == drawCallType.UP))
            {
                xPosition += 15;
            }
            if ((type == drawCallType.DOWN && type2 == drawCallType.LEFT) || (type == drawCallType.LEFT && type2 == drawCallType.DOWN))
            {
                yPosition += 15;
            }
            if ((type == drawCallType.DOWN && type2 == drawCallType.RIGHT) || (type == drawCallType.RIGHT && type2 == drawCallType.DOWN))
            {
                xPosition += 15;
                yPosition += 15;
            }


            // 一个格子(墙) 由四个图片组成
            for (int i = xPosition; i < xPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(i, yPosition, img);
                notMovethingList.Add(wallLeft);
            }
        }

        /// <summary>
        /// 绘制小墙(半个) 横着绘制
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <param name="img"></param>
        /// <param name="notMovethingList"></param>
        private void CreateQuarterWallRow(int x, int y, int count, Image img, List<NotMovething> notMovethingList, drawCallType type = drawCallType.UP, drawCallType type2 = drawCallType.LEFT)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 15;
            if ((type == drawCallType.UP && type2 == drawCallType.LEFT) || (type == drawCallType.LEFT && type2 == drawCallType.UP))
            {
            }
            if ((type == drawCallType.UP && type2 == drawCallType.RIGHT) || (type == drawCallType.RIGHT && type2 == drawCallType.UP))
            {
                xPosition += 15;
            }
            if ((type == drawCallType.DOWN && type2 == drawCallType.LEFT) || (type == drawCallType.LEFT && type2 == drawCallType.DOWN))
            {
                yPosition += 15;
            }
            if ((type == drawCallType.DOWN && type2 == drawCallType.RIGHT) || (type == drawCallType.RIGHT && type2 == drawCallType.DOWN))
            {
                xPosition += 15;
                yPosition += 15;
            }


            // 一个格子(墙) 由四个图片组成
            for (int i = yPosition; i < yPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(xPosition, i, img);
                notMovethingList.Add(wallLeft);
            }
        }


        /// <summary>
        /// rectangle 是否和墙发生了碰撞
        /// </summary>
        /// <returns></returns>
        public static NotMovething IsCollideWall(Rectangle rectangle)
        {
            foreach (var wall in wallList)
            {
                if (wall.GetRectangle().IntersectsWith(rectangle))
                {
                    return wall;
                }
            }

            return null;
        }

        /// <summary>
        /// rectangle 是否和钢铁墙发生了碰撞
        /// </summary>
        /// <returns></returns>
        public static NotMovething IsCollideSteelWall(Rectangle rectangle)
        {
            foreach (var steel in steelList)
            {
                if (steel.GetRectangle().IntersectsWith(rectangle))
                {
                    return steel;
                }
            }

            return null;
        }

        /// <summary>
        /// rectangle 是否和Boss发生了碰撞
        /// </summary>
        /// <returns></returns>
        public static NotMovething IsCollideBossTank(Rectangle rectangle)
        {
            foreach (var boss in bossList)
            {
                if (boss.GetRectangle().IntersectsWith(rectangle))
                {
                    return boss;
                }
            }

            return null;
        }

        /// <summary>
        /// rectangle 是否和敌方坦克发生了碰撞
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static EnemyTank IsCollideEnemyTank(Rectangle rectangle)
        {
            foreach(var tank in enemyTankList)
            {
                if(tank.GetRectangle().IntersectsWith(rectangle))
                {
                    return tank;
                }
            }

            return null;
        }

        /// <summary>
        /// rectangle 是否和我的坦克发生了碰撞
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static MyTank IsCollideMyTank(Rectangle rectangle)
        {
            if(myTank.GetRectangle().IntersectsWith(rectangle))
            {
                return myTank;
            }

            return null;
        }
    }
}
