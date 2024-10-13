using LibraryProject.Data.Entity;

namespace LibraryProject.Data.Repository;

public class LibraryRepository : Repository<Library>
{
    public LibraryRepository(LibraryContext context) : base(context)
    {
    }

    public override Library Add(Library entity)
    {
        var addedLibrary = base.Add(entity); 
        SaveChanges(); 
        return addedLibrary; 
    }

    public override void Update(Library entity)
    {

        base.Update(entity); 
        SaveChanges(); 
    }

    public override void Delete(Library entity)
    {

        base.Delete(entity); 
        SaveChanges(); 
    }
}
