namespace ArtistManager.Models {
    public class Artwork {

        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
