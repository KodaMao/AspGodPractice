using AspGodPractice.Models;
using AspGodPractice.ViewModels.Movies;
using System.Collections.Generic;

namespace AspGodPractice.Services.MovieService
{
    public interface IMovieService
    {
        MoviesViewModel GetAllMovies();
        MovieDetailsViewModel GetMovieDetailsById(int id);
    }
}
