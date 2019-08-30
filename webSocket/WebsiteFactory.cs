using System;
using System.IO;

namespace webSocket
{
    public class WebsiteFactory
    {
        public IWebsite GetWebsite(string path)
        {
            if (Directory.Exists(path))
            {
                return new DynamicWebsite();
            }
            else if (File.Exists(path))
            {
                return new StaticWebsite();
            }
            else
            {
                throw new NotImplementedException();
            }
        }


    }
}
