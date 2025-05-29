using Cine.Resenha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Resenha.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Orgulho e Preconceito",
                    Summary =
                        "Elizabeth Bennet vive com sua mãe, pai e irmãs no campo, na Inglaterra. Por ser uma das filhas mais velhas, ela enfrenta uma crescente pressão de seus pais para se casar. Quando Elizabeth é apresentada ao belo e rico Darcy, faíscas voam. Embora haja uma química óbvia entre os dois, a natureza excessivamente reservada de Darcy ameaça a relação.",
                    CoverLink = "https://br.web.img3.acsta.net/c_310_420/medias/nmedia/18/87/84/14/20028635.jpg",
                    WhoChose = "Izabella",
                    ReleaseYear = 2006,
                    WatchedDate = new DateTime(2025, 4, 27),
                    Rating = 3.0m,
                    Duration = 129,
                    Watched = true
                },
                new Movie
                {
                    Id = 2,
                    Title = "His Motorbike Her Island",
                    Summary =
                        "His Motorbike, Her Island tells the story of Koh, a young biker who finds solace in his motorcycle after a breakup, and Miyo, a free-spirited girl on an island who becomes captivated by his bike. Their connection deepens, and Miyo develops a passion for motorcycles, leading to a bittersweet story of love, loss, and the transformative power of the open road",
                    CoverLink =
                        "https://m.media-amazon.com/images/M/MV5BZDUyOGEwMGYtM2ViNi00MjY3LTk4YzktNWJmZmY2NGFiNTgzXkEyXkFqcGc@._V1_.jpg",
                    WhoChose = "Teteu",
                    ReleaseYear = 1986,
                    WatchedDate = new DateTime(2025, 4, 28),
                    Rating = 4.5m,
                    Duration = 90,
                    Watched = true
                },
                new Movie
                {
                    Id = 3,
                    Title = "Bladerunner",
                    Summary =
                        "No século 21, uma corporação desenvolve clones humanos para serem usados como escravos em colônias fora da Terra, identificados como replicantes. Em 2019, um ex-policial é acionado para caçar um grupo fugitivo vivendo disfarçado em Los Angeles.",
                    CoverLink =
                        "https://m.media-amazon.com/images/M/MV5BOWQ4YTBmNTQtMDYxMC00NGFjLTkwOGQtNzdhNmY1Nzc1MzUxXkEyXkFqcGc@._V1_.jpg",
                    WhoChose = "Andre",
                    ReleaseYear = 1982,
                    WatchedDate = new DateTime(2025, 5, 5),
                    Rating = 5.0m,
                    Duration = 117,
                    Watched = true
                }
        );
    }
}