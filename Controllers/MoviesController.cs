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

        // GET: Movies/Random
        public ActionResult Random(int id = 1)
        {
            var viewModel = _movieService.GetRentalData(id);
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route ("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ReleasedByDate ( int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}