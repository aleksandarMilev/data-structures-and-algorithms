def solve(parantheses):
    '''
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

    An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.

    Example 1:
    Input: s = "()"
    Output: true

    Example 2:
    Input: s =
    Output: true

    Example 3:
    Input: s = "(]"
    Output: false

    Example 4:
    Input: s = ""
    Output: true

    Constraints:
    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.
    '''
    length = len(parantheses)
    if length == 0 or length % 2 != 0:
        return False
    
    seen = []
    close_to_open = {
        ")": "(",
        "}": "{",
        "]": "["
    }
    
    for p in parantheses:
        if p in close_to_open.values():
            seen.append(p)
        elif p in close_to_open:
            if not seen or seen.pop() != close_to_open[p]:
                return False
        else:
            raise ValueError("Invalid input!")
        
    return not seen 
            
print(solve("()")) # true
print(solve("()[]{}")) # true
print(solve("(]")) # false
print(solve("([])")) # true
