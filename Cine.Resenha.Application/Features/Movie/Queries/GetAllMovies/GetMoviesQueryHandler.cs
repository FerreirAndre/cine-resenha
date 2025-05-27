using AutoMapper;
using Cine.Resenha.Application.Contracts.Persistence;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Queries.GetAllMovies;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IReadOnlyList<MovieDto>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var data = await _movieRepository.GetAsync();
        var mappedData = _mapper.Map<IReadOnlyList<MovieDto>>(data);
        return mappedData;
    }
}