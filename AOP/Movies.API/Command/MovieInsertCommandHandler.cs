using AutoMapper;
using MediatR;
using Movies.API.Autofac.Aspect;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repositories;
using Movies.API.Validators;

namespace Movies.API.Command
{
    [ValidationAspect(typeof(MovieInsertCommandValidator))]
    public class MovieInsertCommandHandler : IRequestHandler<MovieInsertCommand, ResponseDto<NoContentDto>>
    {
        private readonly IMovieRepository  _movieRepository;
        private IMapper _mapper;

        public MovieInsertCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public Task<ResponseDto<NoContentDto>> Handle(MovieInsertCommand request, CancellationToken cancellationToken)
        {
            var mappedMovie = _mapper.Map<Movie>(request);
            _movieRepository.Add(mappedMovie);

            return Task.FromResult(ResponseDto<NoContentDto>.Success(201));
        }
    }
}
