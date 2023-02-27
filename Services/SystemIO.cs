using SmartCard_API.Interfaces;
using System.IO.MemoryMappedFiles;

namespace SmartCard_API.Services
{
    public class SystemIO : ISystemIO
    {
        public bool IsFileExist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }



    }
}
