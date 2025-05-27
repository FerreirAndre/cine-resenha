using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Queries.GetMovieDetails;

public record GetMovieDetailsQuery(int id) : IRequest<MovieDetailsDto>;