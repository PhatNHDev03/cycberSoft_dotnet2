class hocSinh
{
    public string name;
    public string gener;
    public string email;
    public string age;

    public void nhapThongTin()
    {
        Console.WriteLine($"mời bạn nhập thông tin");
        Console.WriteLine("Tên");
        name = Console.ReadLine();
        Console.WriteLine("gioi tinh");
        gener = Console.ReadLine();
        Console.WriteLine("email");
        email = Console.ReadLine();
        Console.WriteLine("tuoi");
        age = Console.ReadLine();
    }

    public void xuatThongTin()
    {
        Console.WriteLine($"{name} va {gener} va {email} va {age}");
    }


}