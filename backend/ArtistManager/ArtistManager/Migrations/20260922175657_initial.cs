using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtistManager.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/artwork1/400/300", "Sunset over the bay", 1 },
                    { 2, "https://picsum.photos/seed/artwork2/400/300", "Portrait study", 1 },
                    { 3, "https://picsum.photos/seed/artwork3/400/300", "Mountain landscape", 1 },
                    { 4, "https://picsum.photos/seed/artwork4/400/300", "Abstract composition", 1 },
                    { 5, "https://picsum.photos/seed/artwork5/400/300", "Urban street scene", 1 },
                    { 6, "https://picsum.photos/seed/artwork6/400/300", "Still life with flowers", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");
        }
    }
}
