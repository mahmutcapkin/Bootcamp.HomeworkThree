using AutoMapper;
using MediatR;
using Movies.API.DTOs;
using Movies.API.Repositories;

namespace Movies.API.Queries
{
    public class MoviesWithPageQueryHandler : IRequestHandler<MoviesWithPageQuery, ResponseDto<List<MovieDto>>>
    {
        private readonly IMovieRepository _movieRepository;
        private IMapper _mapper;

        public MoviesWithPageQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async  Task<ResponseDto<List<MovieDto>>> Handle(MoviesWithPageQuery request, CancellationToken cancellationToken)
        {
            var movie = _movieRepository.GetAll().Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

            var moviesDto = _mapper.Map<List<MovieDto>>(movie);

            return ResponseDto<List<MovieDto>>.Success(moviesDto, 200);
        }
    }
}
