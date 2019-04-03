using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmLibraryCore.Models
{
    public class FillmDetails
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string imdbRating { get; set; }
        public string Language { get; set; }
        public List<Rating> Ratings { get; set; }
        public string LocalImageName { get; set; }

    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
