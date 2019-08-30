using System.Net.Sockets;

namespace webSocket
{
    public interface IWebsite
    {
        void Handle(Genrator responseGenrate, Socket clientSocket, string path);
    }
}
