using AutoMapper;
using Cine.Resenha.Application.Contracts.Persistence;
using Cine.Resenha.Application.Exceptions;
using MediatR;

namespace Cine.Resenha.Application.Features.Movie.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateMovieCommandValidator(_movieRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid movie", validationResult);

        var movieToUpdate = _mapper.Map<Domain.Movie>(request);
        await _movieRepository.UpdateAsync(movieToUpdate);

        return Unit.Value;
    }
}
