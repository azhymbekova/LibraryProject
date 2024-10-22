using LibraryProject.Data.Entity;

public class Borrow
{
    public long BorrowId { get; set; }
    public long UserId { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; } = new List<BorrowBook>();
    public DateTime CreateDate { get; set; }
    public BorrowBook BorrowBook { get; set; }
}
