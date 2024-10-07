using LibraryProject.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Data
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("User ID=postgres; Password=admin; Server=localhost; Port=5432; Database=postgres; Pooling=True;");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь один ко многим: Library -> Books
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Library)
                .HasForeignKey(b => b.LibraryId);

            // Связь один ко многим: Library -> Users
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Users)
                .WithOne(u => u.Library)
                .HasForeignKey(u => u.LibraryId);

            // Связь многие ко многим: Book -> Author через BookAuthor
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            // Связь один ко многим: User -> BorrowBooks
            modelBuilder.Entity<User>()
                .HasMany(u => u.BorrowBooks)
                .WithOne(bb => bb.User)
                .HasForeignKey(bb => bb.UserId);

            // Связь один ко многим: Book -> BorrowBooks
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BorrowBooks)
                .WithOne(bb => bb.Book)
                .HasForeignKey(bb => bb.BookId);

            // Связь один к одному: Borrow -> BorrowBook
            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.BorrowBook)
                .WithOne(bb => bb.Borrow)
                .HasForeignKey<BorrowBook>(bb => bb.BorrowId);
        }
    }
}
