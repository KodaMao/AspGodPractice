using AspGodPractice.Models;
using AspGodPractice.Repositories.MovieRepository;
using AspGodPractice.Services.MovieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace AspGodPractice.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController() : this(new MovieService(new MovieRepository()))
        {
        }
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public ActionResult Index()
        {
            var moviesViewModel = _movieService.GetAllMovies();
            return View(moviesViewModel);
        }

        public ActionResult Details(int id)
        {
            var movieDetailsViewModel = _movieService.GetMovieDetailsById(id);

            if (movieDetailsViewModel == null|| movieDetailsViewModel.Movie == null)
            {
                return HttpNotFound();
            }

            return View(movieDetailsViewModel);
        }
    }
}