using System.Drawing;
using System.Text.RegularExpressions;

class WareHouse
{
    public string id;
    public string wareHouseName;
    public List<Product> products;


    public WareHouse(string id, string wareHouseName)
    {
        this.id = id;
        this.wareHouseName = wareHouseName;
        products = new List<Product>();
    }

    public void add(Product product)
    {
        products.Add(product);
    }

    public void displayAll()
    {
        foreach (var item in products)
        {
            item.infor();
        }
    }
    public Product getInforProductByID(string id)
    {
        return products.Find(p => p.id == id);
    }

    public void displayByName(string name)
    {
        foreach (var item in products)
        {
            if (item.name.IndexOf(name) > -1)
            {
                item.infor();
            }
        }
    }

    public void updateProduct(string productId, int choice)
    {
        var product = getInforProductByID(productId);
        if (product == null)
        {
            Console.WriteLine("product is not exist!!!");
            return;
        }
        Console.WriteLine("Enter updatenumber");
        var updatenumber = Console.ReadLine();
        switch (choice)
        {
            case 1:
                product.price = double.Parse(updatenumber);
                break;
            case 2:
                product.quantity = int.Parse(updatenumber);
                break;
        }
        Console.WriteLine("Update successfully!!");
    }

    public void totalPrice()
    {
        var sum = 0.0;
        foreach (var item in products)
        {
            sum += item.price * item.quantity;
        }
        Console.WriteLine($"Total: {sum}");
    }

    public void removeAproduct(string productId)
    {
        var product = getInforProductByID(productId);
        if (product == null)
        {
            Console.WriteLine("product is not exist!!!");
            return;
        }
        products.Remove(product);
        Console.WriteLine("Remove successfully");
    }
    public void displayAllWithTotalPrice()
    {
        foreach (var item in products)
        {
            Console.WriteLine($"Product: id {item.id}, name {item.name}, total price {item.totalPrice()}");
        }
    }
    public void displayAllWithPriceAsc()
    {
        foreach (var item in products.OrderBy(p => p.price))
        {
            item.infor();
        }
    }

    public void updateQuantityByUpdatingstatus(string productId, int orderQuantity)
    {
        var product = getInforProductByID(productId);
        product.quantity = product.quantity - orderQuantity;
    }

    public void displayOrderByFullName()
    {
        foreach (var item in products.OrderBy(p => p.name))
        {
            item.infor();
        }
    }
    public void displayOrderByName()
    {
        foreach (var item in products.OrderBy(p =>
        {
            return Regex.Split(p.name, @"\s+").Last();
        }))
        {
            item.infor();
        }
    }

}