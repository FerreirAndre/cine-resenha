using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.CreateMovie;

public class CreateMovieCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string CoverLink { get; set; }
    public string WhoChose { get; set; }
    public int ReleaseYear { get; set; }
    public DateTime? WatchedDate { get; set; }
    public decimal Rating { get; set; } = 0.0m;
    public int Duration { get; set; } = 0;
    public bool Watched { get; set; } = false;
}