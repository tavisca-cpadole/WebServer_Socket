using System.Net;
using System.Net.Sockets;

namespace webSocket
{
    public class SocketSetup
    {
        public Socket GetSocket()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 5997);

            Socket listener = new Socket(AddressFamily.InterNetwork,
                         SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);

            listener.Listen(10);

            return listener;
        }
    }
}
