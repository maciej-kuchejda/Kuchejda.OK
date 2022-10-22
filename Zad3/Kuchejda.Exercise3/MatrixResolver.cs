using Google.OrTools.ConstraintSolver;

namespace Kuchejda.Exercise3
{
    public class MatrixResolver
    {
        public int[,] Resolve(int[,] input, int cellSize)
        {
            var gridSize = input.GetLength(0);

            Solver solver = new Solver("Exercise3-number8");

            var variables = new IntVar[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    variables[i, j] = solver.MakeIntVar(1, gridSize, $"grid[{i},{j}]");

            for (int i = 0; i < gridSize; i++)
            {
                var row = new IntVar[gridSize];
                for (int j = 0; j < gridSize; j++)
                {
                    if (input[i, j] > 0)
                        solver.Add(solver.MakeEquality(variables[i, j], input[i, j]));

                    row[j] = variables[i, j];
                }
                solver.Add(IntVarArrayHelper.AllDifferent(row));
            }

            for (int j = 0; j < gridSize; j++)
            {
                var col = new IntVar[gridSize];
                for (int i = 0; i < gridSize; i++)
                {
                    col[i] = variables[i, j];
                }
                var constraint = IntVarArrayHelper.AllDifferent(col);
                solver.Add(constraint);
            }

            for (int i = 0; i < cellSize; i++)
            {
                for (int j = 0; j < cellSize; j++)
                {
                    var cell = new List<IntVar>();
                    for (int di = 0; di < cellSize; di++)
                    {
                        for (int dj = 0; dj < cellSize; dj++)
                        {
                            cell.Add(variables[i * cellSize + di, j * cellSize + dj]);
                        }
                    }
                    solver.Add(solver.MakeAllDifferent(cell.ToArray()));
                }
            }

            var db = solver.MakePhase(variables.Flatten(), Solver.INT_VAR_SIMPLE, Solver.INT_VALUE_SIMPLE);
            solver.NewSearch(db);
            var solution = solver.NextSolution();

            if (!solution)
                throw new Exception("Solution not found, input file is invalid");

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    input[i, j] = (int)variables[i, j].Value();
                }
            }

            solver.EndSearch();

            return input;
        }
    }
}
