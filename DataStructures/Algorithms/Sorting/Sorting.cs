namespace DataStructures.Algorithms.Sorting
{
    public static class Sorting
    {
        //Space complexity: O(1)
        //Time Complexity: O(n^2)
        //'Swaps' the elements
        //Is Stable: Yes
        //can be used on: nearly sorted arrays
        //should not be used on: large datasets
        public static void BubbleSort(this int[] arr)
        {
            var swapped = false;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        swapped = true;
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        //Is Stable: No
        //Others: same as bubble sort
        public static void SelectionSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var indexOfMinElement = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[indexOfMinElement]) < 0)
                    {
                        indexOfMinElement = j;
                    }
                }

                if (indexOfMinElement != i)
                {
                    (arr[i], arr[indexOfMinElement]) = (arr[indexOfMinElement], arr[i]);
                }
            }
        }

        //it shifts instead of swaps the items,
        //but in the other properties,
        //same as bubble sort,
        //very fast on small collections
        public static void InsertionSort(this int[] arr)
        {
            for (int currentIndex = 1; currentIndex < arr.Length; currentIndex++)
            {
                var currentElement = arr[currentIndex];
                var previousIndex = currentIndex - 1;

                //while previous index is in the range of the array and previous element is greater than the current
                while (previousIndex >= 0 && arr[previousIndex].CompareTo(currentElement) > 0)
                {
                    arr[previousIndex + 1] = arr[previousIndex];
                    previousIndex--;
                }

                // place currentElement in its correct position
                arr[previousIndex + 1] = currentElement;
            }
        }

        //Time Complexity: O(n log n) on average, O(n ^ 2) in the worst case.
        //Space Complexity: O(log n) on average due to recursion stack, O(n) in the worst case
        //Is Stable: No
        //Works by selecting a pivot element from the array,
        //partitioning the array into two sub-arrays: elements less than the pivot
        //and elements greater than the pivot. It then recursively sorts the sub-arrays.
        //Steps:
        //1. Choose a pivot (in this implementation, always the last element).
        //2. Rearrange the array so that all elements smaller than the pivot are
        //on the left and all greater elements are on the right.
        //3. Recursively apply the above steps to the left and right sub-arrays.
        public static void QuickSort(this int[] array) => QuickSort(array, 0, array.Length - 1);

        private static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var pivotIndex = Partition(array, low, high);

                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            var pivot = array[high];
            var i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }

        // Time Complexity: O(n log n) for all cases (best, average, worst)
        // Space Complexity: O(n) due to the temporary arrays used during merging
        // Is Stable: Yes
        // Works by recursively dividing the array into halves until each sub-array contains one element,
        // then merging the sorted sub-arrays back together.
        // Steps:
        // 1. Divide the array into two halves.
        // 2. Recursively sort each half.
        // 3. Merge the two sorted halves into a single sorted array.
        public static void MergeSort(this int[] array) => MergeSort(array, 0, array.Length - 1);

        private static void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;

                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);

                Merge(array, leftIndex, middleIndex, rightIndex);
            }
        }

        private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            var leftSize = middleIndex - leftIndex + 1;
            var rightSize = rightIndex - middleIndex;

            var leftArray = new int[leftSize];
            var rightArray = new int[rightSize];

            for (var i = 0; i < leftSize; i++)
            {
                leftArray[i] = array[leftIndex + i];
            }

            for (var j = 0; j < rightSize; j++)
            {
                rightArray[j] = array[middleIndex + 1 + j];
            }

            var sortedIndex = leftIndex;
            var leftIndexCounter = 0;
            var rightIndexCounter = 0;

            while (leftIndexCounter < leftSize && rightIndexCounter < rightSize)
            {
                if (leftArray[leftIndexCounter] <= rightArray[rightIndexCounter])
                {
                    array[sortedIndex] = leftArray[leftIndexCounter];
                    leftIndexCounter++;
                }
                else
                {
                    array[sortedIndex] = rightArray[rightIndexCounter];
                    rightIndexCounter++;
                }

                sortedIndex++;
            }

            while (leftIndexCounter < leftSize)
            {
                array[sortedIndex] = leftArray[leftIndexCounter];
                leftIndexCounter++;
                sortedIndex++;
            }

            while (rightIndexCounter < rightSize)
            {
                array[sortedIndex] = rightArray[rightIndexCounter];
                rightIndexCounter++;
                sortedIndex++;
            }
        }

        public static int[] Reset(this int[] arr) => [4, 10, 3, 1, 8, 2, 7, 5, 9, 6];
    }
}
