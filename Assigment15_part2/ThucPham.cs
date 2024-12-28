class ThucPham : SanPham
{
    private double shipMoney;
    public double ShipMoney
    {
        get { return shipMoney; }
        set { shipMoney = value; }
    }
    public override double tinhGiaBan()
    {
        return GiaGoc + shipMoney;
    }

    public override void Infor()
    {

        Console.WriteLine($"Mã Sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham},Giá gốc: {GiaGoc}.000 Đồng ,Giá bán: {tinhGiaBan()}.000 Đồng");
    }

}