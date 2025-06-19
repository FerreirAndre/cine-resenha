using Cine.Resenha.Domain;

namespace Cine.Resenha.Application.Contracts.Persistence;

public interface IMovieRepository
{
    Task<IReadOnlyList<Movie>> GetAsync();
    Task<Movie> GetByIdAsync(int id);
    Task CreateAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Movie movie);
    Task<bool> MovieTitleUnique(string title);
    Task<bool> MovieTitleUnique(string title, int id);
    Task ToggleWatched(int id);
}
