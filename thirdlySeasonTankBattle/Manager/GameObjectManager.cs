using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Entity;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Manager
{
    internal class GameObjectManager
    {

        private List<NotMovething> wallList = new List<NotMovething>();
        private List<NotMovething> steelList = new List<NotMovething>();
        private List<NotMovething> bossList = new List<NotMovething>();

        public void DrawMap()
        {
            foreach (var wall in wallList)
            {
                wall.DrawSelf();
            }

            foreach (var steel in steelList)
            {
                steel.DrawSelf();
            }

            foreach (var boss in bossList)
            {
                boss.DrawSelf();
            }
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

    }
}
