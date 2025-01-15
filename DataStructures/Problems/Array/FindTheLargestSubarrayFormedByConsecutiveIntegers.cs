namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class FindTheLargestSubarrayFormedByConsecutiveIntegers
    {
        public static void Solve()
        {
            var nums = Console
                .ReadLine()
                !.Split(", ")
                .Select(int.Parse)
                .ToArray();

            FindSubarray(nums);
        }

        private static void FindSubarray(int[] nums)
        {
            var maxSubarrayLength = 0;
            var maxSubarrayStartIndex = 0;
            var maxSubarrayEndIndex = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                var seenElements = new HashSet<int>();

                var currentMin = nums[start];
                var currentMax = nums[start];

                for (var end = start; end < nums.Length; end++)
                {
                    if (seenElements.Contains(nums[end]))
                    {
                        break;
                    }

                    seenElements.Add(nums[end]);

                    currentMin = Math.Min(currentMin, nums[end]);
                    currentMax = Math.Max(currentMax, nums[end]);

                    if (currentMax - currentMin == end - start)
                    {
                        var currentSubarrayLength = end - start + 1;

                        if (currentSubarrayLength > maxSubarrayLength)
                        {
                            maxSubarrayLength = currentSubarrayLength;
                            maxSubarrayStartIndex = start;
                            maxSubarrayEndIndex = end;
                        }
                    }
                }
            }

            Console.Write("Largest subarray is [ ");

            for (int i = maxSubarrayStartIndex; i <= maxSubarrayEndIndex; i++)
            {
                Console.Write(nums[i] + ", ");
            }

            Console.Write("]");
        }

    }
}
