using System.Collections.Generic;

namespace adventofcode20.Utils.Iterools {
    public static class IterableExtensions {

        // TODO: Get all N-Element combinations!! How difficult is that? The result probably couldn't be tuple anymore,
        // would need to be an n-element array I think.

        // Get all 2-element combinations of the input
        public static IEnumerable<(T, T)> TwoCombinations<T>(this IEnumerable<T> source) {
            var firstIndex = 0;
            foreach (var firstItem in source)
            {
                var secondIndex = 0;
                foreach (var secondItem in source) {
                    if (secondIndex != firstIndex) {
                        yield return (firstItem, secondItem);
                    }
                    secondIndex++;
                }
                firstIndex ++;
            }
        }

        public static IEnumerable<(T, T, T)> ThreeCombinations<T>(this IEnumerable<T> source) {
            // First
            var firstIndex = 0;
            foreach (var firstItem in source) {

                // Second
                var secondIndex = 0;
                foreach (var secondItem in source) {

                    // Third
                    var thirdIndex = 0;
                    foreach (var thirdItem in source) {
                        if (secondIndex != firstIndex && secondIndex != thirdIndex && firstIndex != thirdIndex) {
                            yield return (firstItem, secondItem, thirdItem);
                        }
                    }
                    secondIndex++;
                }
                firstIndex ++;
            }
        }

        // private int[] SelectNewIndexes(int[] indexes, int maxValue) {
        //     int[] newIndexes = (int[])indexes.Clone();

        //     for (int i = 0; i < indexes.Length; i++)
        //     {
        //         if (newIndexes[i] < maxValue) {
        //             // TODO: this must be unique!
        //             newIndexes[i] += 1;
        //             break;
        //         }
        //         if (newIndexes[i] == maxValue) {
        //             // TODO: reset or something?
        //             continue;
        //         }

        //     }
        // }

        // public static IEnumerable<T[]> NCombinations<T>(this IEnumerable<T> source, int N) {
        //     int[] indexes = new int[N];
        //     T[] values = new T[N];

        //     values[0] = source[0];
        //     values[1] = source[1];
        //     values[2] = source[2];

        //     values[0] = source[0];
        //     values[1] = source[1];
        //     values[2] = source[3];

        //     while (true) {
        //         indexes = SelectNewIndexes(indexes);
        //     }

        //     // This is looking kind of recursive? e.g., to get the 3 combs you fix the first index and get the two combs

        //     for (int i = 0; i < N; i++)
        //     {
        //         indexes[i] = 0;
        //         foreach (var item in source) {

        //         }
        //     }
        // }

        public static IEnumerable<int> AsInts(this IEnumerable<string> source) {
            foreach (var item in source) {
                yield return int.Parse(item);
            }
        }
    }
}