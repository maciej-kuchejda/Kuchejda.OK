using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.Exercise4
{
    public class PathFinder
    {
        public void Resolve(char [,] input)
        {
            var length = input.GetLength(0);

            NextStep(input, 0, 0, 0,true, length);
        }

        private void NextStep(char[,] input, int i, int j,int currentPath, bool goUp, int length)
        {
            var @char = input[i, j];
            var isShorter = CheckResult(currentPath);

            if (@char == '.' && !isShorter)
            {
                currentPath += 1;
                SetResult(i, j, currentPath, length);
                if (goUp)
                {
                    Check(input, i + 1, j, currentPath, goUp, length);
                    Check(input, i, j + 1, currentPath, goUp, length);
                }
                else
                {
                    Check(input, i - 1, j, currentPath, goUp, length);
                    Check(input, i, j - 1, currentPath, goUp, length);
                }
            }
            else
            {
                goUp = !goUp;
                return;
            }
        }

        private bool CheckResult(int currentPath)
        {
            var shortestPath = PathFinderResult.ShortestPathReequiredSteps;
            return shortestPath < currentPath;
        }

        private void SetResult(int v, int j,int currentPath, int length)
        {
            if (v == length-1 && length-1 == j)
            {
                PathFinderResult.ShortestPathReequiredSteps = currentPath;
                PathFinderResult.Results += 1;
            }
        }

        private void Check(char[,] input, int v, int j, int currentPath, bool goUp, int length)
        {
            if (v >= length || j >= length)
                return;

            NextStep(input, v, j, currentPath, goUp, length);
        }
    }
}
