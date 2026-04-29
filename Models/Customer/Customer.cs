using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspGodPractice.Models.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribed { get; set; }
    }
}