namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Linq;

    public static class SortBinaryArrayInLinearTime
    {
        public static void Solve()
        {
            var numbers = Console
                .ReadLine()
                !.Split(", ")
                .Select(int.Parse)
                .ToArray();

            Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Sort(int[] numbers)
        {
            var zerosCount = 0;

            foreach (var number in numbers)
            {
                if (number == 0)
                {
                    zerosCount++;
                }
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                if (i < zerosCount)
                {
                    numbers[i] = 0;
                }
                else
                {
                    numbers[i] = 1;
                }
            }
        }
    }
}
