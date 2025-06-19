using Cine.Resenha.Application.Contracts.Persistence;
using Cine.Resenha.Application.Exceptions;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.ToggleWatchedMovie;

public class UpdateMovieWatchedCommandHandler : IRequestHandler<UpdateMovieWatchedCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;

    public UpdateMovieWatchedCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<Unit> Handle(UpdateMovieWatchedCommand request, CancellationToken cancellationToken)
    {
        var movieToUpdate = await _movieRepository.GetByIdAsync(request.id);
        if (movieToUpdate == null)
            throw new NotFoundException(nameof(Domain.Movie), request.id);
        await _movieRepository.ToggleWatched(movieToUpdate.Id);
        return Unit.Value;
    }
}