using System.Text.RegularExpressions;
using Newtonsoft.Json;

class Room
{
    public string roomId;
    public string roomName;
    public List<Student> students;

    public Room(string roomId, string roomName)
    {
        this.roomId = roomId;
        this.roomName = roomName;
        students = new List<Student>();
    }

    public bool checkId(int id)
    {
        var foundedStudent = students.Find(s => s.id == id);
        if (foundedStudent != null)
        {
            return true;
        }
        return false;
    }
    public void add(Student? student)
    {
        students.Add(student);
    }
    public void displayAll()
    {
        Console.WriteLine("________________________LIST STUDENT_____________________________");
        if (File.Exists("room.json") == true)
        {
            var studentFromJson = File.ReadAllText("room.json");
            students = JsonConvert.DeserializeObject<List<Student>>(studentFromJson);
        }
        if (students != null)
        {
            foreach (var student in students)
            {
                student.infor();
            }
        }
        Console.WriteLine("__________________________________________________________________");
    }
    public void searchByName(string name)
    {
        var foundedstudentsList = students.FindAll(x => x.name.IndexOf(name) > -1);
        if (foundedstudentsList == null)
        {
            Console.WriteLine($"Can't find student name: {name}");
            return;
        }
        Console.WriteLine("Founded Students/student !!");
        foreach (var student in foundedstudentsList)
        {
            student.infor();
        }
    }

    public void updatePoint(int id, int choice)
    {
        var student = students.Find(x => x.id == id);
        if (student == null)
        {
            Console.WriteLine($"Can't find student Id: {id}");
            return;
        }
        Console.WriteLine("Please Enter updated point");

        if (!int.TryParse(Console.ReadLine(), out int updatePoint))
        {
            Console.WriteLine("please enter correct point");
            return;
        }

        if (updatePoint < 0)
        {
            Console.WriteLine("Please enter point equal or bigger than zero!!");
            return;
        }
        Console.Write("before: ");
        student.infor();
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                student.mathPoint = updatePoint;
                break;
            case 2:
                student.mathPoint = updatePoint;
                break;
            case 3:
                student.mathPoint = updatePoint;
                break;
        }
        Console.WriteLine("Update successfully");
        Console.Write("After: ");
        student.infor();
        Console.WriteLine("");
    }

    public void sortStundentByTheirAveragePoint()
    {
        Console.WriteLine("_______________________AVERAGE LIST_______________________");
        var listTemp = students.FindAll(x => x.argPoint() < 5);
        Console.WriteLine("Học sinh yếu");
        foreach (var student in listTemp)
        {
            student.infor();
        }
        listTemp = (students.FindAll(x => x.argPoint() >= 5 && x.argPoint() < 6.5));
        Console.WriteLine("Học sinh Trung bình");
        foreach (var student in listTemp)
        {
            student.infor();
        }
        listTemp = (students.FindAll(x => x.argPoint() >= 6.5 && x.argPoint() < 8));
        Console.WriteLine("Học sinh Khá");
        foreach (var student in listTemp)
        {
            student.infor();
        }
        listTemp = (students.FindAll(x => x.argPoint() >= 8 && x.argPoint() <= 10));
        Console.WriteLine("Học sinh Giỏi");
        foreach (var student in listTemp)
        {
            student.infor();
        }
    }

    public void revemoveAStudent(int id)
    {
        var student = students.Find(s => s.id == id);
        if (student == null)
        {
            Console.WriteLine($"Can't find student id: {id}");
            return;
        }
        students.Remove(student);
        Console.WriteLine("Remove sucessfully !!!");
        Console.WriteLine("____________________After_____________________");
        displayAll();
    }

    public void displayStudentWithAveragePoint()
    {
        Console.WriteLine("_____________________ AVERAGE LIST __________________________");
        foreach (var student in students)
        {
            Console.Write($"id: {student.id}, name: {student.name}, math: {student.mathPoint}, literature: {student.literaturePoint}, english: {student.englishPoint}, Average: {student.argPoint()}, ");
            if (student.argPoint() < 5)
            {
                Console.WriteLine("average: Yếu");
            }
            else if (student.argPoint() >= 5 && student.argPoint() < 6.5)
            {
                Console.WriteLine("average: trung bình");
            }
            else if (student.argPoint() >= 6.5 && student.argPoint() < 8)
            {
                Console.WriteLine("average: Khá");
            }
            else if (student.argPoint() >= 8 && student.argPoint() <= 10)
            {
                Console.WriteLine("average: Giỏi");
            }
        }
    }

    public void studentListBysortAsc()
    {
        foreach (var student in students.OrderBy(s => s.argPoint()))
        {
            student.infor();
        }
    }

    public void studentListBysortName()
    {
        Console.WriteLine("List sort by name");
        // using lambda block to clean code ༼ つ ◕_◕ ༽つ
        foreach (var student in students.OrderBy(s =>
        {
            var name = Regex.Split(s.name, @"\s+");
            return name[2].Length > 0 ? name[2] : "";
        }
        ))
        {
            student.infor();
        }

    }

}