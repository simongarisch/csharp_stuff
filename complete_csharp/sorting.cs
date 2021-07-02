// csc sorting.cs && sorting && del sorting.exe
using System;
using System.Linq;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class LinearSearch : IExample {
    List<int> elements = new List<int> {1, 2, 3, 4, 5};
    public void Run() {
        foreach(int item in elements) {
            Console.Write(linearSearch(elements, item) + " "); // 0 1 2 3 4
        }
        Console.WriteLine();

        Console.WriteLine(linearSearch(elements, 10)); // -1
    }

    static int linearSearch(List<int> elements, int x) {
        for (int i=0; i < elements.Count; i++) {
            if(elements[i] == x) {
                return i;
            }
        }
        return -1;
    }
}

class BinarySearch : IExample {
    // can only be used once a collection is sorted
    // starts at the middle and halfs the selection we're searching at each step
    public void Run() {
        int startingValue = 0;
        int sequenceLength = 10;
        var elements = Enumerable.Range(startingValue, sequenceLength).ToList<int>();

        foreach(int item in elements) {
            Console.Write(binarySearch(elements, item) + " "); // 0 1 2 3 4 5 6 7 8 9
        }
        Console.WriteLine();

        Console.WriteLine(binarySearch(elements, 20)); // -1

        // thankfully this is already available to you
        foreach(int item in elements) {
            Console.Write(Array.BinarySearch(elements.ToArray(), item) + " "); // 0 1 2 3 4 5 6 7 8 9
        }
        Console.WriteLine();
    }

    static int binarySearch(List<int> elements, int x) {
        int start = 0;
        int stop = elements.Count -1;
        int middle = (int)((start + stop) / 2);
        while (elements[middle] != x && start < stop) {
            if (x < elements[middle]) {
                stop = middle - 1;
            } else {
                start = middle + 1;
            }

             middle = (int)((start + stop) / 2);
        }
        
        return (elements[middle] != x) ? -1 : middle;
    }
}

class InterpolationSearch : IExample {
    // requires that the elements are sorted and uniformly distributed
    public void Run() {
        var arr = new int[] {1, 2, 3, 4, 5, 6, 7};
        foreach(int item in arr) {
            Console.Write(interpolationSearch(arr, item) + " "); // 0 1 2 3 4 5 6
        }
        Console.WriteLine();

    }

    int interpolationSearch(int[] arr, int x) {
        int low = 0;
        int high = arr.Length - 1;
        while (low <= high && x >= arr[low] && x <= arr[high]) {
            if (low == high) {
                if (arr[low] == x) {
                    return low;
                } else {
                    return -1;
                }
            }

            int pos = low + (high - low) / (arr[high] - arr[low]) * (x - arr[low]);
            if (arr[pos] == x) {
                return pos;
            }

            if (arr[pos] < x) {
                low = pos + 1;
            } else {
                high = pos - 1;
            }
        }

        return -1;
    }
}

class BuiltInSort : IExample {
    public void Run() {
        var example = new int[] { 3, 1, 6, 2, 8, 0 };
        Array.Sort(example);
        Array.ForEach(example, item => Console.Write(item + " ")); // 0 1 2 3 6 8
        Console.WriteLine();
    }
}

class SelectionSort : IExample {
    public void Run() {
        var elements = new int[] { 7, 5, 1, 2, 6 };
        foreach(int item in selectionSort(elements)) {
            Console.Write(item + " "); // 1 2 5 6 7
        }
        Console.WriteLine();
    }

    static int[] selectionSort(int[] arr) {
        int len = arr.Length;
        for (int i = 0; i < len; i++) {
            int minIndex = i;
            for (int j=i+1; j < len; j++) {
                if (arr[j] < arr[minIndex]) {
                    minIndex = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }

        return arr;
    }
}

class BubbleSort : IExample {
    public void Run() {
        var elements = new int[] { 5, 6, 3, 2, 1, 4 };
        foreach(int item in bubbleSort(elements)) {
            Console.Write(item + " "); // 1 2 3 4 5 6
        }
        Console.WriteLine();
    }

    static int[] bubbleSort(int[] arr) {
        for(int i=arr.Length-1; i >= 0 ; i--) {
            for (int j=1; j<=i; j++) {
                if (arr[j-1] > arr[j]) {
                    int temp = arr[j-1];
                    arr[j-1] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        return arr;
    }
}

class QuickSort : IExample {
    // https://www.geeksforgeeks.org/quick-sort/
    public void Run() {
        var elements = new int[] { 5, 6, 3, 2, 1, 4 };
        quickSort(elements, 0, elements.Length-1);
        foreach(int item in elements) {
            Console.Write(item + " "); // 1 2 3 4 5 6
        }
        Console.WriteLine();
    }

    static int Partition(int[] arr, int left, int right) {
        int arrLen = arr.Length;
        int temp;
        int pivotIndex = left;
        int pivot = arr[left];
        while (left < right) {
            while (arr[left] <= pivot && left < arrLen) {
                left++;
            }
            
            while (arr[right] > pivot) {
                right--;
            }

            if (left < right) {
                temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
        }

        temp = arr[right];
        arr[right] = arr[pivotIndex];
        arr[pivotIndex] = temp;

        return right;
    }

    static void quickSort(int[] arr, int left, int right) {
        if (left < right) {
            int pivot = Partition(arr, left, right);
            quickSort(arr, left, pivot-1);
            quickSort(arr, pivot+1, right);
        }
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new LinearSearch(),
            new BinarySearch(),
            new InterpolationSearch(),
            new BuiltInSort(),
            new SelectionSort(),
            new BubbleSort(),
            new QuickSort(),
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
