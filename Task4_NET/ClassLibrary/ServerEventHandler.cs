using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class ServerEventHandler
    {
        public Dictionary<string, string> ClientsMessages { get; private set; }

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
