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

        private int sleepTime = 1000 / 60;// 绘制一帧后的等待时间, 控制帧率
        private Thread gameMainThread = null;
        private bool gameIsFinish = false;
        private GameFramework gameFramework = new GameFramework();
        private Bitmap tempBitmap = null;// 临时图片
        private Graphics mainWindowGraphics = null;// 主窗口画布

        public Main()
        {
            InitializeComponent();// 窗口中的一些控件的初始化
            this.StartPosition = FormStartPosition.CenterScreen;

            // 创建一个图片, 转为画布赋值给 GameFramework.graphics, 之后就在这个画布上直接绘制
            tempBitmap = new Bitmap(450, 450);
            Graphics bmpGraphics = Graphics.FromImage(tempBitmap);
            GameFramework.graphics = bmpGraphics;

            mainWindowGraphics = this.CreateGraphics();// 获取到画布 (获取到本窗口得画布)

            // 窗口启动后, 运行游戏的主线程
            gameMainThread = new Thread(new ThreadStart(GameMainThread));
            gameMainThread.Start();
        }

        // 游戏主线程
        public void GameMainThread()
        {
            gameFramework.Start();// 在临时画布上绘制
            while(!gameIsFinish)
            {
                GameFramework.graphics.Clear(Color.Black);

                gameFramework.Update();// 在临时画布上绘制, 相当于绘制图片
                mainWindowGraphics.DrawImage(tempBitmap, 0, 0);// 将已经绘制好得图片刷入主画布(将当前帧完全绘制好后,再绘制到主画布, 避免直接在主画布上先绘制墙, 再绘制子弹等, 有先后顺序, 主窗口会闪烁)
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
