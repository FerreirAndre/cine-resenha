using Cine.Resenha.Application.Contracts.Persistence;
using Cine.Resenha.Application.Exceptions;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movieToDelete = await _movieRepository.GetByIdAsync(request.id);
        if (movieToDelete == null)
            throw new NotFoundException(nameof(Domain.Movie), request.id);
        await _movieRepository.DeleteAsync(movieToDelete);
        return Unit.Value;
    }
}