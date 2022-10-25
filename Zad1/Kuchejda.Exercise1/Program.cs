// See https://aka.ms/new-console-template for more information
using Google.OrTools.ConstraintSolver;

Solver solver = new Solver("Exercise1");

var input = new int[,]
{
    {0,0,0,0 },
    {0,0,1,1 },
    {0,1,0,0 },
    {0,1,0,0 },
};

var variables = new IntVar[input.GetLength(0)];
for (int i = 0; i < variables.Length; i++)
    variables[i] = solver.MakeIntVar(0, 1, $"{i}");

for (int i = 0; i < input.GetLength(0); i++)
{
    for (int j = 0; j < input.GetLength(1); j++)
    {
        solver.Add(solver.MakeLessOrEqual(variables[i] + input[i,j], 0));
    }
}


var db = solver.MakePhase(variables, Solver.INT_VAR_SIMPLE, Solver.INT_VALUE_SIMPLE);
solver.NewSearch(db);
var solution = solver.NextSolution();

if (!solution)
    throw new Exception("Solution not found, input file is invalid");



solver.EndSearch();
