using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrencies.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<decimal?[][]> Chunk(this decimal?[][] array, int chunkSize)
        {
            for (int i = 0; i < array?.Length; i += chunkSize)
            {
                yield return array.Skip(i).Take(chunkSize).ToArray();
            }
        }

        public static decimal?[] MaxBy(this decimal?[][] input, Func<decimal?[], decimal?> selector)
        {
            var maxRow = input[0];
            var maxValue = selector(maxRow);

            for (int i = 1; i < input.Length; i++)
            {
                decimal?[] currentRow = input[i];
                var currentValue = selector(currentRow);

                if (currentValue > maxValue)
                {
                    maxRow = currentRow;
                    maxValue = currentValue;
                }
            }

            return maxRow;
        }

        public static decimal?[] MinBy(this decimal?[][] input, Func<decimal?[], decimal?> selector)
        {
            var minRow = input[0];
            var minValue = selector(minRow);

            for (int i = 1; i < input.Length; i++)
            {
                decimal?[] currentRow = input[i];
                var currentValue = selector(currentRow);

                if (currentValue < minValue)
                {
                    minRow = currentRow;
                    minValue = currentValue;
                }
            }

            return minRow;
        }
    }
}
