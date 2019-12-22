using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Test class for Client and Server methods
    /// </summary>
    [TestClass]
    public class ClientAndServerMethodsTests
    {
        /// <summary>
        /// Test method for Client class SendMessageToServer() method
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="messageFromClient"></param>
        [DataTestMethod]
        [DataRow("Vasya", "My name is Vasya...")]
        [DataRow("Kolya", "Of course, I have horse...")]
        [DataRow("Petya", "London is the capital...")]
        public void SendMessageToServerTestMethod(string clientName, string messageFromClient)
        {
            Client client = new Client(clientName);

            Server server = new Server();

            ServerEventHandler serverEventHandler = new ServerEventHandler(server);

            server.StartServer();

            client.Connect();

            client.SendMessageToServer(messageFromClient);

            string resultString = serverEventHandler.ClientsMessages[clientName];

            server.StopServer();

            client.Disconnect();

            Assert.AreEqual(messageFromClient, resultString);
        }
    }
}
