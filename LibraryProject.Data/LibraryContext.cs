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

            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Library)
                .HasForeignKey(b => b.LibraryId);

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

            modelBuilder.Entity<User>()
                .HasMany(u => u.BorrowBooks)
                .WithOne(bb => bb.User)
                .HasForeignKey(bb => bb.UserId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.BorrowBooks)
                .WithOne(bb => bb.Book)
                .HasForeignKey(bb => bb.BookId);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.BorrowBook)
                .WithOne(bb => bb.Borrow)
                .HasForeignKey<BorrowBook>(bb => bb.BorrowId);
        }

    }
}
