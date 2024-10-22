
using LibraryProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MainMenuController : ControllerBase
{
    private readonly LibraryContext _context;

    public MainMenuController(LibraryContext context)
    {
        _context = context;
    }

    // Главная страница - отображение всех книг с кратким описанием
    [HttpGet("books")]
    public IActionResult GetBooks(string search = "", string sortBy = "")
    {
        var books = _context.Books.AsQueryable();

        // Поиск и фильтрация
        if (!string.IsNullOrEmpty(search))
        {
            books = books.Where(b => b.Title.Contains(search) || b.BookAuthors.Contains(search));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            books = sortBy.ToLower() switch
            {
                "title" => books.OrderBy(b => b.Title),
                "author" => books.OrderBy(b => b.BookAuthors),
                "date" => books.OrderBy(b => b.BookDateTime),
                _ => books
            };
        }

        var result = books.Select(b => new
        {
            b.Id,
            b.Title,
            b.BookAuthors,
            ShortDescription = b.BookDescription.Length > 100 
                ? b.BookDescription.Substring(0, 100) + "..." 
                : b.BookDescription
        }).ToList();

        return Ok(result);
    }

    // Переход в личный кабинет
    [HttpGet("cabinet")]
    public IActionResult GoToUserCabinet()
    {
        return Redirect("/api/UserCabinet");
    }
}
