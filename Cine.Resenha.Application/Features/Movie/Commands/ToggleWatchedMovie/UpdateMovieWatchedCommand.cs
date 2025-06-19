using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.ToggleWatchedMovie;

public record UpdateMovieWatchedCommand(int id) : IRequest<Unit>;