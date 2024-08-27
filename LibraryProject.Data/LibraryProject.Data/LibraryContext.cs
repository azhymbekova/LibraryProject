

public class LibraryContext : IdentityDbContext<ApplicationUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BorrowBook> BorrowBooks { get; set; }
    public DbSet<Borrow> Borrows { get; set; }
    public DbSet<Library> Libraries { get; set; }


    
}