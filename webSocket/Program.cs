using Newtonsoft.Json;
using System.Collections.Generic;

namespace webSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketSetup socketSetup = new SocketSetup();

            HandleRequest handle = new HandleRequest();

            handle.Request(socketSetup.GetSocket());
        }

    }

    //status code
     public class StatusCodes
    {
        Dictionary<string, string> satuslist = new Dictionary<string, string>()
        {
            {"200","OK" },
            { "404","Not Found"}
        };

        public Dictionary<string, string> Satuslist { get => satuslist; }
    }
}
