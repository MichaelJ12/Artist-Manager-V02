using ArtistManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtistManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworksController : ControllerBase {

        private readonly ArtistManagerDbContext _context;

        public ArtworksController(ArtistManagerDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var artworks = await _context.Artworks.ToListAsync();
            return Ok(artworks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id) {
            var artwork = await _context.Artworks.FindAsync(id);

            if (artwork == null) return NotFound();

            return Ok(artwork);

        }
    }
}
