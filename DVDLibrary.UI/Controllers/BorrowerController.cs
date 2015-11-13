using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.BLL;

namespace DVDLibrary.UI.Controllers
{
    public class BorrowerController : Controller
    {
        // GET: Borrower
        [HttpPost]
        public ActionResult Track(int movieID)
        {
            var ops = new MovieOperations();
            var movie = ops.TrackDvd(movieID);
            return View("Track", movie.Rentals);
        }

        //public ActionResult CheckIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CheckInResult()
        //{
        //    var ops = new MovieOperations();
        //    ops.CheckIn();
        //    return View();
        //}

        
        
    }
}