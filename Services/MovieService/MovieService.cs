using AspGodPractice.Models;
using AspGodPractice.Repositories.MovieRepository;
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

        public List<Movie> GetAllMovies()
        {
            List<Movie> allMovies = _movieRepository.GetAllFilms();
            return allMovies;
        }

        public Movie GetMovieDetailsById(int id)
        {
            Movie movie = _movieRepository.GetFilmDetailsById(id);
            return movie;
        }
    }
}