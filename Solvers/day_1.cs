using System;
using adventofcode20.Utils;
using adventofcode20.Utils.Iterools;

namespace adventofcode20.Solvers
{
    public class Day1 : Solver {
        public Day1() : base(1) {}

        public override string SolvePartOne()
        {
            foreach (var (firstItem, secondItem) in _input.AsInts().TwoCombinations())
            {
                if (firstItem + secondItem == 2020) {
                    return (firstItem*secondItem).ToString();
                }
            }

            return "No answer found!";
        }

        public override string SolvePartTwo() {
            foreach (var (first, second, third) in _input.AsInts().ThreeCombinations()) {
                if (first+second+third == 2020) {
                    return (first*second*third).ToString();
                }
            }
            return "No answer found!";
        }
    }
}