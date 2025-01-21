namespace DataStructuresAndAlgorithms.Problems.Array
{
    using System;
    using System.Linq;

    public static class FindTheMaximumProductOfTwoIntegersInAnArray
    {
        public static void Solve()
        {
            var nums = Console
                .ReadLine()
                !.Split(", ")
                .Select(int.Parse)
                .ToArray();

            Solve(nums);
        }

        //(O(n log(n)))
        private static void Solve(int[] nums)
        {
            Array.Sort(nums);

            var firstTwoNumsProduct = nums[0] * nums[1];
            var lastTwoNumsProduct = nums[^1] * nums[^2];

            if (firstTwoNumsProduct >= lastTwoNumsProduct)
            {
                Console.WriteLine($"The maximum product is the ({nums[0]}, {nums[1]})");
            }
            else 
            {
                Console.WriteLine($"The maximum product is the ({nums[^1]}, {nums[^2]})");
            }
        }

        //O(n^2)
        private static void SolveQuadratic(int[] nums)
        {
            var maxProduct = int.MinValue;
            var maxMultiplicand = int.MinValue;
            var maxMultiplier = int.MinValue;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] * nums[j] > maxProduct)
                    {
                        maxProduct = nums[i] * nums[j];

                        maxMultiplicand = nums[i];
                        maxMultiplier = nums[j];
                    }
                }
            }

            Console.WriteLine($"The maximum product is the ({maxMultiplicand}, {maxMultiplier})");
        }

    }
}
