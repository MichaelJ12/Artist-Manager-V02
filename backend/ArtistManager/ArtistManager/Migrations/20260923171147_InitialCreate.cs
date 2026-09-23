using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtistManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork1/400/300", "Sunset over the bay", new DateTime(2024, 1, 15, 10, 30, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, new DateTime(2024, 1, 16, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork2/400/300", "Portrait study", new DateTime(2024, 1, 16, 10, 30, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, new DateTime(2024, 1, 17, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork3/400/300", "Mountain landscape", new DateTime(2024, 1, 17, 10, 30, 0, 0, DateTimeKind.Utc), 1 },
                    { 4, new DateTime(2024, 1, 18, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork4/400/300", "Abstract composition", new DateTime(2024, 1, 18, 10, 30, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, new DateTime(2024, 1, 19, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork5/400/300", "Urban street scene", new DateTime(2024, 1, 19, 10, 30, 0, 0, DateTimeKind.Utc), 1 },
                    { 6, new DateTime(2024, 1, 20, 10, 30, 0, 0, DateTimeKind.Utc), "https://picsum.photos/seed/artwork6/400/300", "Still life with flowers", new DateTime(2024, 1, 20, 10, 30, 0, 0, DateTimeKind.Utc), 1 }
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
