using MoviesCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesCrud.ViewModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public People Director { get; set; }

        public People LeadingMale { get; set; }
        public People LeadingFemale { get; set; }
    }
}