
namespace LibraryProject.Data.Entity;
public class Book : BaseEntity
{
    public long Id { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public DateTime BookDateTime { get; set; }
    public int AmountPages { get; set; }
    public int Rating { get; set; }

    public Library? Library { get; set; }
    public long? LibraryId { get; set; }

    public List<BorrowBook> BorrowBooks { get; set; }
}
