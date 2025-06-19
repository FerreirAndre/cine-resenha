using Cine.Resenha.Application.Features.Movie.Commands.CreateMovie;
using Cine.Resenha.Application.Features.Movie.Commands.DeleteMovie;
using Cine.Resenha.Application.Features.Movie.Commands.ToggleWatchedMovie;
using Cine.Resenha.Application.Features.Movie.Commands.UpdateMovie;
using Cine.Resenha.Application.Features.Movie.Queries.GetAllMovies;
using Cine.Resenha.Application.Features.Movie.Queries.GetMovieDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Resenha.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<IReadOnlyList<MovieDto>> Get()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());
            return movies;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<MovieDetailsDto> Get(int id)
        {
            var movie = await _mediator.Send(new GetMovieDetailsQuery(id));
            return movie;
        }

        // POST api/<MoviesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateMovieCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateMovieCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand(id);
            await _mediator.Send(command);
            return NoContent();       
        }
        
        // PATCH api/<MoviesController>/5
        [HttpPatch("{id}/watched")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Patch(int id)
        {
            await _mediator.Send(new UpdateMovieWatchedCommand(id));
            return NoContent();
        }
    }
}