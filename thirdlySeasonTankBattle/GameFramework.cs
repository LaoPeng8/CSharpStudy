using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Manager;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle
{
    public enum GameStatus
    {
        Running = 0,
        GameOver = 1,
    }


    internal class GameFramework
    {

        public static Graphics graphics;
        private static GameStatus gameStatus = GameStatus.Running;
        private GameObjectManager gameObjectManager = new GameObjectManager();

        /// <summary>
        /// 游戏开始时调用一次
        /// </summary>
        public void Start()
        {
            GameSoundManager.PlayStart();
            gameObjectManager.CreateMap();
            gameObjectManager.CreateMyTank();
            gameObjectManager.CreateEnemyBornPoint();
        }

        /// <summary>
        /// 开始后页面是不断刷新的, 线程在不断执行时就需要不断调用Update()来刷新页面
        /// 
        /// 也就是FPS
        /// 60FPS 即一秒调用60次 Update();
        /// </summary>
        public void Update()
        {
            if (gameStatus == GameStatus.Running)
            {
                gameObjectManager.Update();
            }
            else if (gameStatus == GameStatus.GameOver)
            {
                GameOver();
            }
        }

        public static void ChangeToGameOver()
        {
            gameStatus = GameStatus.GameOver;
        }

        public void GameOver()
        {
            // 窗体的一半宽度 450/2 - 图片的一半宽度 Width / 2, 等于图片左上角的坐标
            int x = 450 / 2 - Resources.GameOver.Width / 2;
            int y = 450 / 2 - Resources.GameOver.Height / 2;
            graphics.DrawImage(Resources.GameOver, x, y);
        }

        public void KeyDown(KeyEventArgs args)
        {
            gameObjectManager.KeyDown(args);

        }

        public void KeyUp(KeyEventArgs args)
        {
            gameObjectManager.KeyUp(args);
        }
    }
}
