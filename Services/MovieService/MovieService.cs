using AspGodPractice.Models;
using AspGodPractice.Repositories.MovieRepository;
using AspGodPractice.ViewModels.Movies;
using System.Collections.Generic;

namespace AspGodPractice.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MoviesViewModel GetAllMovies()
        {
            List<Movie> allMovies = _movieRepository.GetAllFilms();
            return new MoviesViewModel
            {
                Movies = allMovies,
                PageHeader = "All Movies"
            };
        }

        public MovieDetailsViewModel GetMovieDetailsById(int id)
        {
            Movie movie = _movieRepository.GetFilmDetailsById(id);
            return new MovieDetailsViewModel
            {
                Movie = movie,
                PageHeader = "Movie Details"
            };
        }
    }
}