using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using DVDLibrary.BLL;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;
using DVDLibrary.UI.Models;

namespace DVDLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ops = new MovieOperations();
            var moviesResponse = ops.GetAllMovies();
            return View(moviesResponse.Movies);
        }

        [HttpPost]
        public ActionResult Details(int movieID)
        {
            var ops = new MovieOperations();
            var movieResponse = ops.GetMovieByID(movieID);

            return View("Details", movieResponse.Movie);
        }

        
        public ActionResult Remove(int movieID)
        {
            var ops = new MovieOperations();
            var movieResponse = ops.GetMovieByID(movieID);
            return View("Remove", movieResponse.Movie);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int movieID)
        {
            var ops = new MovieOperations();
            ops.RemoveMovie(movieID);
            var movieResponse = ops.GetMovieByID(movieID);

            return View("ConfirmDelete", movieResponse.Movie);
        }

        public ActionResult Add()
        {
            var ops = new MovieOperations();

            MovieInfoVM movieInfoVm = new MovieInfoVM();

            movieInfoVm.CreateMpaaRatingsList(ops.GetAllMpaaRatings().MpaaRatings);
            movieInfoVm.CreateActorsList(ops.GetAllActors().Actors);
            movieInfoVm.CreateBorrowersList(ops.GetAllBorrowers().Borrowers);
            movieInfoVm.CreateStudiosList(ops.GetAllStudios().Studios);
            movieInfoVm.CreateDirectorsList(ops.GetAllDirectors().Directors);

            return View(movieInfoVm);
        }

        [HttpPost]
        public ActionResult Add(MovieInfoVM movieInfoVm)
        {
            var ops = new MovieOperations();

            movieInfoVm.CreateMpaaRatingsList(ops.GetAllMpaaRatings().MpaaRatings);
            movieInfoVm.CreateActorsList(ops.GetAllActors().Actors);
            movieInfoVm.CreateBorrowersList(ops.GetAllBorrowers().Borrowers);
            movieInfoVm.CreateStudiosList(ops.GetAllStudios().Studios);
            movieInfoVm.CreateDirectorsList(ops.GetAllDirectors().Directors);

            if (ModelState.IsValid)
            {
                var addMovieResponse = ops.AddMovie(movieInfoVm.Movie);
                var addedMovieResponse = ops.GetMovieByID(addMovieResponse.Movie.MovieID);

                return View("Details", addedMovieResponse.Movie);
            }
            else
            {
                return View(movieInfoVm);
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}