class Student
{
    public string id;
    public string name;
    public int age;

    public Student(string id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    public void Information()
    {
        Console.WriteLine("Id học sinh");
        Console.WriteLine($"{id}");
        Console.WriteLine("Tên học sinh");
        Console.WriteLine($"{name}");
        Console.WriteLine("Tuổi học sinh");
        Console.WriteLine($"{age}");
    }


}