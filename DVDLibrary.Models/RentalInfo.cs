using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class RentalInfo
    {
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public MovieInfo Movie { get; set; }
        public Borrower Borrower { get; set; }
        public string UserNotes { get; set; }
        public int UserRating { get; set; }

        public RentalInfo()
        {
            Movie = new MovieInfo();
        }
    }
}
