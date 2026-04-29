using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public int Runtime { get; set; }
        public string Rating { get; set; }
        public int Awards { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Country { get; set; }
    }
}