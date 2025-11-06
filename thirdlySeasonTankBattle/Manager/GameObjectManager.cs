using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Entity;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Manager
{
    internal class GameObjectManager
    {

        private static List<NotMovething> wallList = new List<NotMovething>();

        public void DrawMap()
        {

        }

        /// <summary>
        /// 创建地图
        /// </summary>
        public void CreateMap()
        {
            CreateWall(1, 1, 5);
        }

        /// <summary>
        /// 绘制墙, 从一个点(x,y), 绘制 count 个墙 (竖着绘制)
        /// 此处 x,y 不是像素, 而是第几个格子, 一个格子是30*30, 目前创建窗口是 宽高各15个格子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private void CreateWall(int x, int y, int count)
        {
            // 将 格子坐标, 转为实际的像素坐标
            int xPosition = x * 30;
            int yPosition = y * 30;
            count = count * 30;

            // 一个格子(墙) 由四个图片组成
            for (int i = yPosition; i < yPosition + count; i += 15)
            {
                NotMovething wallLeft = new NotMovething(xPosition, i, Resources.wall);
                NotMovething wallRight = new NotMovething(xPosition + 16, i, Resources.wall);

                wallList.Add(wallLeft);
                wallList.Add(wallRight);
            }
        }

    }
}
