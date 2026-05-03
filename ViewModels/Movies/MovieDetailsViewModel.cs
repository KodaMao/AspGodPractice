using AspGodPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.ViewModels.Movies
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; } = new Movie();
        public string PageHeader { get; set; }
        public MovieDetailsViewModel()
        {
            Movie.Actors = new List<Actor>();
        }
    }
}