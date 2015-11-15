using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;

namespace DVDLibrary.Models
{
    public class MovieInfo
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public MpaaRating MpaaRating { get; set; }
        public Director Director { get; set; }
        public int ReleaseDate { get; set; }
        public Studio Studio { get; set; }
        public List<Actor> Actors { get; set; }


        public MovieInfo()
        {
            Actors = new List<Actor>();
            MpaaRating = new MpaaRating();
            Director = new Director();
            Studio = new Studio();
        }



     
    }
}
