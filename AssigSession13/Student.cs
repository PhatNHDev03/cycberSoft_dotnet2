class Student
{
    public int id;
    public string name;
    public double mathPoint;
    public double literaturePoint;
    public double englishPoint;
    public Student(int id, string name, double mathPoint, double literaturePoint, double englishPoint)
    {
        this.id = id;
        this.name = name;
        this.mathPoint = mathPoint;
        this.literaturePoint = literaturePoint;
        this.englishPoint = englishPoint;
    }

    public void infor()
    {
        Console.WriteLine($"id: {id}, name: {name}, math: {mathPoint}, literature: {literaturePoint}, english: {englishPoint}, Average: {argPoint()}");
    }

    public Double argPoint()
    {
        return (this.mathPoint + this.literaturePoint + this.englishPoint) / 3;
    }

}