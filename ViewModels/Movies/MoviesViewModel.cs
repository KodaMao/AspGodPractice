using AspGodPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.ViewModels.Movies
{
    public class MoviesViewModel
    {
         public List<Movie> Movies { get; set; }
         public string PageHeader { get; set; }
         public int TotalMovieCount => Movies.Count; 
   
    }
}