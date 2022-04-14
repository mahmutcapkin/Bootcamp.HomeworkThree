using AutoMapper;
using MediatR;
using Movies.API.Autofac.Aspect;
using Movies.API.DTOs;
using Movies.API.Models;
using Movies.API.Repositories;
using Movies.API.Validators;

namespace Movies.API.Command
{
    [ValidationAspect(typeof(MovieUpdateCommandValidator))]
    public class MovieUpdateCommandHandler : IRequestHandler<MovieUpdateCommand, ResponseDto<NoContentDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private IMapper _mapper;

        public MovieUpdateCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public Task<ResponseDto<NoContentDto>> Handle(MovieUpdateCommand request, CancellationToken cancellationToken)
        {
            var hasMovie = _movieRepository.GetAll().Any(x => x.Id == request.Id);
            if (!hasMovie)
            {
                return Task.FromResult(ResponseDto<NoContentDto>.Fail($"Güncellenecek film {request.Id} bulunamadı!"));
            }
            var mappedMovie = _mapper.Map<Movie>(request);
            _movieRepository.Update(mappedMovie);
            return Task.FromResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
