using LibraryProject.BL.Dtos;
using LibraryProject.Data.Repository;
using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Services;

public class LibraryService
{
    private readonly LibraryRepository _libraryRepository;
    private readonly BookRepository _bookRepository;

    public LibraryService(LibraryRepository libraryRepository, BookRepository bookRepository)
    {
        _libraryRepository = libraryRepository;
        _bookRepository = bookRepository;
    }

    public Library AddLibrary(LibraryDto libraryDto)
    {
        var newLibrary = new Library
        {
            Name = libraryDto.Name,
            Address = libraryDto.Address,
            Books = new List<Book>()
        };

        if (libraryDto.BookIds != null && libraryDto.BookIds.Any())
        {
            foreach (var bookId in libraryDto.BookIds)
            {
                var book = _bookRepository.GetById(bookId);
                if (book != null)
                {
                    newLibrary.Books.Add(book);
                }
            }
        }

        var addedLibrary = _libraryRepository.Add(newLibrary);
        _libraryRepository.SaveChanges();

        return addedLibrary;
    }

    public List<Library> GetLibraries()
    {
        return _libraryRepository.GetAll();
    }

    public Library GetLibraryById(int id)
    {
        return _libraryRepository.GetById(id);
    }

    public Library UpdateLibrary(int id, LibraryDto libraryDto)
    {
        var existingLibrary = _libraryRepository.GetById(id);
        if (existingLibrary == null)
        {
            throw new Exception("Библиотека не найдена.");
        }

        existingLibrary.Name = libraryDto.Name;
        existingLibrary.Address = libraryDto.Address;

        _libraryRepository.Update(existingLibrary);
        _libraryRepository.SaveChanges();

        return existingLibrary;
    }

    public void DeleteLibrary(int id)
    {
        var libraryToDelete = _libraryRepository.GetById(id);
        if (libraryToDelete == null)
        {
            throw new Exception("Библиотека не найдена.");
        }

        _libraryRepository.Delete(libraryToDelete);
        _libraryRepository.SaveChanges();
    }

    public void AddBooksToLibrary(int libraryId, List<int> bookIds)
    {
        var library = _libraryRepository.GetById(libraryId);
        if (library == null)
        {
            throw new Exception("Библиотека не найдена.");
        }

        foreach (var bookId in bookIds)
        {
            var book = _bookRepository.GetById(bookId);
            if (book != null)
            {
                library.Books.Add(book);
            }
        }

        _libraryRepository.Update(library);
        _libraryRepository.SaveChanges();
    }
}
