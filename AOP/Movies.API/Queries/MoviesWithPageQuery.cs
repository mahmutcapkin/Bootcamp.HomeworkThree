using MediatR;
using Movies.API.DTOs;

namespace Movies.API.Queries
{
    public class MoviesWithPageQuery : IRequest<ResponseDto<List<MovieDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
