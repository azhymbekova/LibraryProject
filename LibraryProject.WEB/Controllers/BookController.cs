using LibraryProject.BL.Dtos;
using LibraryProject.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            var addedBook = _service.AddBook(book);
            return Ok(addedBook); 
        }

        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            var books = _service.GetBooks();
            if(books.Count() == 0)
                return NotFound();
            return Ok(books);
        }
        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(long id)
        {
            try
            {
                _service.DeleteBook(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        }
        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(long id, [FromBody] BookDto bookDto)
        {
            try
            {
                var updatedBook = _service.UpdateBook(id, bookDto); 
                return Ok(updatedBook); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _service.GetBookById(id); 

            if (book == null) return NotFound("Книга не найдена.");

            return Ok(book);
        }

    }
}
