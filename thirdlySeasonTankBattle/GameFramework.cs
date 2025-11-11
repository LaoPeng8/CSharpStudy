using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Manager;

namespace thirdlySeasonTankBattle
{
    internal class GameFramework
    {

        public static Graphics graphics;
        private GameObjectManager gameObjectManager = new GameObjectManager();

        /// <summary>
        /// 游戏开始时调用一次
        /// </summary>
        public void Start()
        {
            gameObjectManager.CreateMap();
            gameObjectManager.CreateMyTank();
        }

        /// <summary>
        /// 开始后页面是不断刷新的, 线程在不断执行时就需要不断调用Update()来刷新页面
        /// 
        /// 也就是FPS
        /// 60FPS 即一秒调用60次 Update();
        /// </summary>
        public void Update()
        {
            gameObjectManager.Update();
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
