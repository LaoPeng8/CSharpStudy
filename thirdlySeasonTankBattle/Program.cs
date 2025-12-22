using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * 第三季 坦克大战
 * https://www.bilibili.com/video/BV1kG41177Xx
 */
namespace thirdlySeasonTankBattle
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //测试窗口
            //Application.Run(new Test01());

            Application.Run(new Main());
        }
    }
}
