def binary(arr, target):
    return binary_recursive(sorted(arr), 0, len(arr) - 1, target)

def binary_recursive(arr, first, last, target):
    if first > last:
        return False

    middle = first + (last - first) // 2

    if arr[middle] == target:
        return True
    elif arr[middle] > target:
        return binary_recursive(arr, first, middle - 1, target)
    else:
        return binary_recursive(arr, middle + 1, last, target)
