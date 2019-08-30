using System.IO;

namespace webSocket
{
    public class FileSystem
    {
        public bool FileExistsCheck(string physicalPath)
        {
            if (File.Exists(physicalPath))
                return true;
            else
                return false;
        }
    }
}
