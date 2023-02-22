using SmartCard_API.Interfaces;

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
