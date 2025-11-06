using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thirdlySeasonTankBattle
{
    public partial class Main : Form
    {

        private static int sleepTime = 1000 / 60;// 绘制一帧后的等待时间, 控制帧率
        private Thread gameMainThread = null;
        private static bool gameIsFinish = false;

        public Main()
        {
            InitializeComponent();// 窗口中的一些控件的初始化
            this.StartPosition = FormStartPosition.CenterScreen;

            Graphics graphics = this.CreateGraphics();// 获取到画布
            GameFramework.graphics = graphics;

            // 窗口启动后, 允许游戏的主线程
            gameMainThread = new Thread(new ThreadStart(GameMainThread));
            gameMainThread.Start();
        }

        // 游戏主线程
        public static void GameMainThread()
        {
            GameFramework.Start();
            while(!gameIsFinish)
            {
                GameFramework.graphics.Clear(Color.Black);

                GameFramework.Update();
                Thread.Sleep(sleepTime);
            }
        }


        /// <summary>
        /// FormClosed事件
        /// 窗口被关闭后调用
        /// 
        /// 为什么这个方法能作为 FormCloased事件, 是如何在窗口被关闭后调用这个方法的
        /// 是因为在 Main.Designer.cs 的 InitializeComponent() 方法中 指定了 这个事件触发后调用的的方法
        /// this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameFinish);
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameFinish(object sender, FormClosedEventArgs e)
        {
            gameIsFinish = true;
        }
    }
}
