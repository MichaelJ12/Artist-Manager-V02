using ArtistManager.Data;
using ArtistManager.DTOs;
using ArtistManager.Models;
using ArtistManager.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtistManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ArtistManagerDbContext context, JwtService jwt) : ControllerBase {

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register) {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password, 12);

            var registerdUser = new User {
                Username = register.Username,
                Email = register.Email,
                PasswordHash = hashedPassword,
                Role = "Artist",
            };



            if (context.Users.Any(u => u.Username == register.Username) || context.Users.Any(u => u.Email == register.Email)) {
                return Conflict(new ProblemDetails {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Conflict",
                    Detail = "Username or Email is already taken."
                });
            }


            context.Users.Add(registerdUser);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(UsersController.GetUser), "Users", new { id = registerdUser.Id },new { registerdUser, jwt });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login) {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash)) {
                return Unauthorized(new ProblemDetails {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Conflict",
                    Detail = "Invalid email or password."
                });
            }

            var token = jwt.GenerateToken(user.Id.ToString(), user.Username, user.Role, user.Email);

            return Ok(new { user, token});

        }
    }

   
}
