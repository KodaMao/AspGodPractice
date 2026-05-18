using AspGodPractice.Models;
using System.Collections.Generic;

namespace AspGodPractice.Services.MovieService
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieDetailsById(int id);
    }
}
