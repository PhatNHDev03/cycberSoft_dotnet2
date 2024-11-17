public class Assignment
{

    public static int sumElement(List<int> lstNumber)
    {
        int sum = 0;


        foreach (int number in lstNumber)
        {
            sum += number;
        }

        return sum;
    }

    public static List<int> FindTwoSum(List<int> nums, int target)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new List<int> { i, j };
                }
            }
        }
        return new List<int>();
    }


    public static List<int> RemoveDuplicates(List<int> nums)
    {
        if (nums.Count == 0) return new List<int>();

        List<int> result = new List<int>();
        result.Add(nums[0]);

        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                result.Add(nums[i]);
            }
        }
        return result;
    }


    public static List<int> FindTopKFrequent(List<int> nums, int k)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();


        foreach (int num in nums)
        {
            if (!frequency.ContainsKey(num))
                frequency[num] = 0;
            frequency[num]++;
        }


        return frequency.OrderByDescending(x => x.Value)
                       .Take(k)
                       .Select(x => x.Key)
                       .ToList();
    }


    public static int MaxProfit(List<int> prices)
    {
        if (prices.Count < 2) return 0;

        int maxProfit = 0;
        int minPrice = prices[0];

        for (int i = 1; i < prices.Count; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else
            {
                int currentProfit = prices[i] - minPrice;
                maxProfit = Math.Max(maxProfit, currentProfit);
            }
        }

        return maxProfit;
    }

}