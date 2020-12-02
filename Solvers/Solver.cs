using System;
using System.Text;
using System.IO;
using System.Linq;

namespace adventofcode20.Solvers {
    public class Solver {
        protected string[] _input;
        protected int _day;
        protected int _part;

        public Solver(int day) {
            _day = day;
            _input = ReadInput(day);
        }

        static string[] ReadInput(int day) {
            return File.ReadAllLines($"input/day_{day}.txt");
        }

        public void Solve() {
            Console.WriteLine($"Day {_day}");
            Console.WriteLine($"  Part 1: {SolvePartOne()}");
            Console.WriteLine($"  Part 2: {SolvePartTwo()}");
        }

        public virtual string SolvePartOne() {
            return "(Not Solved)";
        }

        public virtual string SolvePartTwo() {
            return "(Not Solved)";
        }

        public void PrintInput() {
            foreach (var item in _input)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}