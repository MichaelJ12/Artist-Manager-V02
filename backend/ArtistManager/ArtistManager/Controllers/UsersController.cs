using ArtistManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtistManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ArtistManagerDbContext context) : ControllerBase {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await context.Users
                .Include(u => u.Artworks)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return NotFound(new ProblemDetails {
                Status = StatusCodes.Status404NotFound,
                Title = "NotFound",
                Detail = "User not found."
            });

            return Ok(user);
        }

    }
}
