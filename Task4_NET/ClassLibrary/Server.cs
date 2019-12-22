using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Server class
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Delegate for methods with signature void(string)
        /// </summary>
        /// <param name="message"></param>
        public delegate void MessageFromClient(string message);

        /// <summary>
        /// Event on message from client
        /// </summary>
        public event MessageFromClient OnMessageFromClient;

        /// <summary>
        /// Instance of TcpListener class
        /// </summary>
        private readonly TcpListener ServerTCP;

        /// <summary>
        /// Port of server
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Host name of server
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Server()
        {
            Port = 8888;
            HostName = "127.0.0.1";
            ServerTCP = new TcpListener(IPAddress.Parse(HostName), Port);
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="port"></param>
        /// <param name="hostName"></param>
        public Server(int port, string hostName)
        {
            Port = port;
            HostName = hostName;
            ServerTCP = new TcpListener(IPAddress.Parse(HostName), Port);
        }

        /// <summary>
        /// Method to start server
        /// </summary>
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
                    catch
                    {
                        stream.Close();
                        client.Close();
                    }
                });

                task.Start();
            }
        }

        /// <summary>
        /// Method for receiving message from client
        /// </summary>
        /// <param name="stream"></param>
        public void ReceiveMessageFromClient(NetworkStream stream)
        {
            byte[] receivedBytes = new byte[1024];

            int bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length);

            string receivedString = Encoding.Unicode.GetString(receivedBytes, 0, bytesCount);

            OnMessageFromClient?.Invoke(receivedString);
        }

        /// <summary>
        /// Method for sanding message to client
        /// </summary>
        /// <param name="stream"></param>
        public void SendMessageToClient(NetworkStream stream)
        {
            string sendString = "Your message has been successfully delivered";

            byte[] sendBytes = Encoding.Unicode.GetBytes(sendString);

            stream.Write(sendBytes, 0, sendBytes.Length);
        }

        /// <summary>
        /// Method to stop server
        /// </summary>
        public void StopServer()
        {
            ServerTCP.Stop();
        }
    }
}
