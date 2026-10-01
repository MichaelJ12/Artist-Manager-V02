using System.Security.Cryptography;
using System.Text;
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
    public class AuthController(ArtistManagerDbContext context, JwtService jwtService) : ControllerBase {

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto register) {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await context.Users.AnyAsync(u => u.Username == register.Username || u.Email == register.Email)) {
                return Conflict(new ProblemDetails {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Conflict",
                    Detail = "Username or Email is already taken."
                });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password, 12);

            var registerdUser = new User {
                Username = register.Username,
                Email = register.Email,
                PasswordHash = hashedPassword,
                Role = "Artist",
            };

            var userResponse = new UserResponseDto {
                Email = registerdUser.Email,
                Username = registerdUser.Username,
                Role = registerdUser.Role
            };

            context.Users.Add(registerdUser);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(UsersController.GetUser), "Users", new { id = registerdUser.Id }, userResponse );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login) {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash)) {
                return Unauthorized(new ProblemDetails {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized",
                    Detail = "Invalid email or password."
                });
            }

            var (accessToken, refreshToken) = jwtService.GenerateTokens(user);

            await context.SaveChangesAsync();

            return Ok(new LoginResponse { AccessToken = accessToken, RefreshToken = refreshToken });

        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest request) {

            var tokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(request.RefreshToken)));

            var storedToken = await context.RefreshTokens.FirstOrDefaultAsync(t =>
                t.TokenHash == tokenHash &&
                !t.IsRevoked &&
                t.ExpiresAt > DateTime.UtcNow);

            if (storedToken is null) {
                return Unauthorized();
            }

            storedToken.IsRevoked = true;

            var user = await context.Users.FindAsync(storedToken.UserId);
            if (user is null) {
                return Unauthorized();
            }

            var (accessToken, refreshToken) = jwtService.GenerateTokens(user);

            await context.SaveChangesAsync();

            return Ok(new LoginResponse {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshRequest request) {
            var refreshToken = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(request.RefreshToken)));
            var token = await context.RefreshTokens.FirstOrDefaultAsync(r =>
                r.TokenHash == refreshToken &&
                !r.IsRevoked &&
                r.ExpiresAt > DateTime.UtcNow);

            if (token is null) {
                return Unauthorized();
            }

            token.IsRevoked = true;

            await context.SaveChangesAsync();

            return Ok();
        }
    }

   
}
