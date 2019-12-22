using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Class for handling events in Server class
    /// </summary>
    public class ServerEventHandler
    {
        /// <summary>
        /// Dictionary for saving client-message pairs
        /// </summary>
        public Dictionary<string, string> ClientsMessages { get; private set; }

        /// <summary>
        /// Constructor with anonim method which split incoming messages on client-message pairs
        /// and saving to ClientsMessages dictionary
        /// </summary>
        /// <param name="server"></param>
        public ServerEventHandler(Server server)
        {
            server.OnMessageFromClient += delegate (string clientNameWithMessage)
            {
                string[] words = clientNameWithMessage.Split(new char[] { '>' });

                ClientsMessages.Add(words[0], words[1]);
            };
        }
    }
}
