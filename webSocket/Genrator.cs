using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace webSocket
{
    public class Genrator
    {
        public void ResponseGenrator(string page, Socket response,string header)
        {
            string mimetype = "";
            if (File.Exists(page))
            {
                mimetype = MimeTypes.GetMIMEType(page);
               // Console.WriteLine(page+" "+mimetype);
                TextReader tr = new StreamReader(page);
                page = tr.ReadToEnd();
                tr.Close();
            }
            else
            {
                mimetype = "application/json";
            }


            StringBuilder responseHeader = new StringBuilder();
            responseHeader.AppendLine(Parser.HTTPVersion+" 200 OK");
            //responseHeader.AppendLine("HTTP/1.1 200 OK");
            responseHeader.AppendLine("Connection:close");
            //responseHeader.AppendLine("Content-Length:"+ responseByte.Length);
            //Console.WriteLine(page);
            responseHeader.AppendLine("Content-Type: "+mimetype+ ";charset=UTF-8");
            responseHeader.AppendLine();
            //header=header+"\nContent-Type: text/html; charset=UTF-8";
            //page = header+"\n"+headerd+"\n" + page;

            //Console.WriteLine(header);
            //byte[] buffer = Encoding.ASCII.GetBytes(page);

            List<byte> response_message = new List<byte>();
            response_message.AddRange(Encoding.UTF8.GetBytes(responseHeader.ToString()));
            response_message.AddRange(Encoding.UTF8.GetBytes(page));
            byte[] responseByte = response_message.ToArray();

          
            //string msg="HTTP/1.1 200 OK\nHello, World!";
            //byte[] message = Encoding.ASCII.GetBytes(msg);

            //// Send a message to Client  
            //// using Send() method 
            response.Send(responseByte);
                
            //response.Shutdown(SocketShutdown.Send);
            response.Shutdown(SocketShutdown.Both);
            response.Close();
            //response.Dispose();
        }

    }
}
