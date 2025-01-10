namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Given an unsorted integer array, find a pair with the given sum in it.
    /// </summary>
    /// <remarks>
    /// For example:
    /// Input: nums = [8, 7, 2, 5, 3, 1], target = 10
    /// Output: Pair found(8, 2) or Pair found(7, 3)
    /// 
    /// Input: nums = [5, 2, 6, 8, 1, 9], target = 12
    /// Output: Pair not found
    /// </remarks>
    public static class FindPairWithGivenSumInAnArray
    {
        public static void Solve()
        {
            var numbers = Console
                .ReadLine()!
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine()!);

            FindPair(numbers, target);
        }

        //O(n)
        //iterate over each num in the array
        //find the diff between the target and the current num
        //if map contains the diff as key, we found a pair: diff + current = target
        //else add the current index with key the current number in the map
        private static void FindPair(int[] numbers, int target)
        {
            var isPairFound = false;
            var map = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var current = numbers[i];
                var diff = target - current;

                if (map.ContainsKey(diff))
                {
                    isPairFound = true;
                    Console.WriteLine($"Pair found({diff}, {current})");
                }
                else
                {
                    map[numbers[i]] = i;
                }
            }

            if (!isPairFound)
            {
                Console.WriteLine("Pair not found");
            }
        }

        //O(n^2)
        private static void FindPairQuadratic(int[] numbers, int target)
        {
            var pairIsFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var num1 = numbers[i];
                    var num2 = numbers[j];

                    if (num1 + num2 == target)
                    {
                        pairIsFound = true;
                        Console.WriteLine($"Pair found({num1}, {num2})");
                    }
                }
            }

            if (!pairIsFound)
            {
                Console.WriteLine("Pair not found");
            }
        }

        //O(n log(n))
        private static void FindPairLinearithmic(int[] numbers, int target)
        {
            Array.Sort(numbers);

            var pairIsFound = false;
            var low = 0;
            var high = numbers.Length - 1;

            while (low < high)
            {
                var num1 = numbers[low];
                var num2 = numbers[high];
                var result = num1 + num2;

                if (result == target)
                {
                    pairIsFound = true;
                    Console.WriteLine($"Pair found({num1}, {num2})");
                }

                if (result < target)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            if (!pairIsFound)
            {
                Console.WriteLine("Pair not found");
            }
        }
    }
}
