using LibraryProject.Data.Entity;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Borrow> Borrow { get; set; }
    public int LibraryId { get; set; }
    public Library Library { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
}
