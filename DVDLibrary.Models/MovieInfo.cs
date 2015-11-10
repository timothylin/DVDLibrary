using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class MovieInfo
    {
        public string Title { get; set; }//
        public string MPAARating { get; set; }//
        public string UserRating { get; set; }//
        public string Director { get; set; }//
        public string UserNotes { get; set; }//
        public DateTime ReleaseDate { get; set; }//
        public int MovieID { get; set; }//
        public string Studio { get; set; }//
        public String ActorLastname { get; set; }
    }
}
