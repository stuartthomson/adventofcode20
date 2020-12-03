using System;

namespace adventofcode20.Solvers
{
    public struct SledgeState {
        public int X {get;}
        public int Y {get;}

        public SledgeState (int x, int y) {
            X = x;
            Y = y;
        }

        public bool Colliding(Forest forest)
            => forest.HasTree(X, Y);

        public SledgeState NextState(Func<SledgeState, SledgeState> slider)
            => slider(this);
    }

    public struct Forest {

        public int AcrossDim => _map.GetLength(0);
        public int DownDim => _map.GetLength(1);

        private char[,] _map;

        public Forest(char[,] map) {
            _map = map;
        }

        public bool HasTree(int across, int down)
            => _map[across%AcrossDim, down] == '#';

    }

    public class Day3 : Solver {
        private Forest _forest;

        public Day3() : base(3) {
            int downDim = _input.Length;
            int acrossDim = _input[0].Length;

            char[,] parsedInput = new char[acrossDim, downDim];

            for (int y = 0; y < downDim; y++) {
                for (int x = 0; x < acrossDim; x++) {
                    var val = _input[y][x];
                    parsedInput[x, y] = val;
                }
            }

            _forest = new Forest(parsedInput);
        }

        public override string SolvePartOne() {
            return CountCollisions(_forest, SliderFactory(3, 1)).ToString();
        }

        private int CountCollisions(Forest forest, Func<SledgeState, SledgeState> sliderFunc) {
            var numTreeCollisions = 0;
            var sledge = new SledgeState(0, 0);

            while (sledge.Y < forest.DownDim) {
                if (sledge.Colliding(forest)) {
                    numTreeCollisions++;
                }
                sledge = sledge.NextState(s => sliderFunc(s));
            }

            return numTreeCollisions;
        }

        private Func<SledgeState, SledgeState> SliderFactory(int xGradient, int yGradient)
            => s => new SledgeState(s.X + xGradient, s.Y + yGradient);

        public override string SolvePartTwo() {
            // Right 1, down 1.
            // Right 3, down 1. (This is the slope you already checked.)
            // Right 5, down 1.
            // Right 7, down 1.
            // Right 1, down 2.
            return (
                Convert.ToInt64(CountCollisions(_forest, SliderFactory(1, 1)))*
                Convert.ToInt64(CountCollisions(_forest, SliderFactory(3, 1)))*
                Convert.ToInt64(CountCollisions(_forest, SliderFactory(5, 1)))*
                Convert.ToInt64(CountCollisions(_forest, SliderFactory(7, 1)))*
                Convert.ToInt64(CountCollisions(_forest, SliderFactory(1, 2)))
            ).ToString();
        }

    }
}