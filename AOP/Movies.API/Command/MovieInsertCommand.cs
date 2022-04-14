using MediatR;
using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Command
{
    public class MovieInsertCommand:IRequest<ResponseDto<NoContentDto>>
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Income { get; set; }
        public MovieType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
