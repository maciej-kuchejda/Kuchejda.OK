namespace Kuchejda.Shared
{
    public class FileReader
    {
        public string[] Read(string path)
        {
            var lines = File.ReadAllLines(path);

            return lines;
        }
    }
}
