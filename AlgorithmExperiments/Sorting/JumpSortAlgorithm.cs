using System;
using System.Collections.Generic;

namespace AlgorithmExperiments
{
    /*abstract :
     * a best effort sorting algorithm that represents a logic of sorting using a hash function that uniquely generates location and performs sorting 
     * sorting in o(n)
     * 
     */
    internal class JumpSortAlgorithm
    {
        private const int marker = -1;
        private const int offset = 1;
        private static Stack<int> _stack = new Stack<int>();

        // these are primitive:  since in the current attempt I focuse on sorting non zero numbers in that sequence 

        private static int GetLocationCodeOrHash(int value) => value - offset;

        private static bool IsValueLocationCorrect(int value, int location) => GetLocationCodeOrHash(value) == location || value == marker;

        private static void JumpSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsValueLocationCorrect(arr[i], i))
                {
                    JumpSwap(arr, i, marker);
                }
            }
        }

        private static void JumpSwap(int[] arr, int pos, int expectedVal)
        {
            if (pos >= arr.Length)
            {
                _stack.Push(arr[pos]);
                arr[pos] = marker;
                return;
            }
            if (!IsValueLocationCorrect(arr[pos], pos))
            {
                int temp = arr[pos];
                arr[pos] = marker;
                JumpSwap(arr, GetLocationCodeOrHash(temp), temp);
                arr[pos] = expectedVal != marker ? expectedVal : arr[pos];
            }
            else if (arr[pos] == expectedVal)
            {
                _stack.Push(expectedVal);
            }
            else
            {
                arr[pos] = expectedVal;
            }
        }

        private static int Main(string[] args)
        {
            int[] arr = { 1, 3, 6, 4, 1, 2 };

            JumpSort(arr);

            Console.WriteLine("New SortedArray : " + string.Join(",", arr));

            Console.WriteLine("Unable to put :" + string.Join(",", _stack.ToArray()));
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] == marker)
                {
                    break;
                }
            }
            Console.WriteLine("missing element = " + (i+offset));
            return i;
        }
    }
}