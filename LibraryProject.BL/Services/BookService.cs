using LibraryProject.BL.Dtos;
using LibraryProject.Data.Repository;
using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Services;

public class BookService(BookRepository bookRepository,
    SimpleRepository<Library> libraryRepository)
{
    public Book AddBook(BookDto book)
    {
        var newBook = new Book
        {
            BookName = book.BookName,
            BookDescription = book.BookDescription
        };

        var addedBook = bookRepository.Add(newBook);

        /*libraryRepository.Add(new Library
        {
            BookId = addedBook.Id,
            LibraryId = book.LibraryId
        });
        */
        bookRepository.SaveChanges();

        return addedBook;
    }


    public List<Book> GetBooks()
    {
        return bookRepository.GetAll();
    }

    public Book GetBookById(int id)
    {
        return bookRepository.GetById(id);
    }

    public Book UpdateBook(long id, BookDto bookDto)
    {
        var existingBook = bookRepository.GetById(id);
        if (existingBook == null)
        {
            throw new Exception("Книга не найдена.");
        }

        existingBook.BookName = bookDto.BookName;
        existingBook.BookDescription = bookDto.BookDescription;
        existingBook.AmountPages = bookDto.AmountPages;

        bookRepository.Update(existingBook);
        bookRepository.SaveChanges();

        return existingBook;
    }

    public void DeleteBook(long id)
    {
        var bookToDelete = bookRepository.GetById(id);
        if (bookToDelete == null)
        {
            throw new Exception("Книга не найдена.");
        }

        bookRepository.Delete(bookToDelete);
        bookRepository.SaveChanges();
    }

}
