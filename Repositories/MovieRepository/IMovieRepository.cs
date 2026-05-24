using AspGodPractice.Models;
using System.Collections.Generic;


namespace AspGodPractice.Repositories.MovieRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllFilms();
        Movie GetFilmDetailsById(int id);
    }
}
