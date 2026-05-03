using AspGodPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspGodPractice.Repositories.MovieRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllFilms();
        Movie GetFilmDetailsById(int id);
    }
}
