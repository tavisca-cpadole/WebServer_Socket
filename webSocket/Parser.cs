using System;

namespace webSocket
{
    public class Parser
    {
        public string BasePath { get; private set; }
        public string LocalPath { get; private set; }

        public string HTTPType { get; private set; }

        public string RequestData { get; private set; }

        public static string HTTPVersion { get; set; }
        private string[] requestarr;
        public Parser(string request)
        {
            requestarr = request.Split("\n");   
            URLParser();
        }
        
        public void URLParser()
        {
            //foreach (var item in requestarr)
            //    Console.WriteLine(item);
            try
            {
                BasePath = (requestarr[1].Split(" "))[1].Trim();
                LocalPath = (requestarr[0].Split(" "))[1].Trim();
                HTTPType = (requestarr[0].Split(" "))[0];
                HTTPVersion = (requestarr[0].Split(" "))[2].Trim();
            }
            catch { }
        }

        public string ApiParser()
        {
            return LocalPath.Replace("/api/", "");
        }

        public string GetRequestData()
        {
            for (int i=11;i<requestarr.Length;i++)
            {
                RequestData += requestarr[i];
            }
            return RequestData;
        }
    }
}
