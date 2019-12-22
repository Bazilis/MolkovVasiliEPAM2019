using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Server
    {
        public delegate void MessageFromClient(string message);
        public event MessageFromClient OnMessageFromClient;

        private static readonly TcpListener ServerTCP;

        public int Port { get; private set; }

        public string HostName { get; private set; }

        public void StartServer()
        {
            ServerTCP.Start();

            while (true)
            {
                TcpClient client = ServerTCP.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                new Thread(delegate ()
                {
                    try
                    {
                        ReceiveMessageFromClient(stream);
                        SendMessageToClient(stream);
                        stream.Close();
                        client.Close();
                    }
                    catch (Exception exception)
                    {
                        stream.Close();
                        client.Close();
                        throw new Exception(exception.ToString());
                    }
                }).Start();
            }
        }

        public void ReceiveMessageFromClient(NetworkStream stream)
        {
            byte[] receivedBytes = new byte[1024];

            int bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length);

            string receivedString = Encoding.Unicode.GetString(receivedBytes, 0, bytesCount);

            OnMessageFromClient?.Invoke(receivedString);
        }

        public void SendMessageToClient(NetworkStream stream)
        {
            string sendString = "Your message has been successfully delivered";

            byte[] sendBytes = Encoding.Unicode.GetBytes(sendString);

            stream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}
