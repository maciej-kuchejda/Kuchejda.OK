namespace Kuchejda.Exercise3
{
    internal class CsvReader
    {
        public int[,] ReturnFromFile(string path)
        {
            var input = File
                .ReadAllLines("./input.csv")
                .Select(x=> x.Split(";"))
                .ToArray();

            var length = input.GetLength(0);

            int[,] dst = new int[length, length];

            for (int i = 0; i < length; ++i)
                for (int j = 0; j < length; ++j)
                    dst[i, j] = int.Parse(input[i][j]);

            return dst;
        }
    }
}
