using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Client
    {
        public delegate void MessageFromServer(string message);
        public event MessageFromServer OnMessageFromServer;

        public string ClientName { get; private set; }

        public int Port { get; private set; }

        public string HostName { get; private set; }

        private TcpClient ClientTCP { get; set; }

        private NetworkStream Stream { get; set; }

        public Client(string clientName)
        {
            ClientName = clientName;
            Port = 8888;
            HostName = "127.0.0.1";
            ClientTCP = new TcpClient();
        }

        public Client(string clientName, int port, string hostName)
        {
            ClientName = clientName;
            Port = port;
            HostName = hostName;
            ClientTCP = new TcpClient();
        }

        public void Connect()
        {
            ClientTCP.Connect(IPAddress.Parse(HostName), Port);

            Stream = ClientTCP.GetStream();
        }

        public void SendMessageToServer(string message)
        {
            string sendString = ClientName + ">" + message;

            byte[] sendBytes = Encoding.Unicode.GetBytes(sendString);

            Stream.Write(sendBytes, 0, sendBytes.Length);
        }

        public void ReceiveMessageFromServer(NetworkStream stream)
        {
            byte[] receivedBytes = new byte[1024];

            int bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length);

            string receivedString = Encoding.Unicode.GetString(receivedBytes, 0, bytesCount);

            OnMessageFromServer?.Invoke(receivedString);
        }
    }
}
