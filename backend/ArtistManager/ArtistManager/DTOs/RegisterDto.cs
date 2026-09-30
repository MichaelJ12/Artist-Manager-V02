using System.ComponentModel.DataAnnotations;
using ArtistManager.Models;

namespace ArtistManager.DTOs {
    public class RegisterDto {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 2)]
        public required string Email { get; set; }

        [MinLength(8)]
        public required string PasswordHash { get; set; }

    }
}
