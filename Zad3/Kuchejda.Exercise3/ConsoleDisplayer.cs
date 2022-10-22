using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.Exercise3
{
    public class ConsoleDisplayer
    {
        public void Display(int[,] input)
        {
            var size = input.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{input[i, j]} ");

                }
                Console.WriteLine();
            }
        }
    }
}
