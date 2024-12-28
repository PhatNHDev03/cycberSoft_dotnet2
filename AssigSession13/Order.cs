class Order
{
    public string id;
    public string name;
    public string productId;
    public int quantity;
    public bool status;

    public Order(string id, string name, string productId, int quantity)
    {
        this.id = id;
        this.name = name;
        this.productId = productId;
        this.quantity = quantity;
        this.status = false;
    }
    public string getInfor()
    {
        var textCheck = (status == true) ? "Đã giao" : "chưa giao";
        return $"ordered id: {id}, customer name: {name}, ordered quanity: {quantity}, ordered status: {textCheck}";
    }



}