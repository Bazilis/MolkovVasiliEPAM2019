using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Delegate for methods with signature void(string)
        /// </summary>
        /// <param name="message"></param>
        public delegate void MessageFromServer(string message);

        /// <summary>
        /// Event on message from server
        /// </summary>
        public event MessageFromServer OnMessageFromServer;

        /// <summary>
        /// Client name property
        /// </summary>
        public string ClientName { get; private set; }

        /// <summary>
        /// Client port property
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Client host name property
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// TcpClient class instance
        /// </summary>
        private TcpClient ClientTCP { get; set; }

        /// <summary>
        /// NetworkStream class instance
        /// </summary>
        private NetworkStream Stream { get; set; }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="clientName"></param>
        public Client(string clientName)
        {
            ClientName = clientName;
            Port = 8888;
            HostName = "127.0.0.1";
            ClientTCP = new TcpClient();
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="port"></param>
        /// <param name="hostName"></param>
        public Client(string clientName, int port, string hostName)
        {
            ClientName = clientName;
            Port = port;
            HostName = hostName;
            ClientTCP = new TcpClient();
        }

        /// <summary>
        /// Connecting method
        /// </summary>
        public void Connect()
        {
            ClientTCP.Connect(IPAddress.Parse(HostName), Port);

            Stream = ClientTCP.GetStream();
        }

        /// <summary>
        /// Method for sending message to server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageToServer(string message)
        {
            string sendString = ClientName + ">" + message;

            byte[] sendBytes = Encoding.Unicode.GetBytes(sendString);

            Stream.Write(sendBytes, 0, sendBytes.Length);
        }

        /// <summary>
        /// Method for receiving message from server
        /// </summary>
        /// <param name="stream"></param>
        public void ReceiveMessageFromServer(NetworkStream stream)
        {
            byte[] receivedBytes = new byte[1024];

            int bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length);

            string receivedString = Encoding.Unicode.GetString(receivedBytes, 0, bytesCount);

            OnMessageFromServer?.Invoke(receivedString);
        }

        /// <summary>
        /// Disconnecting method
        /// </summary>
        public void Disconnect()
        {
            Stream.Close();

            ClientTCP.Close();
        }
    }
}
