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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MovieInfo Movie { get; set; }
        public int BorrowerId { get; set; }
        public string UserNotes { get; set; }//
        public string UserRating { get; set; }//



    }
}
