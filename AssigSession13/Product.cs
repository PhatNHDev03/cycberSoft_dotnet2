class Product
{

    public string id;
    public string name;
    public double price;
    public int quantity;

    public Product() { }
    public Product(string id, string name, double price, int quantity)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public void infor()
    {
        Console.WriteLine($"Product: id {id}, name {name}, price {price}, quantity {quantity}");
    }
    public double totalPrice()
    {
        return price * quantity;
    }
}