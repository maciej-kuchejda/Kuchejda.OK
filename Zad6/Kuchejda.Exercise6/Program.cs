// See https://aka.ms/new-console-template for more information
using Microsoft.Z3;

//Zadanie 6 - wariant 8
//https://github.com/maciej-kuchejda/Kuchejda.OK
using (Context ctx = new Context(new Dictionary<string, string>() { { "model", "true" } }))
{
    Exercise(ctx);
}


static void Exercise(Context ctx)
{
    IntExpr zero = ctx.MkInt(0);

    IntExpr x1 = ctx.MkIntConst("x1");
    IntExpr x2 = ctx.MkIntConst("x3");
    IntExpr x3 = ctx.MkIntConst("x3");
    IntExpr x4 = ctx.MkIntConst("x4");
    IntExpr x5 = ctx.MkIntConst("x5");
    IntExpr x6 = ctx.MkInt(144);
    IntExpr x7 = ctx.MkIntConst("x7");

    Solver solver = ctx.MkSolver();

    solver.Assert(ctx.MkGt(x1, zero));
    solver.Assert(ctx.MkGt(x2, zero));
    solver.Assert(ctx.MkGt(x3, zero));
    solver.Assert(ctx.MkGt(x4, zero));
    solver.Assert(ctx.MkGt(x5, zero));

    solver.Assert(ctx.MkEq(x4, ctx.MkMul(x3, ctx.MkAdd(x2, x1))));
    solver.Assert(ctx.MkEq(x5, ctx.MkMul(x4, ctx.MkAdd(x3, x2))));
    solver.Assert(ctx.MkEq(x6, ctx.MkMul(x5, ctx.MkAdd(x4, x3))));
    solver.Assert(ctx.MkEq(x7, ctx.MkMul(x6, ctx.MkAdd(x5, x4))));

    var tmp = new List<IntExpr>() { x1,x2,x3,x4,x5,x6,x7};

    if (Status.SATISFIABLE == solver.Check())
    {
        var model = solver.Model;

        for (int i = 0; i < 7; i++)
        {
            Expr v = model.Evaluate(tmp[i]);
            if (v != null)
            {
                Console.WriteLine($"result x{i+1} = {v}");
            }
            else
            {
                Console.WriteLine("Failed to evaluate: x+y");
            }
        }
    }
}