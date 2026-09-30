using System.ComponentModel.DataAnnotations;

namespace ArtistManager.Models {
    public class User {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 2)]
        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public required string Role { get; set; }

        public ICollection<Artwork>? Artworks { get; set; }
    }
}
