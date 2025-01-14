namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Linq;

    /// <summary>
    /// Find the duplicate element in a limited range array.
    /// Given a limited range array of size n containing elements between 1 and n-1 with one element repeating,
    /// 
    /// For example:
    /// Input:  { 1, 2, 3, 4, 4 }
    /// Output: The duplicate element is 4
    /// 
    /// Input:  { 1, 2, 3, 4, 2 }
    /// Output: The duplicate element is 2
    /// </summary>
    public static class FindTheDuplicateElementInALimitedRangeArray
    {
        public static void Solve()
        {
            var numbers = Console
                .ReadLine()!
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            FindDuplicate(numbers);
        }

        public static void FindDuplicate(int[] nums)
        {
            var duplicateIsFound = false;

            for (int i = 0; i < nums.Length; i++)
            {
                var current = Math.Abs(nums[i]);

                if (nums[current] >= 0)
                {
                    nums[current] = -nums[current];
                }
                else
                {
                    duplicateIsFound = true;
                    Console.WriteLine($"The duplicate element is {current}");

                    break;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    nums[i] = -nums[i];
                }
            }

            if (!duplicateIsFound)
            {
                Console.WriteLine("The array elements are unique!");
            }
        }
    }
}
