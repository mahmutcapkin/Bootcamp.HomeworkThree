using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Command;
using Movies.API.DTOs;
using Movies.API.Filters;
using Movies.API.Queries;
using Movies.API.Services;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;
        private IMediator _mediator;
        public MoviesController(MovieService movieService, IMapper mapper, IMediator mediator)
        {
            _movieService = movieService;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("[action]/{page:int}/{pageSize:int}")]
        [CustomExceptionFilter]
        public async Task<IActionResult> GetMovies(int page, int pageSize)
        {
            return Ok(await _mediator.Send(new MoviesWithPageQuery() { Page = page, PageSize = pageSize }));


        }

        [HttpPut]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieRequestDto movieRequestDto)
        {
            var result = _mapper.Map<MovieUpdateCommand>(movieRequestDto);
            return Ok(await _mediator.Send(result));
        }


        [HttpPost]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddMovie(MovieInsertCommand movieInsertCommand)
        {
            return Ok(await _mediator.Send(movieInsertCommand));
        }


    }
}
