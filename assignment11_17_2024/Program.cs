internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bài 1:");
        List<int> nums1 = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
        int result1 = Assignment.sumElement(nums1);
        Console.WriteLine($"Kết quả: sum: {result1}");

        Console.WriteLine("Bài 2:");
        List<int> nums2 = new List<int> { 2, 7, 11, 15 };
        int target = 9;
        List<int> result2 = Assignment.FindTwoSum(nums2, target);
        Console.WriteLine($"Kết quả: [{string.Join(", ", result2)}]");


        Console.WriteLine("\nBài 3:");
        List<int> nums3 = new List<int> { 1, 1, 2, 2, 3, 4, 4, 5 };
        List<int> result3 = Assignment.RemoveDuplicates(nums3);
        Console.WriteLine($"Mảng mới: [{string.Join(", ", result3)}]");

        // Test Bài 4
        Console.WriteLine("\nBài 4:");
        List<int> nums4 = new List<int> { 1, 1, 1, 2, 2, 3 };
        int k = 2;
        List<int> result4 = Assignment.FindTopKFrequent(nums4, k);
        Console.WriteLine($"Kết quả: [{string.Join(", ", result4)}]");

        // Test Bài 5
        Console.WriteLine("\nBài 5:");
        List<int> prices = new List<int> { 7, 1, 5, 3, 6, 4 };
        int maxProfit = Assignment.MaxProfit(prices);
        Console.WriteLine($"Lợi nhuận tối đa: {maxProfit}");
    }
}