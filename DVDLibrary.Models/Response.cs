using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MovieInfo Movie { get; set; }
        public List<MovieInfo> Movies { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Borrower> Borrowers { get; set; }
        public List<Director> Directors { get; set; }
        public List<MpaaRating> MpaaRatings { get; set; }
        public List<Studio> Studios { get; set; }    
        public RentalInfo Rental { get; set; }  
        public List<RentalInfo> Rentals { get; set; }

        public Response()
        {
            Movie = new MovieInfo();
            Movies = new List<MovieInfo>();
            Actors = new List<Actor>();
            Rental = new RentalInfo();
            Rentals = new List<RentalInfo>();
        }

    }
}
