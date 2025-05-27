using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Queries.GetAllMovies;

public record GetMoviesQuery : IRequest<IReadOnlyList<MovieDto>>;