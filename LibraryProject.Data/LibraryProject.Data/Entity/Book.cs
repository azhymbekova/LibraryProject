public class Book
{
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
    public DateTime BookDateTime { get; set; }
    public string AmountPages { get; set; }
    public int Rating { get; set; }
    //public ICollection<BorrowBook> BorrowBook { get; set; } = new List<BorrowBook>();
    //public ICollection<Library> Libraries { get; set; } = new List<Library>();
}
