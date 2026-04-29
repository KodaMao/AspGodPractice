using AspGodPractice.Models;
using AspGodPractice.ViewModels.Movies;
using System.Collections.Generic;

namespace AspGodPractice.Services.MovieService
{
    public interface IMovieService
    {
        MovieRentalViewModel GetRentalData(int movieId);
        MoviesViewModel GetAllMovies();
    }
}
