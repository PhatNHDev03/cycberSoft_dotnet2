internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Baiviet baiviet = new Baiviet("nhiem vu 100 ngay", "hinhAnh.png", "gaio nhiem vu");

        Console.WriteLine("xuat thong tin");
        baiviet.xuatThongTin();

        // Baiviet baiviet3;
        // baiviet3 = baiviet;
        // Console.WriteLine($"{baiviet3 == baiviet}");
        // baiviet3.hinhAnh = "HinhANh1.png";
        // Console.WriteLine($"{baiviet.hinhAnh}");
        // Baiviet biaviet4 = new Baiviet();

        // biaviet4.content = baiviet.content;
        // biaviet4.title = baiviet.title;
        // biaviet4.hinhAnh = baiviet.hinhAnh;
        // Console.WriteLine($"{biaviet4 == baiviet}");
        // string la null
        //int la 0
        //noll la 0 va 1
        // hocSinh hocSinh = new hocSinh();
        // hocSinh.xuatThongTin();
    }
}