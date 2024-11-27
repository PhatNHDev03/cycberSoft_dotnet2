class Student
{
    public int id;
    public string name;
    public int age;

    public Student(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    public void Information()
    {
        Console.WriteLine($"Id học sinh: {id}, Tên học sinh{name}, Tuổi học sinh {age}");
    }


}