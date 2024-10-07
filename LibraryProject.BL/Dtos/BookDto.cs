namespace LibraryProject.BL.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public DateTime BookDateTime { get; set; }
        public int AmountPages { get; set; } 
        public int Rating { get; set; }
        public int LibraryId { get; set; }
    }
}
