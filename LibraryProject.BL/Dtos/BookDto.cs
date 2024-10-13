using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Dtos
{
    public class BookDto
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int AmountPages { get; set; } 
        public int? LibraryId { get; set; }
        public DateTime BookDateTime { get; set; }
        //public List<BookAuthor> BookAuthors { get; set; }

    }
}
