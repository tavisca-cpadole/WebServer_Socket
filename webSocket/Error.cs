using System.Net.Sockets;

namespace webSocket
{
    public class Error
    {
        public void Error404NotFound(Dispatch dispatch, Genrator responseGenrate, Socket response,string path)
        {
            path = dispatch.Applist["error"] + "/404.html";
            string header = Parser.HTTPVersion + " 404 Not Found";
            responseGenrate.ResponseGenrator(path, response,header);
        }
    }
}
