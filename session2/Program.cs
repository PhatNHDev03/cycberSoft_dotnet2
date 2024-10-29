internal class Program
{
    private static void Main(string[] args)
    {
        #region bài 1
         Console.Write("Nhập số ngày: ");
        string dayString = Console.ReadLine();
        int days = Convert.ToInt32(dayString);
        int weeks = days / 7;
        int remainingDays = days % 7;

        Console.WriteLine($"{days} ngày = {weeks} tuần và {remainingDays} ngày.");
      #endregion
    #region bai 2
            Console.Write("Nhập giá trị đơn hàng: ");
            string order = Console.ReadLine();
        decimal orderValue = Convert.ToDecimal(order);

        Console.Write("Nhập phần trăm giảm giá: ");
        string discount = Console.ReadLine();
        decimal discountPercentage = Convert.ToDecimal(discount);

        decimal discountAmount = orderValue * discountPercentage / 100;
        decimal finalAmount = orderValue - discountAmount;

        Console.WriteLine($"Số tiền giảm giá: {discountAmount}");
        Console.WriteLine($"Tổng tiền phải thanh toán sau khi áp dụng giảm giá: {finalAmount}");
    #endregion
    #region bai 3
     Console.Write("Nhập số phút: ");
        string minString = Console.ReadLine();
        int minutes = Convert.ToInt32(minString);

        int hours = minutes / 60;
        int remainingMinutes = minutes % 60;

        Console.WriteLine($"{minutes} phút = {hours} giờ và {remainingMinutes} phút."); 
    #endregion
    #region bai 4
     Console.Write("Nhập số tiền gốc: ");
     string amountString = Console.ReadLine();
        decimal originalAmount = Convert.ToDecimal(amountString);

        Console.Write("Nhập tỷ lệ thuế VAT (%): ");
        string vartString = Console.ReadLine();
        decimal vatPercentage = Convert.ToDecimal(vartString);

        decimal vatAmount = originalAmount * vatPercentage / 100;
        decimal totalAmount = originalAmount + vatAmount;

        Console.WriteLine($"Số tiền thuế VAT: {vatAmount}");
        Console.WriteLine($"Tổng số tiền sau khi đã cộng thêm thuế: {totalAmount}"); 
    #endregion
    #region bai 5
     Console.Write("Nhập số tiền USD: ");
        string amount = Console.ReadLine();
        decimal usdAmount = Convert.ToDecimal(amount);

        Console.Write("Nhập tỷ giá chuyển đổi từ USD sang VND: ");
        string rateString  = Console.ReadLine();
        decimal exchangeRate = Convert.ToDecimal(rateString);

        decimal vndAmount = usdAmount * exchangeRate;

        Console.WriteLine($"Số tiền tương ứng bằng VND: {vndAmount}");
    #endregion
    }
}