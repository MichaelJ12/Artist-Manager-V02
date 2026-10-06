using ArtistManager.Data;
using ArtistManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtistManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworksController(ArtistManagerDbContext context) : ControllerBase {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var artworks = await context.Artworks.OrderByDescending(a => a.CreatedAt).ThenByDescending(a => a.UpdatedAt).ToListAsync();


            return Ok(artworks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var artwork = await context.Artworks.FindAsync(id);

            if (artwork == null) return NotFound();

            return Ok(artwork);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string title, IFormFile image, [FromForm] int userId) {
            // refactor this into service
            if (image == null || image.Length == 0) return BadRequest("Image is required.");

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine("wwwroot/images", fileName);

            Directory.CreateDirectory("wwwroot/images"); 

            using (var stream = new FileStream(filePath, FileMode.Create)) {
                await image.CopyToAsync(stream);
            }
            
            var artwork = new Artwork {
                Title = title,
                ImageUrl = $"/images/{fileName}",
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Artworks.Add(artwork);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = artwork.Id }, artwork);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Artwork updatedArtwork) {
            var artwork = await context.Artworks.FindAsync(id);

            if (artwork == null) return NotFound();

            artwork.Title = updatedArtwork.Title;
            artwork.ImageUrl = updatedArtwork.ImageUrl;
            artwork.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
