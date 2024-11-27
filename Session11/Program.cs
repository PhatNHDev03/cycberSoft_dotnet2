

using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        #region  bai 1 quan ly lop hoc
        Console.WriteLine("================================================================");
        // Console.BackgroundColor = ConsoleColor.Yellow;
        // ClassRoom classRoom = new ClassRoom("C02", "DOTNET02");
        // int choice = 0;
        // do
        // {
        //     Console.WriteLine("-------Classroom management--------");
        //     Console.WriteLine("1.Them sing vien");
        //     Console.WriteLine("2.hien thi danh sach sinh vien");
        //     Console.WriteLine("3. find by ID");
        //     Console.WriteLine("4 End");
        //     choice = int.Parse(Console.ReadLine());
        //     switch (choice)
        //     {
        //         case (1):
        //             Console.WriteLine("Enter student Id:");
        //             int id = int.Parse(Console.ReadLine());
        //             Console.WriteLine("Enter student name");
        //             string name = Console.ReadLine();
        //             Console.WriteLine("Enter student Age");
        //             int age = int.Parse(Console.ReadLine());
        //             classRoom.addStudent(new Student(id, name, age));
        //             //luu danhs ach sinh vien vao json

        //             break;
        //         case (2):
        //             classRoom.showAll();
        //             break;
        //         case (3):
        //             Console.WriteLine("Please Enter Id Student to search");
        //             classRoom.findStudnetById(int.Parse(Console.ReadLine()));
        //             break;
        //         case (4):
        //             Console.WriteLine("Thank you");
        //             break;
        //     }
        // }
        // while (choice < 4);
        #endregion

        #region bai 2 quan ly thu vien

        Library library = new Library("C02", "DOTNET02");
        int choice = 0;
        do
        {
            Console.WriteLine("-------Classroom management--------");
            Console.WriteLine("1.Add book");
            Console.WriteLine("2.Display all Books");
            Console.WriteLine("3. find a book by ID");
            Console.WriteLine("4. End");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case (1):
                    Console.WriteLine("Enter book Id:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter book name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter author book");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter price");
                    double price = double.Parse(Console.ReadLine());
                    library.addBook(new Book(id, name, author, price));
                    //luu danh sach sinh vien vao json
                    var json = JsonConvert.SerializeObject(library.books);
                    File.WriteAllText("books.json", json);
                    break;
                case (2):
                    var bookJson = File.ReadAllText("books.json");
                    //json --> string json --> list
                    library.books = JsonConvert.DeserializeObject<List<Book>>(bookJson);
                    library.showAll(library.books);
                    break;
                case (3):
                    Console.WriteLine("Please Enter Id book to search");
                    library.findBookById(Console.ReadLine());
                    break;
                case (4):
                    Console.WriteLine("Thank you");
                    break;
            }
        }
        while (choice < 4);


        #endregion
    }





}