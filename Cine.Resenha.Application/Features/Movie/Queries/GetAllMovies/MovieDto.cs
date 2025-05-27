namespace Cine.Resenha.Application.Features.Movie.Queries.GetAllMovies;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverLink { get; set; }
    public decimal Rating { get; set; }
    public int Duration { get; set; }
    public bool Watched { get; set; }
}