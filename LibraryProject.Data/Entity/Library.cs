public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Book> Books { get; set; }
    public long BookId { get; set; }
    public List<User> Users { get; set; }
}
