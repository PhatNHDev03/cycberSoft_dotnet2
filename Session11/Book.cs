class Book
{
    public string id;
    public string name;
    public string author;
    public double price;

    public Book(string id, string name, string author, double price)
    {
        this.id = id;
        this.name = name;
        this.author = author;
        this.price = price;
    }

    public void infor()
    {
        Console.WriteLine($"{id},{name},{author},{price}");
    }

}