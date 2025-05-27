using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.DeleteMovie;

public record DeleteMovieCommand(int id) : IRequest<Unit>;