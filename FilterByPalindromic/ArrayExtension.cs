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
            bool IsPalindromicNumber(int number)
            {
                if (number < 0)
                {
                    return false;
                }

                int digitnum = (int)Math.Log10(number) + 1;
                int zeronum = (int)Math.Pow(10, digitnum - 1);
                return IsPalindromicNumberLocalFun();
                bool IsPalindromicNumberLocalFun()
                {
                    if (number < 10 & number >= 0)
                    {
                        return true;
                    }
                    else if (number % 10 == number / zeronum)
                    {
                        number = number % (int)Math.Pow(10, digitnum - 1);
                        number /= 10;
                        digitnum -= 2;
                        zeronum /= 100;
                        return IsPalindromicNumberLocalFun();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (source == null)
            {
                throw new ArgumentNullException("array is null.");
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
    }
}
