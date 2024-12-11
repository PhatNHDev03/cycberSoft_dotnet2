using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class OrderManagement
{
    public string id;
    public string name;
    public List<Order> orders;
    public OrderManagement(string id, string name)
    {
        this.id = id;
        this.name = name;
        orders = new List<Order>();
    }
    public void add(Order order)
    {
        orders.Add(order);
        Console.WriteLine("Add sucessfully!!");
    }
    public void displayAll(List<Product> products)
    {
        foreach (var item in orders)
        {
            foreach (var product in products)
            {
                if (item.productId == product.id)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");
                }
            }
        }
    }
    public void findByName(string name, List<Product> products)
    {
        Console.WriteLine("________________FOUND PRODUCT LIST________________");
        foreach (var item in orders)
        {
            foreach (var product in products)
            {
                if (item.productId == product.id && product.name.IndexOf(name) > -1)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");
                }
            }
        }
    }

    public Order checkOrder(string orderId)
    {
        return orders.Find(o => o.id == orderId);
    }

    public void updateQuantity(string orderId, int orderedQuantity)
    {
        var order = checkOrder(orderId);
        if (order == null)
        {
            Console.WriteLine(" invalid ordered id !!!");
            return;
        }
        order.quantity = orderedQuantity;
        Console.WriteLine("Udpdate sucessFully");
    }

    public void removeAorderedProduct(string orderdId)
    {
        var order = checkOrder(orderdId);
        if (order == null)
        {
            Console.WriteLine(" invalid ordered id !!!");
            return;
        }
        orders.Add(order);
        Console.WriteLine("Remove successfully");
    }

    public void displayAllWithTotalPrice(List<Product> products)
    {
        foreach (var item in orders)
        {
            foreach (var product in products)
            {
                if (item.productId == product.id)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, total price {product.totalPrice()}");
                }
            }
        }
    }

    public void displayAllWithPriceAsc(List<Product> products)
    {
        foreach (var item in orders)
        {
            foreach (var product in products.OrderBy(p => p.price))
            {
                if (item.productId == product.id)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");
                }
            }
        }
    }

    public void updateOrderStatus(Order order)
    {
        Console.WriteLine("Enter status:(True/false");
        bool status = ("true".Equals(Console.ReadLine().ToLower())) ? true : false;
        order.status = status;
    }

    public void displayOrderByName(List<Product> products)
    {
        foreach (var product in products)
        {
            foreach (var item in orders)
            {
                if (product.id == item.productId)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");

                }
            }
        }
    }
    public void displayOrderByFirstName(List<Product> products)
    {
        foreach (var product in products.OrderBy(p => { return Regex.Split(p.name, @"\s+").Last(); }))
        {
            foreach (var item in orders)
            {
                if (product.id == item.productId)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");

                }
            }
        }
    }

    public void displayAllFromJson(List<Order> ordersJson, List<Product> products)
    {
        foreach (var item in ordersJson)
        {
            foreach (var product in products)
            {
                if (item.productId == product.id)
                {
                    Console.WriteLine($" order detail: id {item.id}, customer name {item.name}, ordered quanity {item.quantity} and product: id {product.id}, name {product.name}, price {product.price}, quantity {product.quantity}");
                }
            }
        }
    }

}