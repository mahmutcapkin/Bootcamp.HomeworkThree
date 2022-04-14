using Movies.API.Models;

namespace Movies.API.DTOs
{
    public class MovieRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Income { get; set; }
        public MovieType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
