class Baiviet
{

    public string title;
    public string content;
    public string hinhAnh;

    public Baiviet()
    {
        Console.WriteLine("khoi tao");
    }

    public Baiviet(string title, string content, string hinhAnh)
    {
        Console.WriteLine("co tham so");
        this.title = title;
        this.content = content;
        this.hinhAnh = hinhAnh;
    }


    public void xuatThongTin()
    {
        Console.Write($"{title},{content},{hinhAnh}");
    }
}