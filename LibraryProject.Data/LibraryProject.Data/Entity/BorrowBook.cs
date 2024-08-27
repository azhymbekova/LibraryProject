public class BorrowBook
{
    public int Id { get; set; }
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public DateTime DueDate { get; set; }

    public Borrow Borrow { get; set; }
    public Book Book { get; set; }
}
