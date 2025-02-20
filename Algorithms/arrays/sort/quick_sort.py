def quick_sort(arr):
    if len(arr) <= 1:
        return arr
    
    left = []
    middle = []
    right = []

    pivot = arr[len(arr) // 2]

    for el in arr:
        if el < pivot:
            left.append(el)
        elif el > pivot:
            right.append(el)
        else:
            middle.append(el)

    left_sorted = quick_sort(left)
    right_sorted = quick_sort(right)

    return left_sorted + middle + right_sorted

arr = [5, 1, 7, 9, 2, 4, 10, 6, 3, 8]
sorted_arr = quick_sort(arr)
print(sorted_arr) # [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

def fancy_quick_sort(arr):
    if len(arr) <= 1:
        return arr
    
    pivot = arr[len(arr) // 2]

    left = [el for el in arr if el < pivot]
    middle = [el for el in arr if el == pivot]
    right = [el for el in arr if el > pivot]

    return fancy_quick_sort(left) + middle + fancy_quick_sort(right)
