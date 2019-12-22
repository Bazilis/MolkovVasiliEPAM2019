using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class ClientEventHandler
    {
        public string MessageFromServer { get; private set; }

        readonly Dictionary<char, string> dictionary = new Dictionary<char, string>
        {
            {'а', "a"},  {'б', "b"},  {'в', "v"},   {'г', "g"},  {'д', "d"},  {'е', "e"},
            {'ё', "e"},  {'ж', "zh"}, {'з', "z"},   {'и', "i"},  {'й', "y"},  {'к', "k"},
            {'л', "l"},  {'м', "m"},  {'н', "n"},   {'о', "o"},  {'п', "p"},  {'р', "r"},
            {'с', "s"},  {'т', "t"},  {'у', "u"},   {'ф', "f"},  {'х', "kh"}, {'ц', "ts"},
            {'ч', "ch"}, {'ш', "sh"}, {'щ', "sch"}, {'ь', ""},   {'ы', "y"},  {'ъ', ""},
            {'э', "e"},  {'ю', "yu"}, {'я', "ya"}
        };

        public ClientEventHandler(Client client)
        {
            client.OnMessageFromServer += delegate (string message)
            {
                MessageFromServer = "";

                string workString = message.ToLower();

                foreach (char letter in workString)
                {
                    if ((letter >= 'а') && (letter <= 'я'))
                        MessageFromServer += dictionary[letter];

                    else MessageFromServer += letter;
                }
            };
        }
    }
}
