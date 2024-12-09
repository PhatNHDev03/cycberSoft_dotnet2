using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {

        #region assignment 1: student management in a room
        Room room = new Room("N02", "NET02");
        room.add(new Student(1, "Nguyen Hoang Phat1", 7.0, 8.0, 8.8));
        room.add(new Student(2, "Trinh Xuan thanh", 9.0, 10.0, 10.0));
        room.add(new Student(3, "Luong the tai", 7.0, 8.0, 8.8));
        room.add(new Student(4, "Nguyen Duc Tung", 3.0, 4.0, 6.0));
        room.add(new Student(5, "Nguyen Thai Dung", 3.0, 4.0, 2.0));
        room.add(new Student(6, "Le Thi Cam", 6.0, 6.0, 7.0));
        room.add(new Student(7, "Le Van Phat", 6.1, 6.0, 7.0));
        room.add(new Student(8, "Nguyen Hoang An", 8.1, 8.0, 8.0));

        int choice = 0;
        do
        {
            Console.WriteLine("-------Classroom management--------");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Find student by Name");
            Console.WriteLine("3. Update Point");
            Console.WriteLine("4. Average point list");
            Console.WriteLine("5. Delete a student by Id");
            Console.WriteLine("6. Display students list by calculating average point");
            Console.WriteLine("7. Display students list Ascending by calculating average point");
            Console.WriteLine("8. Display students list Ascending by searching first name");
            Console.WriteLine("9. display from file json");
            Console.WriteLine("10 .End");
            Console.WriteLine("Enter your choice:");
            Console.Write("My choice is:");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case (1):
                    room.displayAll();
                    Console.WriteLine("Please enter student ID:");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Please Enter a integer number for student id!!");
                        break;
                    }
                    if (room.checkId(id) == true)
                    {
                        Console.WriteLine($"Stundent id {id} is already exist !!! ");
                        break;
                    }
                    Console.WriteLine("Please enter student name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Please enter math point:");
                    double mathPoint = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter liturature point:");
                    double lituraturePoint = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter english point:");
                    double englishPoint = double.Parse(Console.ReadLine());
                    room.add(new Student(id, name, mathPoint, lituraturePoint, englishPoint));
                    Console.WriteLine("add successfully");
                    room.displayAll();
                    var json = JsonConvert.SerializeObject(room.students);
                    File.WriteAllText("room.json", json);
                    break;
                case (2):
                    Console.WriteLine("Please enter your searching name to find a student by name");
                    var searchingName = Console.ReadLine();
                    room.searchByName(searchingName);
                    break;
                case (3):
                    Console.WriteLine("__________________UPDATED CHOICE:______________");
                    Console.WriteLine("1. Update math point");
                    Console.WriteLine("2. Update liturature point");
                    Console.WriteLine("3. Update english point");
                    Console.WriteLine("________________________________________________");
                    Console.WriteLine("Please Enter your choice");
                    if (!int.TryParse(Console.ReadLine(), out int updateChoice))
                    {
                        Console.WriteLine("ERROR: Please Enter your choice as a integernumber !!!!");
                        break;
                    }
                    if (updateChoice < 1 || updateChoice > 3)
                    {
                        Console.WriteLine("Error: Please Choice from 1 to 3 !!!");
                        break;
                    }
                    room.displayAll();
                    Console.WriteLine("Enter student id to update point:");
                    if (!int.TryParse(Console.ReadLine(), out int idChoice))
                    {
                        Console.WriteLine("ERROR: Please Enter your id choice as a integernumber !!!!");
                        break;
                    }
                    room.updatePoint(idChoice, updateChoice);
                    break;
                case (4):
                    room.sortStundentByTheirAveragePoint();
                    break;
                case (5):
                    room.displayAll();
                    Console.WriteLine("Enter id to delete");
                    if (!int.TryParse(Console.ReadLine(), out int deleteChocie))
                    {
                        Console.WriteLine("ERROR: Please Enter your choice as a integernumber !!!!");
                        break;
                    }
                    room.revemoveAStudent(deleteChocie);
                    break;
                case (6):
                    room.displayStudentWithAveragePoint();
                    break;
                case (7):
                    room.studentListBysortAsc();
                    break;
                case (8):
                    room.studentListBysortName();
                    break;
                case (9):
                    var studentFromJson = File.ReadAllText("room.json");
                    room.students = JsonConvert.DeserializeObject<List<Student>>(studentFromJson);
                    room.displayAll();
                    break;
                case (10):
                    Console.WriteLine("Thank you for using our program !!!");
                    break;
            }
        }
        while (choice < 10);
        #endregion
    }
}