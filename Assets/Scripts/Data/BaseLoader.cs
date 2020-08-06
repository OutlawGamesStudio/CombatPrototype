using System.IO;

namespace ForgottenLegends.Data
{
    public abstract class BaseLoader
    {
        public static string LoadFile(string fileName)
        {
            if (!File.Exists(fileName) || Path.GetExtension(fileName) != ".json")
            {
                return string.Empty;
            }

            return File.ReadAllText(fileName);
        }
    }
}
