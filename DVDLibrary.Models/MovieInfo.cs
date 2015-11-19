using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;

namespace DVDLibrary.Models
{
    public class MovieInfo
    {
        public int MovieID { get; set; }
        //[Required(ErrorMessage = "Please enter a title!")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Please select a MPAA Rating!")]
        public MpaaRating MpaaRating { get; set; }
        //[Required(ErrorMessage = "Please select a director!")]
        public Director Director { get; set; }
        //[Required(ErrorMessage = "Please enter a release date!")]
        public int ReleaseDate { get; set; }
        //[Required(ErrorMessage = "Please select a studio!")]
        public Studio Studio { get; set; }
        //[Required(ErrorMessage = "Please select actors for the movie!")]
        public List<Actor> Actors { get; set; }
        public List<int> ActorIDs { get; set; } 

        public MovieInfo()
        {
            Actors = new List<Actor>();
            MpaaRating = new MpaaRating();
            Director = new Director();
            Studio = new Studio();
            ActorIDs = new List<int>();
        }
    }
}
