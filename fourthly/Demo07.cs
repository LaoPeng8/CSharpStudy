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

    }
}
