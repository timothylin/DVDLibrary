using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using DVDLibrary.BLL;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{

    [TestFixture]
    public class MovieOperationsTests
    {
        private MovieOperations _ops { get; set; }
        private Response _response { get; set; }

        [SetUp]
        public void Setup()
        {
            _ops = new MovieOperations();
            _response = new Response();
        }

        [Test]
        public void GetAllMoviesTest()
        {
            _response = _ops.GetAllMovies();
            //var _response = movieRepo.GetAllMovieInfo();

            Assert.AreEqual(true, _response.Success);
            
        }

        [Test]
        public void GetMovieByIDTest()
        {
            var resp = _ops.GetMovieByID(1);
            //var _response = movieRepo.GetAllMovieInfo();

            Assert.AreEqual(true, resp.Success);

        }

        [Test]
        public void AddMovieTest()
        {
            List<Actor> actors = new List<Actor>();
            Director director = new Director();
            Studio studio = new Studio();

            var movie = new MovieInfo();

            //movie.MovieID = 20;
            //movie.MpaaRating.FilmRating = "PG-13";
            movie.MpaaRating.MpaaRatingID = 7;
            movie.Title = "Inception";

            var actor = new Actor();
            actor.ActorID = 6;
            //actor.FirstName = "Will";
            //actor.LastName = "Smith";

            actors.Add(actor);

            movie.Actors = actors;
            movie.Director.DirectorID = 13;
            //movie.Director.FirstName = "Oliver";
            //movie.Director.LastName = "Queen";
            movie.ReleaseDate = 2002;
            movie.Studio.StudioID = 10;
            //movie.Studio.StudioName = "Robot";


            _response = _ops.AddMovie(movie);

            var responseReturned = _ops.GetMovieByID(_response.Movie.MovieID);
            
            var actual = new JavaScriptSerializer().Serialize(_response.Movie);
            var expected = new JavaScriptSerializer().Serialize(responseReturned.Movie);

            //Assert.AreEqual(expected, actual);
           Assert.AreEqual(true, _response.Success );

        }

        [Test]
        public void RemoveMovieTest()
        {

            _response = _ops.RemoveMovie(18);

            Assert.AreEqual(0, _response.Movie.MovieID);
        }

        [Test]
        public void TrackDVDTest()
        {
            _response = _ops.TrackDvd(2);

            Assert.AreEqual(true,  _response.Success );
        }


        [Test]
        public void GetBorrowerByID()
        {
            _response = _ops.GetBorrowerByID(1);

            Assert.AreEqual(true, _response.Success);
        }


        [Test]
        public void GetAllMpaaRatings()
        {
            _response = _ops.GetAllMpaaRatings();

            Assert.AreEqual(true, _response.Success);
        }


        [Test]
        public void GetAllActors()
        {
            _response = _ops.GetAllActors();

            Assert.AreEqual(true, _response.Success);

        }


        [Test]
        public void GetAllBorrowers()
        {
            _response = _ops.GetAllBorrowers();

            Assert.AreEqual(true, _response.Success);

        }


        [Test]
        public void GetAllDirectors()
        {
            _response = _ops.GetAllDirectors();

            Assert.AreEqual(true, _response.Success);

        }


        [Test]
        public void GetAllStudios()
        {
            _response = _ops.GetAllStudios();        
                
                Assert.AreEqual(true, _response.Success);


        }





    }
}
