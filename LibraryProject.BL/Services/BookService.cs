using LibraryProject.BL.Dtos;
using LibraryProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BL.Services;

public class BookService(BookRepository bookRepository,
    SimpleRepository<Library> libraryRepository);
{
    public Book AddBook(BookDto book)
    {
    var newBook = new Book
    {
        BookName = book.BookName,
        BookDescription = book.BookDescription
    };
        
    var addedBook = bookRepository.Add(newBook);

    libraryRepository.Add(new Library
    {
        BookId = addedBook.BookId,
    });

    bookRepository.SaveChanges();

    return addedBook;
    }
    
    public List<Book> GetBooks()
{
    return bookRepository.GetAllBooks();
}
}
