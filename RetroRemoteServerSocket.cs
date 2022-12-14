using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RetroRemoteServer
{
    internal class ServerSocket
    {

        private TcpListener Listener;
        private TcpClient? sender;

        public ServerSocket(String Address, int Port)
        {
            Listener = new TcpListener(new IPEndPoint(IPAddress.Parse(Address), Port));
            Listener.Start();
        }

        public void Accept()
        {

            sender = Listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
        }


        public void Close()
        {
            if (sender != null) sender.Close();
            Listener.Stop();
            
        }

        public void SendMessage(String msg)
        {
            if (sender == null) return;

            var bytes = Encoding.ASCII.GetBytes(msg);

            var stream = sender.GetStream();

            stream.Write(bytes);
            stream.FlushAsync();

            //if (handler == null)
            //{
            //    return;
            //}

            //handler.Send(Encoding.ASCII.GetBytes(msg));
        }
    }
}
