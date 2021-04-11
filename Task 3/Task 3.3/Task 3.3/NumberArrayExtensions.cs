using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3
{
    static class NumberArrayExtensions
    {
        public static void AllElement<T>(this T[] arr, Func<T, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }
        #region Sum Number
        public static int Sum(this int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
                sum += numbers[i];
            return sum;
        }
        public static short Sum(this short[] numbers)
        {
            short sum = 0;
            for (short i = 0; i < numbers.Length; i++)
                sum += numbers[i];
            return sum;
        }
        public static float Sum(this float[] numbers)
        {
            float sum = 0;
            for (int i = 0; i < numbers.Length; i++)
                sum += numbers[i];
            return sum;
        }
        public static double Sum(this double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
                sum += numbers[i];
            return sum;
        }
        #endregion
        #region Average
        public static int Average(this int[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }
        public static short Average(this short[] numbers)
        {
            return (short)(numbers.Sum() / numbers.Length);
        }
        public static float Average(this float[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }
        public static double Average(this double[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }
        #endregion

        public static T MostRepeat<T>(this IEnumerable<T> numbers)
        {
            var group =  numbers.GroupBy(number => number);

            return group.OrderBy ( number=> number.Count()).First().Key;

        }

    }
}
