using AspGodPractice.Repositories.MovieRepository;
using AspGodPractice.Services.MovieService;
using System;
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
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }


        // GET: Movie/GetFilmDetailsJson?id=5
        // This is the endpoint your jQuery AJAX call will hit
        [HttpGet]
        public JsonResult GetMovieDetailsById(int id)
        {
            try
            {
                var movie = _movieService.GetMovieDetailsById(id);
                if (movie == null)
                {
                    return Json(new { success = false, message = "Movie record not found." }, JsonRequestBehavior.AllowGet);
                }

                return Json(movie, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllMovies()
        {
            try
            {
                var movies = _movieService.GetAllMovies(); // Returns List<Movie>

                return Json(movies, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}