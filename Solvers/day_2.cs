using System;
using adventofcode20.Utils;
using System.Linq;

namespace adventofcode20.Solvers
{
    public class Day2 : Solver {
        public Day2() : base(2) {}

        public override string SolvePartOne()
        {
            var validPasswords = _input.Select(ParseLine).Count(PasswordValidPartOne);
            return validPasswords.ToString();
        }

        public override string SolvePartTwo()
        {
            var validPasswords = _input.Select(ParseLine).Count(PasswordValidPartTwo);
            return validPasswords.ToString();
        }

        private static (int lower, int upper, char letter, string password) ParseLine(string line) {
            // Example:
            // 14-15 b: zbbbtbfbbbbbbbl
            var min = line.Split("-")[0];
            var max = line.Split("-")[1].Split(" ")[0];
            var letter = line.Split(" ")[1].Split(":")[0];
            var password = line.Split(" ")[2].Trim();

            return (int.Parse(min), int.Parse(max), letter[0], password);
        }

        private bool PasswordValidPartOne((int lower, int upper, char letter, string password) line) {
            var letterCount = line.password.Count(letter => letter == line.letter);
            return (line.lower <= letterCount && letterCount <= line.upper);
        }

        private bool PasswordValidPartTwo((int lower, int upper, char letter, string password) line) {
            var letterOneMatches = LetterMatches(line.password, line.lower-1, line.letter);
            var letterTwoMatches = LetterMatches(line.password, line.upper-1, line.letter);

            return (letterOneMatches ^ letterTwoMatches);
        }

        private bool LetterMatches(string password, int loc, char letter) {
            if (password.Length < loc) {
                return false;
            }
            return password[loc] == letter;
        }

    }
}