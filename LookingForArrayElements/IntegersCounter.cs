using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            if (arrayToSearch is null || elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument is null");
            }

            int counter = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < elementsToSearchFor.Length; j++)
                {
                    if (arrayToSearch[i] == elementsToSearchFor[j])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch is null || elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument is null");
            }

            int counter = 0;
            int finalIndex = startIndex + count;
            if (startIndex < 0 || startIndex > arrayToSearch.Length || count < 0 || finalIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Argument is out fo range");
            }

            while (startIndex < finalIndex)
            {
                int i = 0;
                while (i < elementsToSearchFor.Length)
                {
                    if (arrayToSearch[startIndex] == elementsToSearchFor[i])
                    {
                        counter++;
                    }

                    i++;
                }

                startIndex++;
            }

            return counter;
        }
    }
}
