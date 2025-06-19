using Cine.Resenha.Application.Contracts.Persistence;
using Cine.Resenha.Domain;
using Cine.Resenha.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Cine.Resenha.Persistence.Repositories;


public class MovieRepository(MovieDatabaseContext context) : IMovieRepository
{
    private readonly MovieDatabaseContext _context = context;

    public async Task<IReadOnlyList<Movie>> GetAsync()
    {
         return await _context.Set<Movie>().AsNoTracking().ToListAsync();
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _context.Set<Movie>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task CreateAsync(Movie movie)
    {
        await _context.AddAsync(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _context.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> MovieTitleUnique(string title)
    {
        return await _context.Set<Movie>().AnyAsync(x => x.Title == title) == false;
    }

    public async Task<bool> MovieTitleUnique(string title, int id)
    {
        return await _context.Set<Movie>().AnyAsync(x => x.Title == title && x.Id != id) == false;
    }

    public async Task ToggleWatched(int id)
    {
        var movieToToggle = await _context.Set<Movie>().FirstOrDefaultAsync(x => x.Id == id);
        movieToToggle.Watched = !movieToToggle.Watched;
        await _context.SaveChangesAsync();
    }
}
