abstract class SanPham
{
    private string maSanPham;
    public string MaSanPham { get { return maSanPham; } set { maSanPham = value; } }
    private string tenSanPham;
    public string TenSanPham { get { return tenSanPham; } set { tenSanPham = value; } }

    private double giaGoc;
    public double GiaGoc { get { return giaGoc; } set { giaGoc = value; } }

    public abstract double tinhGiaBan();

    public virtual void Infor()
    {
        Console.WriteLine($"Ma San pham:{MaSanPham}, Ten san pham: {TenSanPham}, Gia ban{tinhGiaBan()}");
    }

}