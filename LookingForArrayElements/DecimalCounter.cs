using System;

#pragma warning disable S2368

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null || ranges is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument is null");
            }

            foreach (decimal[] array in ranges)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(ranges), "Argument is null");
                }
            }

            for (int i = 0; i < ranges.GetLength(0); i++)
            {
                if (ranges[i].Length != 2 && ranges[i].Length != 0)
                {
                    throw new ArgumentException("Length is not 2.");
                }
            }

            decimal[] arrayToSearchOneZero = new decimal[arrayToSearch.Length];
            int count = 0;
            for (int j = 0; j < arrayToSearch.Length; j++)
            {
                arrayToSearchOneZero[j] = 0;
                for (int x = 0; x < ranges.GetLength(0); x++)
                {
                    if (ranges[x].Length != 0 && arrayToSearch[j] >= ranges[x][0] && arrayToSearch[j] <= ranges[x][1] && arrayToSearchOneZero[j] == 0)
                    {
                        arrayToSearchOneZero[j] = 1;
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null || ranges is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Is null");
            }

            foreach (decimal[] array in ranges)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int i = 0; i < ranges.GetLength(0); i++)
            {
                if (ranges[i].Length != 2 && ranges[i].Length != 0)
                {
                    throw new ArgumentException("Length is not 2.");
                }
            }

            int finalIndex = startIndex + count;
            if (startIndex < 0 || startIndex > arrayToSearch.Length || count < 0 || finalIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Argument is out fo range");
            }

            decimal[] arrayToSearchOneZero = new decimal[arrayToSearch.Length];
            int counter = 0;
            for (int j = startIndex; j < finalIndex; j++)
            {
                arrayToSearchOneZero[j] = 0;
                for (int x = 0; x < ranges.GetLength(0); x++)
                {
                    if (ranges[x].Length != 0 && arrayToSearch[j] >= ranges[x][0] && arrayToSearch[j] <= ranges[x][1] && arrayToSearchOneZero[j] == 0)
                    {
                        arrayToSearchOneZero[j] = 1;
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
