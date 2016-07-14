using System.IO;

namespace Atlas.Files
{
    public class FileLoader
    {
        public static bool TryLoadFile(string fileName, out string content)
        {
            try
            {
                content = File.ReadAllText(fileName);
                return true;
            }
            catch
            {
                content = string.Empty;
                return false;
            }
        }
    }
}
