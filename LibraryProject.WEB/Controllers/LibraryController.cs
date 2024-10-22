using LibraryProject.BL.Dtos;
using LibraryProject.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _service;

        public LibraryController(LibraryService service)
        {
            _service = service;
        }

        [HttpPost("add-library")]
        public IActionResult AddLibrary([FromBody] LibraryDto libraryDto)
        {
            var addedLibrary = _service.AddLibrary(libraryDto);
            return CreatedAtAction(nameof(GetLibraryById), new { id = addedLibrary.Id }, addedLibrary);
        }

        [HttpGet("get-libraries")]
        public IActionResult GetLibraries()
        {
            var libraries = _service.GetLibraries();
            if (libraries.Count == 0)
                return NotFound();
            return Ok(libraries);
        }

        [HttpGet("get-library/{id}")]
        public IActionResult GetLibraryById(int id)
        {
            var library = _service.GetLibraryById(id);
            if (library == null)
                return NotFound();
            return Ok(library);
        }

        [HttpPut("update-library/{id}")]
        public IActionResult UpdateLibrary(int id, [FromBody] LibraryDto libraryDto)
        {
            try
            {
                var updatedLibrary = _service.UpdateLibrary(id, libraryDto);
                return Ok(updatedLibrary);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete-library/{id}")]
        public IActionResult DeleteLibrary(int id)
        {
            try
            {
                _service.DeleteLibrary(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add-books/{libraryId}")]
        public IActionResult AddBooksToLibrary(int libraryId, [FromBody] List<int> bookIds)
        {
            try
            {
                _service.AddBooksToLibrary(libraryId, bookIds);
                return Ok("Книги успешно добавлены в библиотеку.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
