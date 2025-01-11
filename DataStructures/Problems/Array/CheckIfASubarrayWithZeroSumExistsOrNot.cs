namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Given an integer array, check if it contains a subarray having zero-sum.
    /// For example:
    /// Input: { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 }
    /// Output: true
    /// </summary>
    public static class CheckIfASubarrayWithZeroSumExistsOrNot
    {
        public static void Solve()
        {
            var numbers = Console
                .ReadLine()
                !.Split(", ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(CheckForSubarraysWithZeroSum(numbers));
        }

        // O(n) time complexity solution
        // Initialize a running sum and an empty set to keep track of prefix sums
        // Iterate through the array
        // Add the current number to the running sum
        // If the sum becomes 0 at any point, return true (subarray from the start sums to zero)
        // The key idea:
        // If the current sum already exists in the set, it means there’s a subarray that sums to zero. Here's why:
        // When the same sum appears twice, the subarray between those two occurrences must sum to zero,
        // because the total sum hasn’t changed, meaning the elements in between canceled each other out.
        private static bool CheckForSubarraysWithZeroSum(int[] numbers)
        {
            var sum = 0;
            var set = new HashSet<int>();

            foreach (var number in numbers)
            {
                sum += number;

                if (set.Contains(sum) || sum == 0)
                {
                    return true;
                }

                set.Add(sum);
            }

            return false;
        }
    }
}
