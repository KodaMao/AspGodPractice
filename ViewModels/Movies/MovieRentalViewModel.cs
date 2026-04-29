using AspGodPractice.Models;
using AspGodPractice.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.ViewModels.Movies
{
    public class MovieRentalViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public string NotificationMessage { get; set; }
    }
}