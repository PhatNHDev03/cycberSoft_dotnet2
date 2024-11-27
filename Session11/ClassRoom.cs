class ClassRoom
{
    public string classId;
    public string className;
    public List<Student> students;

    public ClassRoom(string classId, string className)
    {
        this.classId = classId;
        this.className = className;
        this.students = new List<Student>();
    }

    public void addStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine($"successfully added to class {className}!");
    }

    public void showAll()
    {
        Console.WriteLine("\n_________________________");
        Console.WriteLine("List of students");
        foreach (var student in students)
        {
            student.Information();
        }
        Console.WriteLine("============================");
    }

    public void findStudnetById(int foundId)
    {
        var student = students.Find(s => s.id == foundId);
        if (student != null)
        {
            student.Information();
        }
        else
        {
            Console.WriteLine($"not found student ID: {foundId}");
        }

    }

}