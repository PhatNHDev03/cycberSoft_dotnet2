class ThoiTrang : SanPham
{
    private double discount;
    public double Discount
    {
        get { return discount; }
        set { discount = value / 100; }
    }
    public override double tinhGiaBan()
    {
        return GiaGoc - (GiaGoc * Discount);
    }

    public override void Infor()
    {

        Console.WriteLine($"Mã Sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham},Giá gốc: {GiaGoc}.000 Đồng ,Giá bán: {tinhGiaBan()}.000 Đồng");
    }

}