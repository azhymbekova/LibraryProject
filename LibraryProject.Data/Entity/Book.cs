using LibraryProject.Data.Entity;

public class Book
{
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
    public List<BookAuthor> BookAuthor { get; set; }
    public DateTime BookDateTime { get; set; }
    public int AmountPages { get; set; }
    public int Rating { get; set; }

    public Library Library { get; set; }
    public int LibraryId { get; set; }

    public List<BorrowBook> BorrowBooks { get; set; }
}
