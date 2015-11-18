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

        
        public ActionResult Remove(int movieID)
        {
            var ops = new MovieOperations();
            var movie = ops.GetMovieByID(movieID);
            return View("Remove", movie.Movie);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int movieID)
        {
            var ops = new MovieOperations();
            ops.RemoveMovie(movieID);
            var movie = ops.GetMovieByID(movieID);

            return View("ConfirmDelete", movie.Movie);
        }

        public ActionResult Add()
        {
            var ops = new MovieOperations();

            MovieInfoVM movieInfoVm = new MovieInfoVM();

            var ratingsResponse = ops.GetAllMpaaRatings();
            var actorsResponse = ops.GetAllActors();
            var borrowersResponse = ops.GetAllBorrowers();
            var studiosResponse = ops.GetAllStudios();
            var directorsResponse = ops.GetAllDirectors();

            movieInfoVm.CreateMpaaRatingsList(ratingsResponse.MpaaRatings);
            movieInfoVm.CreateActorsList(actorsResponse.Actors);
            movieInfoVm.CreateBorrowersList(borrowersResponse.Borrowers);
            movieInfoVm.CreateStudiosList(studiosResponse.Studios);
            movieInfoVm.CreateDirectorsList(directorsResponse.Directors);

            return View(movieInfoVm);
        }

        [HttpPost]
        public ActionResult Add(MovieInfoVM movieInfoVm)
        {
            var ops = new MovieOperations();

            var ratingsResponse = ops.GetAllMpaaRatings();
            var actorsResponse = ops.GetAllActors();
            var borrowersResponse = ops.GetAllBorrowers();
            var studiosResponse = ops.GetAllStudios();
            var directorsResponse = ops.GetAllDirectors();

            movieInfoVm.CreateMpaaRatingsList(ratingsResponse.MpaaRatings);
            movieInfoVm.CreateActorsList(actorsResponse.Actors);
            movieInfoVm.CreateBorrowersList(borrowersResponse.Borrowers);
            movieInfoVm.CreateStudiosList(studiosResponse.Studios);
            movieInfoVm.CreateDirectorsList(directorsResponse.Directors);


            if (ModelState.IsValid)
            {
                var response = ops.AddMovie(movieInfoVm.Movie);
                var movie = ops.GetMovieByID(response.Movie.MovieID);

                return View("Details", movie.Movie);
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