class Library
{
    public string id;
    public string name;
    public List<Book> books;

    public Library(string id, string name)
    {
        this.id = id;
        this.name = name;
        books = new List<Book>();
    }

    public void addBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Successfully added");
    }

    public void showAll(List<Book> books)
    {
        foreach (var item in books)
        {
            item.infor();
        }
    }

    public void findBookById(string id)
    {
        var book = books.Find(x => x.id == id);
        if (book != null)
        {
            book.infor();
        }
        else
        {
            Console.WriteLine($"cant find {id}");
        }
    }

}