using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.BLL;
using DVDLibrary.DataLayer;

namespace DVDLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ops = new MovieOperations();
            var movies = ops.GetAllMovies();
            return View(movies.Movies);
        }

        [HttpPost]
        public ActionResult Details(int movieID)
        {
            var ops = new MovieOperations();
            var movie = ops.GetMovieByID(movieID);

            return View("Details", movie.Movie);
        }

        //public ActionResult Remove()
        //{
            
        //}
    }
}