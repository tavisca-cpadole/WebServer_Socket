using System.Collections.Generic;

namespace webSocket
{
    public class Dispatch
    {
        private Dictionary<string, string> applist = new Dictionary<string, string>()
        {
            { "http://localhost:5997","C:/Users/cpadole/Documents/localhost"},
            { "localhost:5997","C:/Users/cpadole/Documents/localhost"},
            { "error","C:/Users/cpadole/Documents/Error"}
        };

        public Dictionary<string, string> Applist { get => applist; }
    }
}
