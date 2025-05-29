using AutoMapper;
using Cine.Resenha.Application.Contracts.Persistence;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieDetailsQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<MovieDetailsDto> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
    {
        var data = await _movieRepository.GetByIdAsync(request.id);
        var mappedData = _mapper.Map<MovieDetailsDto>(data);
        return mappedData;
    }
}