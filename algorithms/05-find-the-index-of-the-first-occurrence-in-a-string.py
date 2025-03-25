def solve(haystack, needle):
    '''
    Given two strings needle and haystack,
    return the index of the first occurrence of needle in haystack,
    or -1 if needle is not part of haystack.

    Example 1:
    Input: haystack = "sadbutsad", needle = "sad"
    Output: 0
    Explanation: "sad" occurs at index 0 and 6.
    The first occurrence is at index 0, so we return 0.
    
    Example 2:
    Input: haystack = "leetcode", needle = "leeto"
    Output: -1
    Explanation: "leeto" did not occur in "leetcode", so we return -1.

    Constraints:
    1 <= haystack.length, needle.length <= 104
    haystack and needle consist of only lowercase English characters.
    '''
    haystack_len, needle_len = len(haystack), len(needle)
    
    for i in range(haystack_len - needle_len + 1):
        if haystack[i:i+needle_len] == needle:
            return i
        
    return -1

print(solve("sadbutsad", "sad")) #0
print(solve("leetcode", "leeto")) #-1