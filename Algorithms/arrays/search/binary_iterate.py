def binary(arr, target):
    first = 0
    last = len(arr) - 1

    while(first <= last):
        middle = first + (last - first) // 2

        if arr[middle] == target:
            return True
        elif arr[middle] > target:
            last = middle - 1
        else:
            first = middle + 1

    return False
