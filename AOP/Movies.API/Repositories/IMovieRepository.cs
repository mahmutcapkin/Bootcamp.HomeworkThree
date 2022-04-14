using Movies.API.Models;

namespace Movies.API.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie entity);
        void Update(Movie entity);
        void Delete(int id);
    }
}
