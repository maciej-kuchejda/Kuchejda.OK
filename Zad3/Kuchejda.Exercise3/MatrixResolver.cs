using Google.OrTools.LinearSolver;

namespace Kuchejda.Exercise3
{
    public class MatrixResolver
    {
        public int[,] Resolve(int[,] input, int cellSize)
        {
            var gridSize = input.GetLength(0);

            Solver solver = new Solver("Exercise3-number8", Solver.OptimizationProblemType.CBC_MIXED_INTEGER_PROGRAMMING);

            var variables = new Variable[gridSize, gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    for (int k = 0; k < gridSize; k++)
                        variables[i, j, k] = solver.MakeBoolVar($"var[{i},{j},{k}]");

            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                {
                    var defined = input[i, j];
                    if (defined != 0)
                        solver.Add(variables[i,j,input[i,j] -1] == 1);
                }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var sumVariables = new Variable[gridSize];
                    for (int k = 0; k < gridSize; k++)
                    {
                        sumVariables[k] = variables[i, j, k];
                    }
                    var expression = LinearExprArrayHelper.Sum(sumVariables) == 1;
                    solver.Add(expression);
                }
            }


            for (int k = 0; k < gridSize; k++)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    var sumVariables = new Variable[gridSize];
                    for (int j = 0; j < gridSize; j++)
                    {
                        sumVariables[j] = variables[i, j, k];
                    }
                    var expression = LinearExprArrayHelper.Sum(sumVariables) == 1;
                    solver.Add(expression);
                }

                for (int j = 0; j < gridSize; j++)
                {
                    var sumVariables = new Variable[gridSize];
                    for (int i = 0; i < gridSize; i++)
                    {
                        sumVariables[i] = variables[i, j, k];
                    }
                    var expression = LinearExprArrayHelper.Sum(sumVariables) == 1;
                    solver.Add(expression);
                }

                for (int rowIdx = 0; rowIdx < gridSize; rowIdx = rowIdx + cellSize)
                {
                    for (int colIdx = 0; colIdx < gridSize; colIdx = colIdx + cellSize)
                    {
                        var sumVariables = new List<Variable>();

                        for (int j = colIdx; j < colIdx + cellSize; j++)
                        {
                            for (int i = 0; i < cellSize; i++)
                            {
                                sumVariables.Add(variables[rowIdx + i, j, k]);
                            }
                        }

                        var expression = LinearExprArrayHelper.Sum(sumVariables.ToArray()) == 1;
                        solver.Add(expression);
                    }
                }
            }
            var solved = solver.Solve();

            if (solved != Solver.ResultStatus.OPTIMAL)
                throw new Exception("Solution not found, input file is invalid");

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var variablesToSum = new int[gridSize];
                    for (int k = 0; k < gridSize; k++)
                    {
                        var solutionValue = (int)variables[i, j, k].SolutionValue();
                        variablesToSum[k] = (k+1) * solutionValue;
                    }
                    input[i,j] = variablesToSum.Sum();
                }
            }

            return input;
        }
    }
}
