using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class MovieInfo
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string MpaaRating { get; set; }
        public string Director { get; set; }
        public int ReleaseDate { get; set; }
        public string Studio { get; set; }
        public List<Actor> Actors { get; set; } 
    }
}
