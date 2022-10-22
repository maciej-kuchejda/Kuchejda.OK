namespace Kuchejda.Exercise3
{
    internal class CsvUpdater
    {
        public void SaveToFile(int[,] array, string filePath)
        {
            using (var sw = new StreamWriter("output.csv"))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        var endOfLineChar = ";";
                        if (j == array.GetLength(1) - 1)
                        {
                            endOfLineChar = String.Empty;
                        }
                        sw.Write($"{array[i, j]}{endOfLineChar}");
                    }
                    sw.Write("\n");
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
