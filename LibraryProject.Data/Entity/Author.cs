using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entity;

internal class Author
{
    public int Id { get; set; }
    public string FullNameofAuthor { get; set; }
    public List<BookAuthor> Authors_Book { get; set; }
}
