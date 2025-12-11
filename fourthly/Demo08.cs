using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace fourthlySeason
{
    /**
     * 网络
     */
    internal class Demo08
    {


        /**
         * Socket Server
         */
        public void TestServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127,0,0,1 }), 8080);
            server.Bind(iPEndPoint);// 绑定IP,端口
            server.Listen(100);// 等待处理连接队列的最大长度

            Console.WriteLine("等待连接...");
            Socket client = server.Accept();// 阻塞, 等待连接
            Console.WriteLine("一个Client连接到Server...");

            byte[] receiveBytes = new byte[1024 * 1024];// 1M
            while(true)
            {
                int len = client.Receive(receiveBytes);// 接收字节数组, 返回长度
                Console.WriteLine("Server收到信息: " + Encoding.UTF8.GetString(receiveBytes, 0, len));
            }
        }


        /**
         * Socket Server
         */
        public void TestClient()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("准备连接...");
            IPEndPoint serverIPAndPort = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8080);
            client.Connect(serverIPAndPort);
            Console.WriteLine("连接成功...");

            client.Send(Encoding.UTF8.GetBytes("你好, 你在吗? 服务器"));
        }
    }
}
