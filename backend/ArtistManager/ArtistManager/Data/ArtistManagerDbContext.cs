using ArtistManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtistManager.Data
{
    public class ArtistManagerDbContext : DbContext
    {
        public ArtistManagerDbContext(DbContextOptions<ArtistManagerDbContext> options) : base(options) { }

        public DbSet<Artwork> Artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Artwork>().HasData(
                new Artwork { Id = 1, Title = "Sunset over the bay", ImageUrl = "https://picsum.photos/seed/artwork1/400/300", UserId = 1 },
                new Artwork { Id = 2, Title = "Portrait study", ImageUrl = "https://picsum.photos/seed/artwork2/400/300", UserId = 1 },
                new Artwork { Id = 3, Title = "Mountain landscape", ImageUrl = "https://picsum.photos/seed/artwork3/400/300", UserId = 1 },
                new Artwork { Id = 4, Title = "Abstract composition", ImageUrl = "https://picsum.photos/seed/artwork4/400/300", UserId = 1 },
                new Artwork { Id = 5, Title = "Urban street scene", ImageUrl = "https://picsum.photos/seed/artwork5/400/300", UserId = 1 },
                new Artwork { Id = 6, Title = "Still life with flowers", ImageUrl = "https://picsum.photos/seed/artwork6/400/300", UserId = 1 }
            );
        }
    }
}
