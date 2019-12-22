using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Server
    {
        public delegate void MessageFromClient(string message);
        public event MessageFromClient OnMessageFromClient;

        private readonly TcpListener ServerTCP;

        public int Port { get; private set; }

        public string HostName { get; private set; }

        public Server()
        {
            Port = 8888;
            HostName = "127.0.0.1";
            ServerTCP = new TcpListener(IPAddress.Parse(HostName), Port);
        }

        public Server(int port, string hostName)
        {
            Port = port;
            HostName = hostName;
            ServerTCP = new TcpListener(IPAddress.Parse(HostName), Port);
        }

        public void StartServer()
        {
            ServerTCP.Start();

            while (true)
            {
                TcpClient client = ServerTCP.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                Task task = new Task(() =>
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
                });

                task.Start();
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

        public void StopServer()
        {
            ServerTCP.Stop();
        }
    }
}
