using AutoMapper;
using Cine.Resenha.Application.Contracts.Persistence;
using Cine.Resenha.Application.Exceptions;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(IMovieRepository movieRepository,IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateMovieCommandValidator(_movieRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Movie.", validationResult);
        
        var movieToCreate = _mapper.Map<Domain.Movie>(request);
        
        await _movieRepository.CreateAsync(movieToCreate);
        
        return movieToCreate.Id;
    }
}