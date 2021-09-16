using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch is null || rangeEnd is null || rangeStart is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument is null");
            }

            for (int i = 0; i <= rangeStart.Length - 1; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("rangeStart is more than rangeEnd");
                }
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Argument trouble.", nameof(rangeStart));
            }

            float[] arrayToSearchOneZero = new float[arrayToSearch.Length];
            for (int index = 0; index < arrayToSearchOneZero.Length; index++)
            {
                arrayToSearchOneZero[index] = 0;
            }

            int count = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        arrayToSearchOneZero[i] = 1;
                    }
                }
            }

            for (int index = 0; index < arrayToSearchOneZero.Length; index++)
            {
                if (arrayToSearchOneZero[index] == 1)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null || rangeEnd is null || rangeStart is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument is null");
            }

            for (int i = 0; i <= rangeStart.Length - 1; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("rangeStart is more than rangeEnd");
                }
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Argument trouble.", nameof(rangeStart));
            }

            int finalIndex = startIndex + count;
            if (startIndex < 0 || startIndex > arrayToSearch.Length || count < 0 || finalIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Argument is out fo range");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            float[] arrayToSearchOneZero = new float[arrayToSearch.Length];
            int index = 0;
            do
            {
                arrayToSearchOneZero[index] = 0;
                index++;
            }
            while (index < arrayToSearch.Length);

            int counter = 0;
            do
            {
                int i = 0;
                do
                {
                    if (arrayToSearch[startIndex] >= rangeStart[i] && arrayToSearch[startIndex] <= rangeEnd[i])
                    {
                        arrayToSearchOneZero[startIndex] = 1;
                    }

                    i++;
                }
                while (i < rangeStart.Length);
                startIndex++;
            }
            while (startIndex < finalIndex);

            int indexCheck = 0;
            do
            {
                if (arrayToSearchOneZero[indexCheck] == 1)
                {
                    counter++;
                }

                indexCheck++;
            }
            while (indexCheck < arrayToSearchOneZero.Length);
            return counter;
        }
    }
}
