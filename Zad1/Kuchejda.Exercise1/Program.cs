// See https://aka.ms/new-console-template for more information
using java.io;
using org.sat4j.core;
using org.sat4j.pb;
using org.sat4j.reader;
using org.sat4j.specs;

int MAXVAR = 1000000;
int NBCLAUSES = 500000;

IPBSolver solver = SolverFactory.newDefault();

// prepare the solver to accept MAXVAR variables. MANDATORY for MAXSAT solving
solver.newVar(MAXVAR);
solver.setExpectedNumberOfClauses(NBCLAUSES);
// Feed the solver using Dimacs format, using arrays of int
// (best option to avoid dependencies on SAT4J IVecInt)
for (int i = 0; i < NBCLAUSES; i++)
{
    int[] clause = new int[] { 1, -3, 7 }; 
    solver.addClause(new VecInt(clause)); 
}

// we are done. Working now on the IProblem interface
IProblem problem = solver;
if (problem.isSatisfiable())
{

}
else
{
}
System.Console.ReadLine();