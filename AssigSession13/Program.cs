using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        #region assignment 1: student management in a room
        // Room room = new Room("N02", "NET02");
        // room.add(new Student(1, "Nguyen Hoang Phat1", 7.0, 8.0, 8.8));
        // room.add(new Student(2, "Trinh Xuan thanh", 9.0, 10.0, 10.0));
        // room.add(new Student(3, "Luong the tai", 7.0, 8.0, 8.8));
        // room.add(new Student(4, "Nguyen Duc Tung", 3.0, 4.0, 6.0));
        // room.add(new Student(5, "Nguyen Thai Dung", 3.0, 4.0, 2.0));
        // room.add(new Student(6, "Le Thi Cam", 6.0, 6.0, 7.0));
        // room.add(new Student(7, "Le Van Phat", 6.1, 6.0, 7.0));
        // room.add(new Student(8, "Nguyen Hoang An", 8.1, 8.0, 8.0));

        // int choice = 0;
        // do
        // {
        //     Console.WriteLine("-------Classroom management--------");
        //     Console.WriteLine("1. Add a student");
        //     Console.WriteLine("2. Find student by Name");
        //     Console.WriteLine("3. Update Point");
        //     Console.WriteLine("4. Average point list");
        //     Console.WriteLine("5. Delete a student by Id");
        //     Console.WriteLine("6. Display students list by calculating average point");
        //     Console.WriteLine("7. Display students list Ascending by calculating average point");
        //     Console.WriteLine("8. Display students list Ascending by searching first name");
        //     Console.WriteLine("9. display from file json");
        //     Console.WriteLine("10 .End");
        //     Console.WriteLine("Enter your choice:");
        //     Console.Write("My choice is:");
        //     choice = int.Parse(Console.ReadLine());
        //     switch (choice)
        //     {
        //         case (1):
        //             room.displayAll();
        //             Console.WriteLine("Please enter student ID:");
        //             if (!int.TryParse(Console.ReadLine(), out int id))
        //             {
        //                 Console.WriteLine("Please Enter a integer number for student id!!");
        //                 break;
        //             }
        //             if (room.checkId(id) == true)
        //             {
        //                 Console.WriteLine($"Stundent id {id} is already exist !!! ");
        //                 break;
        //             }
        //             Console.WriteLine("Please enter student name:");
        //             var name = Console.ReadLine();
        //             Console.WriteLine("Please enter math point:");
        //             double mathPoint = double.Parse(Console.ReadLine());
        //             Console.WriteLine("Please enter liturature point:");
        //             double lituraturePoint = double.Parse(Console.ReadLine());
        //             Console.WriteLine("Please enter english point:");
        //             double englishPoint = double.Parse(Console.ReadLine());
        //             room.add(new Student(id, name, mathPoint, lituraturePoint, englishPoint));
        //             Console.WriteLine("add successfully");
        //             room.displayAll();
        //             var json = JsonConvert.SerializeObject(room.students);
        //             File.WriteAllText("room.json", json);
        //             break;
        //         case (2):
        //             Console.WriteLine("Please enter your searching name to find a student by name");
        //             var searchingName = Console.ReadLine();
        //             room.searchByName(searchingName);
        //             break;
        //         case (3):
        //             Console.WriteLine("__________________UPDATED CHOICE:______________");
        //             Console.WriteLine("1. Update math point");
        //             Console.WriteLine("2. Update liturature point");
        //             Console.WriteLine("3. Update english point");
        //             Console.WriteLine("________________________________________________");
        //             Console.WriteLine("Please Enter your choice");
        //             if (!int.TryParse(Console.ReadLine(), out int updateChoice))
        //             {
        //                 Console.WriteLine("ERROR: Please Enter your choice as a integernumber !!!!");
        //                 break;
        //             }
        //             if (updateChoice < 1 || updateChoice > 3)
        //             {
        //                 Console.WriteLine("Error: Please Choice from 1 to 3 !!!");
        //                 break;
        //             }
        //             room.displayAll();
        //             Console.WriteLine("Enter student id to update point:");
        //             if (!int.TryParse(Console.ReadLine(), out int idChoice))
        //             {
        //                 Console.WriteLine("ERROR: Please Enter your id choice as a integernumber !!!!");
        //                 break;
        //             }
        //             room.updatePoint(idChoice, updateChoice);
        //             break;
        //         case (4):
        //             room.sortStundentByTheirAveragePoint();
        //             break;
        //         case (5):
        //             room.displayAll();
        //             Console.WriteLine("Enter id to delete");
        //             if (!int.TryParse(Console.ReadLine(), out int deleteChocie))
        //             {
        //                 Console.WriteLine("ERROR: Please Enter your choice as a integernumber !!!!");
        //                 break;
        //             }
        //             room.revemoveAStudent(deleteChocie);
        //             break;
        //         case (6):
        //             room.displayStudentWithAveragePoint();
        //             break;
        //         case (7):
        //             room.studentListBysortAsc();
        //             break;
        //         case (8):
        //             room.studentListBysortName();
        //             break;
        //         case (9):
        //             var studentFromJson = File.ReadAllText("room.json");
        //             room.students = JsonConvert.DeserializeObject<List<Student>>(studentFromJson);
        //             room.displayAll();
        //             break;
        //         case (10):
        //             Console.WriteLine("Thank you for using our program !!!");
        //             break;
        //     }
        // }
        // while (choice < 10);
        #endregion
        WareHouse wareHouse = new WareHouse("K0001", "Nhà kho");
        wareHouse.products = new List<Product>(){
            new Product("P0001", "Chao ca", 3.0, 10),
            new Product("P0002", "Bun bo", 4.0, 8),
            new Product("P0003", "Com chien Duong Chau", 7.0, 6)
        };

        OrderManagement orderManagement = new OrderManagement("O001", "OrderCustomer1");
        orderManagement.add(new Order("MO001", "Phat", "P0001", 1));
        orderManagement.add(new Order("MO002", "Phat", "P0002", 4));

        int choice2 = 0;
        do
        {
            // cai requirment 7 va 8 em gop lai lam 1 ạ ==> để em thêm chỗ update status va case 8 ạ
            Console.WriteLine("-------productmanagement--------");
            Console.WriteLine("1. Add a product in ordered list or in warehouse");
            Console.WriteLine("2. Find ordered product/warehouse product by product name");
            Console.WriteLine("3. Update iformation for product in ordered list or warehouse");
            Console.WriteLine("4. Total price product in warehouse");
            Console.WriteLine("5. Remove a product in warehouse/ in ordered list");
            Console.WriteLine("6. Show All product with total price in warehouse/ordered List");
            Console.WriteLine("7. Show ALl products which are sorted by asc");
            Console.WriteLine("8. Update status order list");
            Console.WriteLine("9. Show all products by sorting full name");
            Console.WriteLine("10. Show all products by sorting first name");
            Console.WriteLine("11. Read from json and display all");
            Console.WriteLine("12. Save All to file json");
            Console.WriteLine("13. END");
            Console.WriteLine("Enter your choice:");
            Console.Write("My choice is:");
            choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case (1):
                    Console.WriteLine("______ CHOICE LIST_____");
                    Console.WriteLine("1. Add a new product in warehouse");
                    Console.WriteLine("2. Create a ordered product");
                    Console.WriteLine("Please Enter your choice: ");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("___________________PRODUCTLIST_________________");
                            wareHouse.displayAll();
                            Console.WriteLine("Enter product id");
                            string newProductId = Console.ReadLine();
                            Console.WriteLine("Enter product name");
                            string newProductName = Console.ReadLine();
                            Console.WriteLine("Enter price");
                            double newProductPrice = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter product quantity");
                            int newProductQuantity = int.Parse(Console.ReadLine());
                            wareHouse.products.Add(new Product(newProductId, newProductName, newProductPrice, newProductQuantity));
                            Console.WriteLine("Add successfully !!");
                            Console.WriteLine("___________________PRODUCTLIST_________________");
                            wareHouse.displayAll();
                            break;
                        case 2:
                            Console.WriteLine("___________________PRODUCTLIST_________________");
                            wareHouse.displayAll();
                            Console.WriteLine("___________________ORDERED LIST__________________");
                            orderManagement.displayAll(wareHouse.products);
                            Console.WriteLine("Enter order id");
                            string orderId = Console.ReadLine();
                            Console.WriteLine("Enter customer name");
                            string customerName = Console.ReadLine();
                            Console.WriteLine("Enter productID (Enter valid product !!!):");
                            string productId = Console.ReadLine();
                            var product = wareHouse.getInforProductByID(productId);
                            if (product == null)
                            {
                                Console.WriteLine("ERROR: Please enter valid product !!!");
                                break;
                            }
                            Console.WriteLine("Enter oredered quantity");
                            int orederedQuantity = int.Parse(Console.ReadLine());
                            if (product.quantity < orederedQuantity)
                            {
                                Console.WriteLine("Error: Ordering over product quantity in the warehouse!!!");
                                break;
                            }
                            orderManagement.add(new Order(orderId, customerName, productId, orederedQuantity));
                            Console.WriteLine("___________________PRODUCTLIST_________________");
                            wareHouse.displayAll();
                            Console.WriteLine("___________________ORDERED LIST__________________");
                            orderManagement.displayAll(wareHouse.products);
                            Console.WriteLine("Enter order id");
                            break;
                    }
                    break;
                case (2):
                    Console.WriteLine("___________________PRODUCTLIST_________________");
                    wareHouse.displayAll();
                    Console.WriteLine("___________________ORDERED LIST__________________");
                    orderManagement.displayAll(wareHouse.products);
                    Console.WriteLine("Enter product name to search");
                    string searchingName = Console.ReadLine();
                    orderManagement.findByName(searchingName, wareHouse.products);
                    wareHouse.displayByName(searchingName);
                    break;
                case (3):
                    Console.WriteLine("1. Update price product in wareHouse");
                    Console.WriteLine("2. Update quantity product in wareHouse");
                    Console.WriteLine("3. Update quantity Ordered product ");
                    Console.WriteLine("Enter your choice:");
                    int updateChoice = int.Parse(Console.ReadLine());
                    if (updateChoice < 3)
                    {
                        wareHouse.displayAll();
                        Console.WriteLine("Enter product Id:");
                        string updatedProductId = Console.ReadLine();
                        wareHouse.updateProduct(updatedProductId, updateChoice);
                        wareHouse.getInforProductByID(updatedProductId).infor();
                    }
                    else
                    {
                        orderManagement.displayAll(wareHouse.products);
                        Console.WriteLine("Enter ordered ID:");
                        string orderId = Console.ReadLine();
                        Console.WriteLine("Enter udpate quantity");
                        int updateQuantityForOrderedList = int.Parse(Console.ReadLine());
                        orderManagement.updateQuantity(orderId, updateQuantityForOrderedList);
                        Console.WriteLine(orderManagement.checkOrder(orderId).getInfor());
                    }
                    break;
                case (4):
                    wareHouse.totalPrice();
                    break;
                case (5):
                    Console.WriteLine("1. Remove a product in warehouse");
                    Console.WriteLine("2. Remove a product in ordered list");
                    Console.WriteLine("Enter your choice:");
                    int removeChoice = int.Parse(Console.ReadLine());
                    if (removeChoice == 1)
                    {
                        wareHouse.displayAll();
                        Console.WriteLine("Enter product Id to remove it:");
                        string removeProductId = Console.ReadLine();
                        wareHouse.removeAproduct(removeProductId);
                        Console.WriteLine("After: ");
                        wareHouse.displayAll();
                    }
                    else
                    {
                        orderManagement.displayAll(wareHouse.products);
                        Console.WriteLine("Enter order Id to remove it:");
                        string removeOrderId = Console.ReadLine();
                        orderManagement.removeAorderedProduct(removeOrderId);
                        Console.WriteLine("After: ");
                        orderManagement.displayAll(wareHouse.products);
                    }
                    break;
                case (6):
                    Console.WriteLine("___________________ WAREHOUSE LIST___________________");
                    wareHouse.displayAllWithTotalPrice();
                    Console.WriteLine("___________________ORDERED LIST______________________");
                    orderManagement.displayAllWithTotalPrice(wareHouse.products);
                    break;
                case (7):
                    Console.WriteLine("___________________ WAREHOUSE LIST___________________");
                    wareHouse.displayAllWithPriceAsc();
                    Console.WriteLine("___________________ORDERED LIST______________________");
                    orderManagement.displayAllWithPriceAsc(wareHouse.products);
                    break;
                case (8):
                    orderManagement.displayAll(wareHouse.products);
                    Console.WriteLine("Enter order id to update status");
                    string orderdIdUpdate = Console.ReadLine();
                    var order = orderManagement.checkOrder(orderdIdUpdate);
                    if (order == null)
                    {
                        Console.WriteLine(" invalid ordered id !!!");
                        return;
                    }
                    Console.WriteLine("_______________________________________________");
                    Console.WriteLine("Before: ");
                    wareHouse.getInforProductByID(order.productId).infor();
                    Console.WriteLine("Ordered information");
                    Console.WriteLine(order.getInfor());
                    orderManagement.updateOrderStatus(order);
                    wareHouse.updateQuantityByUpdatingstatus(order.productId, order.quantity);
                    Console.WriteLine("_______________________________________________");
                    Console.WriteLine("After: ");
                    wareHouse.getInforProductByID(order.productId).infor();
                    Console.WriteLine("Ordered information");
                    Console.WriteLine(order.getInfor());
                    Console.WriteLine("_______________________________________________");
                    break;
                case (9):
                    Console.WriteLine("__________________________WAREHOUSE LIST_________________");
                    wareHouse.displayOrderByFullName();
                    Console.WriteLine("__________________________ORDER LIST_________________");
                    orderManagement.displayOrderByName((wareHouse.products.OrderBy(p => p.name)).ToList());
                    break;
                case (10):
                    Console.WriteLine("__________________________WAREHOUSE LIST_________________");
                    wareHouse.displayOrderByName();
                    Console.WriteLine("__________________________Ordered LIST_________________");
                    orderManagement.displayOrderByFirstName(wareHouse.products);
                    break;
                case (11):
                    Console.WriteLine("___________________WAREHOUSE LIST________________________");
                    var productFromJson = File.ReadAllText("products.json");
                    wareHouse.products = JsonConvert.DeserializeObject<List<Product>>(productFromJson);
                    wareHouse.displayAll();
                    Console.WriteLine("___________________ORDER LIST________________________");
                    var orderFromJson = File.ReadAllText("order.json");
                    var orderJsonFomart = JsonConvert.DeserializeObject<List<Order>>(orderFromJson);
                    orderManagement.displayAllFromJson(orderJsonFomart, wareHouse.products);
                    break;
                case (12):
                    var productjsonSave = JsonConvert.SerializeObject(wareHouse.products);
                    File.WriteAllText("products.json", productjsonSave);
                    var orderjsonSave = JsonConvert.SerializeObject(orderManagement.orders);
                    File.WriteAllText("order.json", orderjsonSave);
                    Console.WriteLine("save successfully !!");
                    break;
                case (13):
                    break;
            }
        }
        while (choice2 < 13);

    }
}