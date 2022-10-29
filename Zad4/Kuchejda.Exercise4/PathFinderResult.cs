using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.Exercise4
{
    public static class PathFinderResult
    {
        public static void InitializeWithDefault()
        {
            ShortestPathReequiredSteps = int.MaxValue;
            Results = 0;
        }
        public static int ShortestPathReequiredSteps = int.MaxValue;
        public static int Results = 0;
    }
}
