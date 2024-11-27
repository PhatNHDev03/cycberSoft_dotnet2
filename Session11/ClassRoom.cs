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

    

}