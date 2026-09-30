using ArtistManager.Data;
using ArtistManager.DTOs;
using ArtistManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtistManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ArtistManagerDbContext context) : ControllerBase {

        [HttpPost("register")]
        public async Task<IActionResult> Login(RegisterDto registerDto) {

            var user = new User {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = registerDto.PasswordHash,
                Role = "Artist",
            };

            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
