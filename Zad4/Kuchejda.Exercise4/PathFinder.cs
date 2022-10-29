namespace Kuchejda.Exercise4
{
    public class PathFinder
    {
        public void Resolve(char [,] input)
        {
            var length = input.GetLength(0);

            NextStep(input, 0, 0, 0, length);
        }

        private void NextStep(char[,] input, int i, int j,int currentPath, int length)
        {
            var @char = input[i, j];

            if (@char == '.')
            {
                currentPath += 1;
                SetResult(i, j, currentPath, length);
                Check(input, i + 1, j, currentPath, length);
                Check(input, i , j + 1, currentPath, length);
            }
            else
            {
                return;
            }
        }

        private void SetResult(int v, int j,int currentPath, int length)
        {
            if (v == length-1 && length-1 == j)
            {
                PathFinderResult.Results += 1;
            }
        }

        private void Check(char[,] input, int v, int j, int currentPath, int length)
        {
            if (v >= length || j >= length)
                return;

            NextStep(input, v, j, currentPath, length);
        }
    }
}
