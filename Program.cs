using adventofcode20.Solvers;
using System;

namespace adventofcode20
{
    class Program
    {
        static bool TryGetSolverForDay(int day, out Solver solver) {
            var solverType = Type.GetType($"adventofcode20.Solvers.Day{day}");
            if (solverType != null && solverType.IsSubclassOf(typeof(Solvers.Solver))) {
                solver = (Solver)Activator.CreateInstance(solverType);
                return true;
            }
            solver = null;
            return false;
        }

        static void Main(string[] args)
        {
            if (args.Length == 0) {
                for (int i = 0; i < 25; i++)
                {
                    if (TryGetSolverForDay(i, out var solver)) {
                        solver.Solve();
                    }
                }
            }

            if (args.Length == 1) {
                if (TryGetSolverForDay(int.Parse(args[0]), out var solver)) {
                    solver.Solve();
                }
            }

        }
    }
}
