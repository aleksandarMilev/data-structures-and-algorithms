def solve(nums, target):
    '''
    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.
    
    Example 1:
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

    Example 2:
    Input: nums = [3,2,4], target = 6
    Output: [1,2]
    
    Example 3:
    Input: nums = [3,3], target = 6
    Output: [0,1]
    '''
    seen = {}
    for i, num in enumerate(nums):
        complement = target - num
        if complement in seen:
            return [seen[complement], i]
        seen[num] = i
    
    raise ValueError("No solution!")

print(solve([2, 7, 11, 15], 9)) #[0, 1]
print(solve([3, 2, 4], 6)) #[1, 2]
print(solve([3, 3], 6)) #[0, 1]
        