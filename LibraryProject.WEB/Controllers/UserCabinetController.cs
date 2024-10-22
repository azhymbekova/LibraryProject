
using LibraryProject.BL.Dtos;
using LibraryProject.Data; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserCabinetController : ControllerBase
{
    private readonly LibraryContext _context;

    public UserCabinetController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var user = _context.Users.Find(userId);

        if (user == null) return NotFound("Пользователь не найден.");

        var userDto = new UserDTO
        {
            Id = user.Id,
            Username = user.Username
        };

        return Ok(userDto);
    }
}
