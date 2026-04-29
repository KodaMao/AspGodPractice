using AspGodPractice.Models;
using AspGodPractice.Models.Customer;
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

        public MovieRentalViewModel GetRentalData(int movieId)
        {
            // Faking a database search
            var fakeMovie = new Movie { Id = movieId, Title = "Inception" };

            var fakeCustomers = new List<Customer>
        {
            new Customer { FirstName = "John", LastName = "Doe" , IsSubscribed = true},
            new Customer { FirstName = "Jane", LastName = "Smith", IsSubscribed = false },
            new Customer { FirstName = "Legacy", LastName = "Coder", IsSubscribed = true }
        };

            return new MovieRentalViewModel
            {
                Movie = fakeMovie,
                Customers = fakeCustomers,
                NotificationMessage = "Don't forget to return the movie within 2 weeks!"
            };
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
    }
}