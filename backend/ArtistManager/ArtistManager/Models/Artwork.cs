using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArtistManager.Models {
    public class Artwork {

        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Title { get; set; }

        [Required]
        public required string ImageUrl { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
