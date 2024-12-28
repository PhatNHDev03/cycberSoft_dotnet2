internal class Program
{
    private static void Main(string[] args)
    {
        QuanLiSanPham quanLiSanPham = new QuanLiSanPham("Q1");
        SanPham sanPham1 = new Dientu() { MaSanPham = "P001", TenSanPham = "Chuot Razer death V2 co day", GiaGoc = 1200.000, BaoHanh = 10 };
        SanPham sanPham2 = new ThoiTrang() { MaSanPham = "P002", TenSanPham = "Chăn lông cừu", GiaGoc = 5200.000, Discount = 20 };
        SanPham sanPham3 = new ThucPham() { MaSanPham = "P003", TenSanPham = "Ức gà", GiaGoc = 49.000, ShipMoney = 15.000 };
        quanLiSanPham.sanPhams.Add(sanPham1);
        quanLiSanPham.sanPhams.Add(sanPham2);
        quanLiSanPham.sanPhams.Add(sanPham3);
        var choice = 0;
        do
        {
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine("________________");
            Console.WriteLine("1. Thêm sản phẩm mới");
            Console.WriteLine("2. Hiển thị danh sach sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.WriteLine("Vui lòng chọn chức năng: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("___________________________________________________________");
            switch (choice)
            {
                case (1):
                    Console.WriteLine("________________");
                    Console.WriteLine("1. Điện tử");
                    Console.WriteLine("2. Thời trang");
                    Console.WriteLine("3. Thực phẩm");
                    Console.WriteLine("Vui lòng nhập lựa chọn:");
                    int optionalChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập mã sản phẩm: ");
                    var id = Console.ReadLine();
                    Console.WriteLine("Nhập tên sản phẩm");
                    var nameProduct = Console.ReadLine();
                    Console.WriteLine("Nhập giá gốc sản phẩm");
                    double price = double.Parse(Console.ReadLine());
                    SanPham sanPhamMoi;
                    if (optionalChoice == 1)
                    {
                        Console.WriteLine("Vui lòng mã thuế bảo hành");
                        var tax = double.Parse(Console.ReadLine());
                        sanPhamMoi = new Dientu() { MaSanPham = id, TenSanPham = nameProduct, GiaGoc = price, BaoHanh = tax };
                    }
                    else if (optionalChoice == 2)
                    {
                        Console.WriteLine("Vui lòng mã giảm giá");
                        var discount = double.Parse(Console.ReadLine());
                        sanPhamMoi = new ThoiTrang() { MaSanPham = id, TenSanPham = nameProduct, GiaGoc = price, Discount = discount };
                    }
                    else if (optionalChoice == 3)
                    {
                        Console.WriteLine("Vui lòng tiển ship");
                        var shipMoney = double.Parse(Console.ReadLine());
                        sanPhamMoi = new ThucPham() { MaSanPham = id, TenSanPham = nameProduct, GiaGoc = price, ShipMoney = shipMoney };
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập lựa chọn phù hợp");
                        break;
                    }
                    quanLiSanPham.sanPhams.Add(sanPhamMoi);
                    Console.WriteLine("Add successfully !!");
                    break;
                case (2):
                    Console.WriteLine("_______________________Danh sách sản phẩm____________________");
                    quanLiSanPham.displayAll();
                    break;
                case (3):
                    Console.WriteLine($"Tổng doanh thu là {quanLiSanPham.sumPrice()}");
                    break;
                case (4):
                    quanLiSanPham.displayAll();
                    Console.WriteLine("_________________________________");
                    Console.WriteLine("Vui lòng nhập mã sản phẩm để xóa");
                    var deleteId = Console.ReadLine();
                    var sanphamTimThay = quanLiSanPham.findSanPham(deleteId);
                    if (sanphamTimThay == null)
                    {
                        Console.WriteLine("Mã sản phẩm ko hợp lệ !!");
                        break;
                    }
                    Console.WriteLine("Are you sure that you want to delete this product ? Y/N");
                    var confirm = Console.ReadLine();
                    if (confirm.Trim().StartsWith("N") == true || confirm.Trim().StartsWith("n") == true)
                    {
                        Console.WriteLine("Đã hủy việc xóa sản phẩm");
                        break;
                    }
                    quanLiSanPham.removeAProduct(sanphamTimThay);
                    Console.WriteLine("Remove successfully");
                    Console.WriteLine("________________AFTER:_________________");
                    quanLiSanPham.displayAll();

                    break;

                case (5):
                    break;
            }
        }
        while (choice < 5);
    }
}