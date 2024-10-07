using LibraryProject.BL.Dtos;
using LibraryProject.BL.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
