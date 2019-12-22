using System;
using System.Diagnostics;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ClientAndServerMethodsTests
    {
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

            Debug.WriteLine(serverEventHandler.ClientsMessages[clientName]);

            string resultString = serverEventHandler.ClientsMessages[clientName];

            server.StopServer();

            client.Disconnect();

            Assert.AreEqual(messageFromClient, resultString);
        }
    }
}
