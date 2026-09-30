using System.ComponentModel.DataAnnotations;

namespace ArtistManager.DTOs {
    public class LoginDto {

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 2)]
        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
