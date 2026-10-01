using System.ComponentModel.DataAnnotations;

namespace ArtistManager.DTOs {
    public class UserResponseDto {

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Email { get; set; }

        public required string Role { get; set; }

    }
}
