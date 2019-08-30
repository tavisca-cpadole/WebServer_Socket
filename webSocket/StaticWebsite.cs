using System.Net.Sockets;

namespace webSocket
{
    public class StaticWebsite : IWebsite
    {
        public void Handle(Genrator responseGenrate, Socket clientSocket, string path)
        {

            string header = Parser.HTTPVersion + " 200 OK";
            responseGenrate.ResponseGenrator(path, clientSocket,header);
        }
    }
}
