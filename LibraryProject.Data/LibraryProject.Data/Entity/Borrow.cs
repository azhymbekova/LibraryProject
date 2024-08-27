public class Borrow
{
    public long BorrowId { get; set; }
    public long UserId { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
    public DateTime CreateDate { get; set; }

}
