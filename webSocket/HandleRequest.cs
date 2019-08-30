using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace webSocket
{
    public class HandleRequest
    {
        Genrator genrator = new Genrator();
        Dispatch dispatch = new Dispatch();
        WebsiteFactory websiteFactory = new WebsiteFactory();
        Error error = new Error();
        public void Request(Socket socket)
        {
            try
            {
                while (true)
                {
                    Socket clientSocket = socket.Accept();

                    // Data buffer 
                    byte[] bytes = new Byte[1024];
                    string data = null;
                    // Console.WriteLine(msg);



                    NetworkStream communicationChannel = new NetworkStream(clientSocket);
                    byte[] byteData = new byte[1024];
                    int byteDataCount = communicationChannel.Read(byteData, 0, byteData.Length);
                    string request = Encoding.ASCII.GetString(byteData, 0, byteDataCount);
                    //Console.WriteLine(request);
                    if (request.Trim().Length > 0)
                    {
                        //Console.WriteLine("Text received -> {0} ", request);
                        Parser parser = new Parser(request);
                        //Console.WriteLine(parser.LocalPath);
                        if (parser.LocalPath.Contains("/api/"))
                        {
                            RESApi method = new RESApi();

                            string methodName = method.GetMethod(parser.HTTPType, parser.ApiParser());

                            if (methodName != "No Such Method")
                            {
                                //Console.WriteLine(methodName);
                                APIOperation aPIOperation = new APIOperation();
                                var cleaned_data = parser.GetRequestData();
                                JObject jsonObj = JObject.Parse(cleaned_data);
                                Dictionary<string, string> dictObj = jsonObj.ToObject<Dictionary<string, string>>();
                                foreach (var item in dictObj)
                                {
                                    data += item.Value;
                                }
                                var output = aPIOperation.GetType().GetMethod(methodName).Invoke(aPIOperation, new object[] { data });
                                string header = Parser.HTTPVersion + " 200 OK";
                                genrator.ResponseGenrator(output.ToString(), clientSocket, header);
                            }
                        }


                        else
                        {

                            string page = dispatch.Applist[parser.BasePath] + parser.LocalPath;
                            //Console.WriteLine(page);
                            try
                            {
                                IWebsite website = websiteFactory.GetWebsite(page);
                                website.Handle(genrator, clientSocket, page);

                            }
                            catch
                            {
                                error.Error404NotFound(dispatch, genrator, clientSocket, page);
                            }
                        }
                    }


                    //clientSocket.Shutdown(SocketShutdown.Both);
                    //clientSocket.Close();


                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }

            
        }

        public void Response()
        {
        }
    }
}
