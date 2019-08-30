using System;
using System.Net.Sockets;

namespace webSocket
{
    public class DynamicWebsite : IWebsite
    {
        public void Handle(Genrator responseGenrate, Socket clientSocket, string path)
        {
            throw new NotImplementedException();
        }
    }
}
