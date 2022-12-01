namespace ConsoleSandBoxApp;

internal static class Solution
{
    public static int[] FindDiagonalOrder(int[][] mat)
    {
        var up = true;
        var rowLen = mat.Length;
        var colLen = mat[0].Length;
        var result = new int[rowLen * colLen];

        var row = 0;
        var col = 0;
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = mat[row][col];
            Console.WriteLine($"row:{row}, col:{col}, i: {i}, result[i]: {result[i]}");
            
            if (up)
            {
                if (row == 0 && col < colLen - 1)
                {
                    col++;
                    up = !up;
                }
                else if (col == colLen - 1)
                {
                    row++;
                    up = !up;
                }
                else
                {
                    row--;
                    col++;
                }
            }
            else
            {
                if (row < rowLen - 1 && col == 0)
                {
                    row++;
                    up = !up;
                }
                else if (row == rowLen - 1)
                {
                    col++;
                    up = !up;
                }
                else
                {
                    row++;
                    col--;
                }
            }
        }

        return result;
    }

    public static int[] PlusOne(int[] digits)
    {
        var index = digits.Length - 1;
        digits[index] += 1;
        while (digits[index] == 10 && index > 0)
        {
            digits[index] = 0;
            index--;
            digits[index] += 1;
        }

        if (digits[0] == 10)
        {
            digits[0] = 0;
            var result = new int[digits.Length + 1];
            result[0] = 1;
            for (var i = 1; i < digits.Length + 1; i++)
            {
                result[i] = digits[i - 1];
            }
            return result;
        }

        return digits;
    }

    public static int DominantIndex(int[] nums)
    {
        var max = -1;
        int maxIndex = -1;
        var second = -2;
        int temp;
        for (var i = 0; i < nums.Length; i++)
        {
            temp = nums[i];
            if (temp > max)
            {
                second = max;
                max = temp;
                maxIndex = i;
            }
            else if (temp > second && temp < max)
            {
                second = nums[i];
            }
        }

        if (max < 2 * second)
        {
            return -1;
        }

        return maxIndex;
    }

    public static int PivotIndex(int[] nums)
    {
        var rightSum = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        if (rightSum == 0)
        {
            return 0;
        }

        var leftSum = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            leftSum += nums[i - 1];
            rightSum -= nums[i];
            if (leftSum == rightSum)
            {
                return i;
            }
        }

        return -1;
    }

    public static IList<int> FindDisappearedNumbers(int[] nums)
    {
        var set = nums.ToHashSet();
        var missing = new List<int>();
        for (var i = 1; i <= nums.Length; i++) // for (var i = set.Min(); i <= set.Min() + nums.Length - 1; i++)
        {
            if (!(set.Contains(i)))
            {
                missing.Add(i);
            }
        }

        return missing;
    }

    public static int ThirdMax(int[] nums)
    {
        //int? first = null;
        //int? second = null;
        //int? third = null;

        //for (var i = 0; i < nums.Length; i++)
        //{
        //    var current = nums[i];
        //    if (first == null)
        //    {
        //        first = current;
        //    }
        //    else if (second == null && current < first)
        //    {
        //        second = current;
        //    }
        //    else if (third == null && current < second)
        //    {
        //        third = current;
        //    }
        //    else if(first != null && current > first)
        //    {
        //        first = current;
        //    }
        //    else if(first != null && second != null &&
        //        current < first && current > second)
        //    {
        //        second = current;
        //    }
        //    else if(first != null && second != null && third != null &&
        //        current < second && current > third)
        //    {
        //        third = current;
        //    }
        //}

        //return third == null ? (int)first : (int)third;

        //// does work-----
        //Array.Sort(nums);
        //var max = nums[nums.Length - 1];
        //var counter = 0;
        //for (var i = nums.Length - 1; i >= 0; i++)
        //{
        //    if (nums[i - 1] == nums[i])
        //    {
        //        nums[counter++] = nums[i - 1];
        //        nums[i - 1] = nums[i - 2];
        //    }
        //}

        //return nums[2];
        ////------------------

        // Works ------------------
        var maxElements = new HashSet<int>();
        foreach (int element in nums)
        {
            maxElements.Add(element);
            if (maxElements.Count > 3)
                maxElements.Remove(maxElements.Min());
        }

        if (maxElements.Count == 3)
        {
            return maxElements.Min();
        }

        return maxElements.Max();
        // ---------------------

        //// Works -------------------
        //int len = nums.Length;
        //Array.Sort(nums);
        //int idx = len - 1, i, distinctCount = 0;
        //while (idx >= 0)
        //{
        //    distinctCount++;
        //    i = idx - 1;
        //    //to check all the values with same value as a[idx]
        //    while (i >= 0 && nums[i] == nums[idx])
        //        i--;
        //    //no third distinct element
        //    if (i == -1)
        //        return nums[len - 1];
        //    idx = i;
        //    //found 2 bigger elements before?
        //    if (distinctCount == 2)
        //        return nums[idx];
        //}
        //return -1;
        //////--------------------
    }

    public static int HeightChecker(int[] heights)
    {
        var corrected = 0;
        var preSort = new int[heights.Length];
        for (var i = 0; i < heights.Length; i++)
        {
            preSort[i] = heights[i];
        }
        Array.Sort(heights);
        for (var i = 0; i < heights.Length; i++)
        {
            if (heights[i] != preSort[i])
            {
                corrected++;
            }
        }

        return corrected;
    }

    public static int[] SortArrayByParity(int[] nums)
    {
        //// Works and is prob better BUT complicated
        //int start = 0;
        //int end = nums.Length - 1;

        //while (start < end)
        //{
        //    while (start < nums.Length && nums[start] % 2 == 0) start++;
        //    while (end >= 0 && nums[end] % 2 != 0) end--;
        //    if (start < end)
        //    {
        //        int temp = nums[start];
        //        nums[start] = nums[end];
        //        nums[end] = temp;
        //    }
        //}
        //return nums;

        int[] result = new int[nums.Length];
        int resultIndex = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                result[resultIndex++] = nums[i];
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 != 0)
            {
                result[resultIndex++] = nums[i];
            }
        }
        return result;
    }

    public static void MoveZeroes(int[] nums)
    {
        var nonZeroPointer = 0;
        for (var readerPointer = 0; readerPointer < nums.Length; readerPointer++)
        {
            if (nums[readerPointer] != 0)
            {
                nums[nonZeroPointer++] = nums[readerPointer];
            }
        }

        for (var addZeroIndex = nonZeroPointer; addZeroIndex < nums.Length; addZeroIndex++)
        {
            nums[addZeroIndex] = 0;
        }
    }

    public static int[] ReplaceElements(int[] arr)
    {
        //// bad solution
        //var editLength = arr.Length - 1;
        //for (var i = 0; i < editLength; i++)
        //{
        //    var max = 0;
        //    for (var j = i + 1; j < arr.Length; j++)
        //    {
        //        var currentVal = arr[j];
        //        if (currentVal > max)
        //        {
        //            max = currentVal;
        //        }
        //    }

        //    arr[i] = max;
        //}

        //arr[editLength] = -1;

        //// better solution
        var len = arr.Length;
        var max = arr[len - 1];
        arr[len - 1] = -1;
        for (var i = len - 2; i >= 0; i--)
        {
            var temp = arr[i];
            arr[i] = max;
            if (temp > max)
            {
                max = temp;
            }
        }

        return arr;
    }

    public static bool ValidMountainArray(int[] arr) // 941
    {
        if (arr.Length < 3)
        {
            return false;
        }

        var previousDiff = 0;
        var slopeSwitched = false;
        for (var i = 1; i < arr.Length; i++)
        {
            var diff = arr[i] - arr[i - 1];
            if (diff == 0)
            {
                return false;
            }
            else if ((diff > 0 && previousDiff < 0) || ((diff < 0 && previousDiff > 0)))
            {
                if (slopeSwitched)
                {
                    return false;
                }
                slopeSwitched = true;
            }
            else if (!slopeSwitched && diff < 0)
            {
                return false;
            }
            previousDiff = diff;
        }

        return slopeSwitched;
    }

    public static bool CheckIfExist(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < arr.Length; j++)
            {
                if (j != i && arr[i] == 2 * arr[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        //var el = 0;
        //for (var i = 0; i < nums.Length; i++)
        //{
        //    if (i < nums.Length - 1 && nums[i] == nums[i + 1]) // not dupe
        //    {
        //         continue; // next
        //    }

        //    nums[el++] = nums[i];
        //}

        //return el;

        ////official soln
        // Check for edge cases.
        if (nums == null)
        {
            return 0;
        }

        // Use the two pointer technique to remove the duplicates in-place.
        // The first element shouldn't be touched; it's already in its correct place.
        int writePointer = 1;
        // Go through each element in the Array.
        for (int readPointer = 1; readPointer < nums.Length; readPointer++)
        {
            // If the current element we're reading is *different* to the previous
            // element...
            if (nums[readPointer] != nums[readPointer - 1])
            {
                // Copy it into the next position at the front, tracked by writePointer.
                nums[writePointer] = nums[readPointer];
                // And we need to now increment writePointer, because the next element
                // should be written one space over.
                writePointer++;
            }
        }

        // This turns out to be the correct length value.
        return writePointer;
    }

    public static int RemoveElement(int[] nums, int val)
    {
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[count++] = nums[i];
            }

            Print(nums);
        }

        Console.WriteLine(count);
        Print(nums);
        return count;
    }

    public static void ResetArray(int[] nums, int i, int k)
    {
        for (var j = i; j < nums.Length; j++)
        {
            if (i < nums.Length - 1)
            {
                nums[i] = nums[i + 1];
            }
        }
    }

    public static void Print(int[] nums)
    {
        Console.WriteLine(string.Join(", ", nums));
    }

    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var nIndex = 0;
        for (var mIndex = m; mIndex <= m + n - 1; mIndex++)
        {
            nums1[mIndex] = nums2[nIndex];
            nIndex++;
        }

        Array.Sort(nums1);
    }

    public static void DuplicateZeros(int[] arr) // 1089
    {
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                for (var j = arr.Length - 2; j >= i + 1; j--)
                {
                    arr[j + 1] = arr[j];
                }
                
                if (i < arr.Length - 1)
                {
                    arr[i + 1] = 0;
                }

                i++;
            }
        }
    }

    public static int[] SortedSquares(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = nums[i] * nums[i];
        }

        Array.Sort(nums);

        return nums;
    }

    public static int FindNumbers(int[] nums) // 1295
    {
        var evensCount = 0;
        foreach (var num in nums)
        {
            var digits = num.ToString().Length;
            if (digits % 2 == 0)
            {
                evensCount++;
            }
        }

        return evensCount;
    }

    public static int FindMaxConsecutiveOnes(int[] nums) // 485
    {
        var maxCon = 0;
        var con = 0;
        foreach (var num in nums)
        {
            if (num == 1)
            {
                con++;
            }
            else
            {
                if (con > maxCon)
                {
                    maxCon = con;
                }
                con = 0;
            }
        }

        return con > maxCon ? con : maxCon;
    }

    public static bool CanConstruct(string ransomNote, string magazine) // 383
    {
        if (magazine.Length < ransomNote.Length)
        {
            return false;
        }

        var magDict = StringToDictionary(magazine);
        var noteDict = StringToDictionary(ransomNote);
        foreach(var noteChar in noteDict)
        {
            var doesExist = magDict.TryGetValue(noteChar.Key, out int magVal);
            if (!doesExist || noteChar.Value > magVal)
            {
                return false;
            }
        }

        return true;
    }

    public static Dictionary<char, int> StringToDictionary(string str)
    {
        var dict = new Dictionary<char, int>();
        foreach (var key in str.ToCharArray())
        {
            var doesExist = dict.TryGetValue(key, out int val);
            if (doesExist)
            {
                dict[key] += 1;
            }
            else
            {
                dict.Add(key, 1);
            }
        }

        return dict;
    }

    public static int NumberOfSteps(int num) // 1342
    { 
        var stepNum = 0;
        while (num != 0)
        { 
            stepNum++;
            var isEven = num % 2 == 0;
            if (isEven)
            {
                num /= 2;
            }
            else
            {
                num -= 1;
            }
            Console.WriteLine(num);
        }

        Console.WriteLine("Steps: " + stepNum);
        return stepNum;
    }

    public static IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();

        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                result.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                result.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                result.Add("Buzz");
            }
            else
            {
                result.Add(i.ToString());
            }

            Console.WriteLine(result[i-1].ToString());
        }

        return result;
    }
}
