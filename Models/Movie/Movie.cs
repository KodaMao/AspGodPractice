using System;
using System.Collections.Generic;


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
        public int Budget { get; set; }
        public int Gross { get; set; }
        public string Rating { get; set; }
        public int Nominations { get; set; }
        public int Awards { get; set; }
        public string Director { get; set; }
        public DateTime DirectorBirthDay { get; set; }
        public string DirectorGender { get; set; }
        public string Studio { get; set; }
        public string Country { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();    
    }
}