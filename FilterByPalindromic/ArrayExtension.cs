using System;

namespace FilterByPalindromicTask
{
    /// <summary>
    /// Provides static method for working with integers array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
        public static int[] FilterByPalindromic(int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array is null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty.");
            }

            List<int> result = new List<int>();
            foreach (int num in source)
            {
                if (IsPalindromicNumber(num))
                {
                    result.Add(num);
                }
            }

            return result.ToArray();
        }

        private static int GetNumberOfDigits(int a) => a switch
        {
            < 10 => 1,
            < 100 => 2,
            < 1000 => 3,
            < 10000 => 4,
            < 100000 => 5,
            < 1000000 => 6,
            < 10000000 => 7,
            < 100000000 => 8,
            < 1000000000 => 9,
            _ => 10,
        };

        private static int GetNumberOfZeroes(int a) => a switch
        {
            2 => 10,
            3 => 100,
            4 => 1000,
            5 => 10000,
            6 => 100000,
            7 => 1000000,
            8 => 10000000,
            9 => 100000000,
            _ => 1000000000,
        };

        private static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                return false;
            }

            int digitnum = GetNumberOfDigits(number);
            while (digitnum > 1)
            {
                byte lustNum = (byte)(number % 10);
                byte firstNum = (byte)(number / GetNumberOfZeroes(digitnum));
                if (firstNum != lustNum)
                {
                    return false;
                }

                number /= 10;
                number = number % GetNumberOfZeroes(digitnum - 1);
                digitnum -= 2;
            }

            return true;
        }
    }
}
