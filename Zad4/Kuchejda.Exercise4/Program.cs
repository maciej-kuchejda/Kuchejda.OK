using Kuchejda.Shared;
using System.Diagnostics;

namespace Kuchejda.Exercise4
{
    public class Program
    {
        public static void Main()
        {
            //https://github.com/maciej-kuchejda/Kuchejda.OK
            var path = "./input.txt";
            //initialize
            var fileReader = new FileReader();
            var pathFinder = new PathFinder();

            //ImportFromFile
            var @charArray = ReadAndResult(fileReader, path);

            //ResolveAndDisplayResults
            ResolveAndDisplay(charArray, pathFinder);
        }

        private static void ResolveAndDisplay(char[,] charArray, PathFinder pathFinder)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine($"Finding possible paths");
            pathFinder.Resolve(@charArray);
            watch.Stop();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Problem resolved!");
            Console.WriteLine($"Shortest paths: {PathFinderResult.ShortestPathReequiredSteps}");
            Console.WriteLine($"Possible paths: {PathFinderResult.Results}");
            Console.WriteLine($"Time spend {watch.Elapsed.Minutes}m:{watch.Elapsed.Seconds}s:{watch.Elapsed.Milliseconds}ms ");
            Console.WriteLine($"Elapsed ticks: {watch.Elapsed.Ticks}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static char[,] ReadAndResult(FileReader fileReader, string path)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine($"Importing from file {path}");
            var result = ReadFromFile(fileReader, path);
            watch.Stop();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Import success!");
            Console.WriteLine($"Time spend {watch.Elapsed.Minutes}m:{watch.Elapsed.Seconds}s:{watch.Elapsed.Milliseconds}ms ");
            Console.BackgroundColor = ConsoleColor.Black;
            return result;
        }

        private static char[,] ReadFromFile(FileReader fileReader, string path)
        {
            var lines = fileReader.Read(path);
            var length = lines.Length;

            var resultArray = new char[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    resultArray[i, j] = lines[i][j];
                }
            }

            return resultArray;
        }
    }
}
