using LibraryProject.Data.Entity;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Borrow> Borrow { get; set; }
    public long LibraryId { get; set; }
    public Library Library { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
}
