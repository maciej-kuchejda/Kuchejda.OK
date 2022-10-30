using System.Numerics;

namespace Kuchejda.Exercise4
{
    public class PathFinder
    {
        public void Resolve(char [,] input)
        {
            var length = input.GetLength(0);

            var @array = new BigInteger[length, length];
            var res = NumberOfPaths(0, 0, array, input);

            PathFinderResult.Results = res;
        }
        private BigInteger NumberOfPaths(int n, int m, BigInteger[,] DP, char[,] chars)
        {
            int length = chars.GetLength(0);

            if (n == length - 1 && m == length-1)
                return DP[n, m] = 1;


            if (DP[n, m] == 0 && chars[n, m] != '*')
            {
                BigInteger first = 0; BigInteger second = 0;
                if (n < length - 1)
                    first = chars[n + 1, m] == '*' ? 0 : NumberOfPaths(n + 1, m, DP, chars);
                if (m < length - 1)
                    second = chars[n, m + 1] == '*' ? 0 : NumberOfPaths(n, m + 1, DP, chars);
                DP[n, m] = first + second;
            }

            return DP[n, m];
        }
    }
}
