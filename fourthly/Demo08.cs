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
         * Socket Server Tcp
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
         * Socket Client Tcp
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


        /**
         * Socket Server Upd
         */
        public void TestUpdServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iPEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8080);
            server.Bind(iPEndPoint);// 绑定IP,端口

            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiveBytes = new byte[1024 * 1024];// 1M
            int len = server.ReceiveFrom(receiveBytes, ref endPoint);
            //int len2 = server.Receive(receiveBytes);// 没有发送者信息

            if(len > 0)
            {
                IPEndPoint sender = (IPEndPoint)endPoint;
                Console.WriteLine($"接收到{sender.Address.ToString()}:{sender.Port}发来的消息: {Encoding.UTF8.GetString(receiveBytes, 0, len)}");
                Thread.Sleep(1000 * 30);// 不知道为什么消息后框直接没了, 我知道了正常来说执行完了框没了才是正常的, 框还在只是通过VisualStudio启动时被VisualSudio加了参数的应该
            }

        }

        public void TestUpdClient()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string sendMessage = "哈喽啊服务端, 我是发送消息的人, 我叫客户端";
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendMessage);
            EndPoint serverAddress = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8080);
            client.SendTo(sendBytes, serverAddress);
            Console.WriteLine("我发送了消息不知道你收到没有...");
        }
    }
}
