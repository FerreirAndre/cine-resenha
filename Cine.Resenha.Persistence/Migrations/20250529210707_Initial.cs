using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cine.Resenha.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoChose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    WatchedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CoverLink", "Duration", "Rating", "ReleaseYear", "Summary", "Title", "Watched", "WatchedDate", "WhoChose" },
                values: new object[,]
                {
                    { 1, "https://br.web.img3.acsta.net/c_310_420/medias/nmedia/18/87/84/14/20028635.jpg", 129, 3.0m, 2006, "Elizabeth Bennet vive com sua mãe, pai e irmãs no campo, na Inglaterra. Por ser uma das filhas mais velhas, ela enfrenta uma crescente pressão de seus pais para se casar. Quando Elizabeth é apresentada ao belo e rico Darcy, faíscas voam. Embora haja uma química óbvia entre os dois, a natureza excessivamente reservada de Darcy ameaça a relação.", "Orgulho e Preconceito", true, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Izabella" },
                    { 2, "https://m.media-amazon.com/images/M/MV5BZDUyOGEwMGYtM2ViNi00MjY3LTk4YzktNWJmZmY2NGFiNTgzXkEyXkFqcGc@._V1_.jpg", 90, 4.5m, 1986, "His Motorbike, Her Island tells the story of Koh, a young biker who finds solace in his motorcycle after a breakup, and Miyo, a free-spirited girl on an island who becomes captivated by his bike. Their connection deepens, and Miyo develops a passion for motorcycles, leading to a bittersweet story of love, loss, and the transformative power of the open road", "His Motorbike Her Island", true, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teteu" },
                    { 3, "https://m.media-amazon.com/images/M/MV5BOWQ4YTBmNTQtMDYxMC00NGFjLTkwOGQtNzdhNmY1Nzc1MzUxXkEyXkFqcGc@._V1_.jpg", 117, 5.0m, 1982, "No século 21, uma corporação desenvolve clones humanos para serem usados como escravos em colônias fora da Terra, identificados como replicantes. Em 2019, um ex-policial é acionado para caçar um grupo fugitivo vivendo disfarçado em Los Angeles.", "Bladerunner", true, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andre" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
