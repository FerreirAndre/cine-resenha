using Cine.Resenha.Application.Contracts.Persistence;
using FluentValidation;

namespace Cine.Resenha.Application.Features.Movie.Commands.CreateMovie;

public class CreateMovieCommandValidator: AbstractValidator<CreateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;

    public CreateMovieCommandValidator(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
        
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .WithMessage("Movie with the same title already exists.");
        
        RuleFor(x=>x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("{PropertyName} must be between 0 and 10.")
            .Must(BeHalfStep)
            .WithMessage("{PropertyName} must be multiple of 0.5.");
        
        RuleFor(x => x)
            .MustAsync(MovieTitleUnique)
            .WithMessage("Movie with the same title already exists.");
    }

    private Task<bool> MovieTitleUnique(CreateMovieCommand request, CancellationToken arg2)
    {
        return _movieRepository.MovieTitleUnique(request.Title);
    }

    private bool BeHalfStep(decimal rating)
    {
        return rating % 0.5m == 0;   
    }
}