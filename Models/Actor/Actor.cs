using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Character { get; set; }
    }
}