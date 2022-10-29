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

            var pathList = new List<int[]>();
            int initialPath = 0;

            NextStep(input, 0, 0,initialPath, pathList, length);
        }

        private void NextStep(char[,] input, int i, int j,int currentPath, List<int[]> path, int length)
        {
            var @char = input[i, j];
            
            var pathFound = SetResult(i, j, currentPath, length);
            if (pathFound)
                return;

            if (@char == '.')
            {
                currentPath += 1;

                Check(input, i + 1, j, currentPath, path,  length, i , j);
                Check(input, i, j + 1, currentPath, path, length, i, j);
            }
            else
            {
                return;
            }
            var elem = path.SingleOrDefault(x => x[0] == i && x[1] == j);
            if (elem != null)
            {
                path.Remove(elem);
            }
        }

        private bool SetResult(int v, int j,int currentPath, int length)
        {
            var last = v == length - 1 && length - 1 == j;
            if (last)
            {
                PathFinderResult.ShortestPathReequiredSteps = currentPath;
                PathFinderResult.Results += 1;
                return true;
            }
            return false;
        }

        private void Check(char[,] input, int i, int j, int currentPath, List<int[]> path, int length, int orgI, int orgJ)
        {
            if (i >= length || j >= length || j < 0 || i < 0)
                return;
            var lastStep = path.SingleOrDefault(x=> x[0] == i && x[1] == j);
            if (lastStep != null)
            {
                return;
            }
            if (input[i, j] == '*')
                return;
            if (!path.Any(x=> x[0] == orgI && x[1] == orgJ))
                path.Add(new int[] { orgI, orgJ });

            NextStep(input, i, j,currentPath, path, length);
        }
    }
}
