using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle
{
    /// <summary>
    /// 绘制直线
    /// 绘制字符串
    /// </summary>
    public partial class Test01 : Form
    {
        public Test01()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Paint事件
        /// 当窗体被重新绘制时调用 (窗体第一次绘制时也会调用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test01_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();

            Pen pen = new Pen(Color.Blue);// Color.FromArgb(255,255,255)
            graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));

            graphics.DrawString("好好生活", new Font("Airal", 20f), new SolidBrush(Color.Black), new Point(100, 105));

            Bitmap boss = Resources.Boss;
            boss.MakeTransparent(Color.Black);// 使指定颜色的像素设置为完全透明, 此处是将图片的黑色背景变为透明 (必须是与参数的颜色完全一致)
            graphics.DrawImage(boss, 200, 200);

        }
    }
}
