using Kuchejda.Exercise3;
using System.Diagnostics;

// Array is imported from csv file. For the uknown value is set 0 
// Result is save in csv and display in console
// link to repository: https://github.com/maciej-kuchejda/Kuchejda.OK

int cellSize = 3;
if (args.Any())
    cellSize = int.Parse(args[0]);

CsvReader reader = new CsvReader();
CsvUpdater updater = new CsvUpdater();
MatrixResolver matrixResolver = new MatrixResolver();
ConsoleDisplayer consoleDisplayer = new ConsoleDisplayer();
Stopwatch GeneralStopWatch = Stopwatch.StartNew();

string inputFile = "./input.csv";
string outputFile = "./output.csv";
//Downloading matrix from csv file
Console.WriteLine($"Reading from file: {inputFile}");
var input = reader.ReturnFromFile("./input.csv");
Console.WriteLine($"Reading from file: {inputFile} => done");
//Display on console
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Input array:");
consoleDisplayer.Display(input);
Console.BackgroundColor = ConsoleColor.Black;

//Resolving
Stopwatch resolverStopWatch = Stopwatch.StartNew();
Console.WriteLine("Resolving problem... StopWatch Started");
matrixResolver.Resolve(input, cellSize);
resolverStopWatch.Stop();
Console.WriteLine($"Resolved problem => StopWatch Ended => ElapsedTime (in ms): {resolverStopWatch.ElapsedMilliseconds}");

//Save result to file
Console.WriteLine($"SaveResult to output file: {outputFile}");
updater.SaveToFile(input, outputFile);
Console.WriteLine($"SavedResult to output file: {outputFile}");
GeneralStopWatch.Stop();

//Display result on console
Console.BackgroundColor = ConsoleColor.Green;
Console.WriteLine("Result array:");
consoleDisplayer.Display(input);
Console.BackgroundColor = ConsoleColor.Black;

Console.WriteLine($"All done => ElapsedTime (in ms): {GeneralStopWatch.ElapsedMilliseconds}");