using ConsoleSandBoxApp;

//var result = Solution.FizzBuzz(3);
var nums = new int[][] { new int[] { 1,2,3 }, new int[] { 4,5,6 }, new int[] { 7,8,9 } }; // 1, 7, 3, 6, 5, 6
var result = Solution.FindDiagonalOrder(nums);

Console.WriteLine(result);
//Helpers.Print(result);