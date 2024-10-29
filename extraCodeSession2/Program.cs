internal class Program
{
    private static void Main(string[] args)
    {
    #region bai 6
        Console.Write("Nhập số dư tài khoản hiện tại: ");
        string balanceString = Console.ReadLine();
        decimal balance = Convert.ToDecimal(balanceString);

        Console.Write("Nhập số tiền muốn rút: ");
        string withdrawalString  = Console.ReadLine();
        decimal withdrawal = Convert.ToDecimal(withdrawalString);

        decimal newBalance = balance - withdrawal;
        
        Console.WriteLine($"Số dư còn lại sau khi rút tiền: {newBalance}");
    #endregion
    #region bai 7

        Console.Write("Nhập quãng đường đã đi (km): ");
        string distanceString = Console.ReadLine();
        double distance = Convert.ToDouble(distanceString);

        Console.Write("Nhập thời gian đã đi (giờ): ");
        string timeString = Console.ReadLine();
        double time = Convert.ToDouble(timeString);

        double averageSpeed = distance / time;
        
        Console.WriteLine($"Tốc độ trung bình: {averageSpeed} km/h");
    #endregion
    #region bai 8
          Console.Write("Nhập một số: ");
          string partString = Console.ReadLine();
        double part =  Convert.ToDouble(partString);

        Console.Write("Nhập tổng số: ");
        string totalString = Console.ReadLine();
        double total = Convert.ToDouble(totalString);

        double percentage = (part / total) * 100;
        
        Console.WriteLine($"Tỷ lệ phần trăm: {percentage}%");
    #endregion
    #region bai 9
     Console.Write("Nhập vận tốc (km/h): ");
         string speedKmHString = Console.ReadLine();
        double speedKmH = double.Parse(speedKmHString);

        double speedMs = speedKmH / 3.6;
        
        Console.WriteLine($"Vận tốc tương ứng: {speedMs}((m/s)");
    #endregion

    #region bai 10
      Console.Write("Nhập số phút đã tập thể dục: ");
       int minutes = int.Parse(Console.ReadLine());

       Console.WriteLine("Chọn loại hình tập thể dục:");
       Console.WriteLine("1. Chạy");
       Console.WriteLine("2. Đạp xe"); 
       Console.WriteLine("3. Bơi lội");
       int choice = int.Parse(Console.ReadLine());

       double caloriesPerMinute;
       switch (choice)
       {
           case 1:
               caloriesPerMinute = 10.0; 
               break;
           case 2:
               caloriesPerMinute = 8.0; 
               break;
           case 3:
               caloriesPerMinute = 12.0; 
               break;
           default:
               caloriesPerMinute = 0.0;
               break;
       }

       double totalCalories = minutes * caloriesPerMinute;
       
       Console.WriteLine($"Lượng calo tiêu thụ: {totalCalories} calo");
    
    #endregion


    }
}