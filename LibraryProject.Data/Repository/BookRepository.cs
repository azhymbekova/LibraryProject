using LibraryProject.Data.Entity;
namespace LibraryProject.Data.Repository;
public class BookRepository : Repository<Book>
{
    public BookRepository(LibraryContext context) : base(context)
    {
    }

    public override Book Add(Book entity)
    {
        SaveChanges();

        base.Update(entity);

        return entity;
    }
}

