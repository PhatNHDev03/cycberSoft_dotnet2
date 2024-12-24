class Dientu : SanPham
{
    private double baoHanh;
    public double BaoHanh
    {
        get { return baoHanh; }
        set { baoHanh = value / 100; }
    }

    public override double tinhGiaBan()
    {
        return GiaGoc + (GiaGoc * baoHanh);
    }

    public override void Infor()
    {

        Console.WriteLine($"Mã sản phẩm:{MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá gốc: {GiaGoc}.000 Đồng ,Giá bán: {tinhGiaBan()}.000 Đồng");
    }

}