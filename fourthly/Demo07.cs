using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace fourthlySeason
{
    /// <summary>
    /// 文件操作
    /// </summary>
    internal class Demo07
    {
        /// <summary>
        /// FileInfo类(实例方法)与之对应的File类(静态方法)
        /// 
        /// 文件
        /// </summary>
        public void Test01()
        {
            FileInfo fileInfo = new FileInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋.txt");
            fileInfo.CopyTo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋_copy.txt", true);// 默认不能覆盖已存在文件, true即可覆盖

            //file/寒窑赋_copy.txt 这个相对路径给我干哪去了, 干到了编译后的Dubug目录下去了
            //File.Copy("file/寒窑赋_copy.txt", "file/寒窑赋_copy_copy.txt");

            string destPath = "D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋_copy.txt";
            string targetPath = "D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋_copy_copy.txt";
            File.Copy(destPath, targetPath, true);
        }

        /// <summary>
        /// DirectoryInfo类(实例方法)与之对应的Directory类(静态方法)
        /// 
        /// 目录
        /// </summary>
        public void Test02()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file");
            if (!directoryInfo.Exists)// 目录不存在则创建
            {
                directoryInfo.Create();
            }
            if(directoryInfo.Exists)// 目录存在则删除
            {
                //directoryInfo.Delete();
            }

            // 目录不存在则创建
            bool file2Exisits = Directory.Exists("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file2");
            if(!file2Exisits)
            {
                Directory.CreateDirectory("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file2");
            }

        }

        /// <summary>
        /// FileInfo 和 DirectoryInfo 的部分属性
        /// 
        /// 文件创建时间: 2025/12/7 23:13:37
        /// 文件的完整路径: D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\file\寒窑赋.txt
        /// 目录完整路径: D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\file
        /// 文件的后缀: .txt
        /// 最后一次访问文件的时间: 2025/12/7 23:17:24
        /// 最后一次修改文件的时间: 2025/12/7 23:17:24
        /// 文件的大小(字节) : 1518
        /// ================
        /// 目录的创建时间: 2025/12/7 23:12:40
        /// 目录的完成路径: D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\file
        /// 目录的父目录: D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly
        /// 最后一次访问目录的时间: 2025/12/7 23:54:22
        /// 最后一次修改目录的时间: 2025/12/7 23:34:47
        /// 目录的根部分: D:\
        /// </summary>
        public void Test03()
        {
            FileInfo fileInfo = new FileInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋.txt");
            Console.WriteLine("文件创建时间: " + fileInfo.CreationTime);
            Console.WriteLine("文件的完整路径: " + fileInfo.FullName);
            Console.WriteLine("目录完整路径: " + fileInfo.DirectoryName);
            Console.WriteLine("文件的后缀: " + fileInfo.Extension);// 目录调用该属性则为空
            Console.WriteLine("最后一次访问文件的时间: " + fileInfo.LastAccessTime);
            Console.WriteLine("最后一次修改文件的时间: " + fileInfo.LastWriteTime);
            Console.WriteLine("文件的大小(字节): " + fileInfo.Length);


            Console.WriteLine("================");
            DirectoryInfo directoryInfo = new DirectoryInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file");
            Console.WriteLine("目录的创建时间: " + directoryInfo.CreationTime);
            Console.WriteLine("目录的完成路径: " + directoryInfo.FullName);
            Console.WriteLine("目录的父目录: " + directoryInfo.Parent.FullName);
            Console.WriteLine("最后一次访问目录的时间: " + directoryInfo.LastAccessTime);
            Console.WriteLine("最后一次修改目录的时间: " + directoryInfo.LastWriteTime);
            Console.WriteLine("目录的根部分: " + directoryInfo.Root);
        }

        /// <summary>
        /// FileInfo 和 DirectoryInfo 的部分方法
        /// </summary>
        public void Test04()
        {
            FileInfo fileInfo = new FileInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋.txt");
            //fileInfo.Create();// 创建给定名称的空文件, 返回一个FileStream方便写入文件
            //fileInfo.Delete();// 删除文件
            //fileInfo.MoveTo();// 移动文件 或 重命名文件
            //fileInfo.CopyTo();// 复制文件


            DirectoryInfo directoryInfo = new DirectoryInfo("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file");
            //directoryInfo.Create();// 创建给定名称的目录, 无返回值
            //directoryInfo.Delete();// 删除目录
            //directoryInfo.MoveTo();// 移动目录 或 重命名目录
            // 目录没有复制目录的方法, 如果需要复制完整的目录树, 需要单独复制每个文件和目录
            //directoryInfo.GetDirectories();// 返回 DirectoryInfo[] 包含该目录下的所有子目录
            //directoryInfo.GetFiles();// 返回 FileInfop[] 包含该目录中的所有文件
            //directoryInfo.GetFileSystemInfos();// 返回 FileSystemInfo[] 包含该目录下的所有目录 和 文件
        }

        /// <summary>
        /// Path类
        /// </summary>
        public void Test05()
        {
            // Path.Combine 会自动处理 windows上的 \ 和 linux上的 /
            string pathStr = Path.Combine("D:", "eatMeal", "CSharp", "CSharpProject", "CSharpStudy", "fourthly", "file", "寒窑赋.txt");
            Console.WriteLine(pathStr);// D:\eatMeal\CSharp\CSharpProject\CSharpStudy\fourthly\file\寒窑赋.txt

            // Path.AltDirectorySeparatorChar 在windows上就是 \ 在linux就是 /
            string pathStr2 = "D:" + Path.AltDirectorySeparatorChar + "eatMeal" + Path.AltDirectorySeparatorChar;
            Console.WriteLine(pathStr2);// D:/eatMeal/

            // 提供一种与平台无关的方式, 来指定划分环境变量的路径字符串, 默认为分号. (如果没有记错, windows和linux环境变量都是分号吧)
            Console.WriteLine(Path.PathSeparator);// ;

            // 提供一种与平台无关的方式, 来指定容量分割符, 默认为冒号 (这不知道是符号)
            Console.WriteLine(Path.VolumeSeparatorChar);// :
        }


        /// <summary>
        /// File Read
        /// </summary>
        public void Test06()
        {
            // 不设置编码或者设置Encoding.UTF8 直接读直接乱码了, Encoding中又没有GBK的枚举, 只能 Encdoing.GetEncoding("GBK")
            // 
            // Encdoing.GetEncoding("GBK") 直接抛异常了, 百度说是.NET Core 默认不支持 GBK 编码, 需要安装包 System.Text.Encoding.CodePages
            // System.ArgumentException:“'gbk' is not a supported encoding name. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method. (Parameter 'name')”
            // 那我只能先找一个 UTF8编码的文件来读了
            string textAll = File.ReadAllText("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋utf8.txt", Encoding.UTF8);
            //Console.WriteLine(textAll);

            // 读取全部的行 (打印发现, 换行符也读取到了并且打印了出来)
            string[] textLines = File.ReadAllLines("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋utf8.txt", Encoding.UTF8);
            //foreach(string itemLine in textLines)
            //{
            //    Console.WriteLine(itemLine);
            //}

            // 读取全部的行, 返回的迭代器
            IEnumerable<string> enumerable = File.ReadLines("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋utf8.txt", Encoding.UTF8);
            //foreach (string itemLine in enumerable)
            //{
            //    Console.WriteLine(itemLine);
            //}

            // 读取全部内容, 得到一个字节数组
            byte[] bytes = File.ReadAllBytes("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋utf8.txt");
            string bytesToString = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(bytesToString);
        }


        /// <summary>
        /// File Write
        /// </summary>
        public void Test07()
        {
            // 写入文件
            string strWrite = "豫章故郡，洪都新府。星分翼轸，地接衡庐。襟三江而带五湖，控蛮荆而引瓯越。物华天宝，龙光射牛斗之墟；人杰地灵，徐孺下陈蕃之榻。雄州雾列，俊采星驰。台隍枕夷夏之交，宾主尽东南之美。都督阎公之雅望，棨戟遥临；宇文新州之懿范，襜帷暂驻。十旬休假，胜友如云；千里逢迎，高朋满座。腾蛟起凤，孟学士之词宗；紫电青霜，王将军之武库。家君作宰，路出名区；童子何知，躬逢胜饯。";
            string filePath = "D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/寒窑赋_copy.txt";
            string filePathNew = "D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/滕王阁序1.txt";
            //File.WriteAllText(filePath, strWrite, Encoding.UTF8);// 会覆盖原类容
            //File.Move(filePath, filePathNew);

            // 以数组的方式写入多行
            string filePathNew2 = "D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/滕王阁序2.txt";
            String[] fileContentStrings = new String[] { "时维九月，序属三秋。", "潦水尽而寒潭清，烟光凝而暮山紫。俨骖𬴂于上路，访风景于崇阿。临帝子之长洲，得天人之旧馆。", "层峦耸翠，上出重霄；飞阁流丹，下临无地。鹤汀凫渚，穷岛屿之萦回；桂殿兰宫，即冈峦之体势。" };
            File.WriteAllLines(filePathNew2, fileContentStrings, Encoding.UTF8);
        }
    }
}
