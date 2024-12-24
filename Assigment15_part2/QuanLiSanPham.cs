class QuanLiSanPham
{

    public string id { get; set; }
    public List<SanPham> sanPhams;

    public QuanLiSanPham(string id)
    {
        this.id = id;
        sanPhams = new List<SanPham>();

    }

    public void add(object sanpham)
    {
        sanPhams.Add(sanpham as SanPham);
    }

    public void displayAll()
    {
        foreach (var item in sanPhams)
        {
            item.Infor();
        }
    }
    public double sumPrice()
    {
        // double total = 0;
        // sanPhams.ForEach(x=>total+=x.tinhGiaBan());
        return sanPhams.Sum(x => x.tinhGiaBan());
    }

    public SanPham findSanPham(string id){
        return sanPhams.Find(p => p.MaSanPham ==id);
    }

    public void removeAProduct(SanPham sanPham){
        sanPhams.Remove(sanPham);
    
    }


}