using AutoMapper;
using Cine.Resenha.Application.Features.Movie.Commands.CreateMovie;
using Cine.Resenha.Application.Features.Movie.Commands.UpdateMovie;
using Cine.Resenha.Application.Features.Movie.Queries.GetAllMovies;
using Cine.Resenha.Application.Features.Movie.Queries.GetMovieDetails;
using Cine.Resenha.Domain;

namespace Cine.Resenha.Application.MappingProfiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<MovieDetailsDto, Movie>().ReverseMap();
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<UpdateMovieCommand, Movie>();
    }
}
