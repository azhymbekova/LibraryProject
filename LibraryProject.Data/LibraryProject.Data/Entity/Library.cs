public class Library
{
    public int LibraryId { get; set; }
    public string LibraryName { get; set; }
    public int OwnersId { get; set; }
    public List<int> ReadersId { get; set; }
    public string LibraryDescription { get; set; }
    public List<Book> LibraryBooks { get; set; }
    public DateTime LibraryDateTime { get; set; }

}
