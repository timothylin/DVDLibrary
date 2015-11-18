using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class MovieRepoTest
    {

        private MovieRepo _repo { get; set; }

        [SetUp]
        public void SetUp()
        {
            _repo = new MovieRepo();
        }

        [Test]
        public void GetAllMovieTest()
        {

            List<MovieInfo> movieinfo = _repo.GetAllMovieInfo();

            Assert.AreEqual(1, movieinfo.FirstOrDefault(m => m.MovieID == 1).MovieID);


        }

        [Test]
        public void GetMovieByIDTest()
        {

            MovieInfo movie = _repo.GetMovieByID(1);

            Assert.AreEqual(1, movie.MovieID);
        }

        [Test]
        public void AddMovieWithInputTest()
        {
            List<Actor> actors = new List<Actor>();
            Director director = new Director();
            Studio studio = new Studio();

            var movie = new MovieInfo();

            //movie.MovieID = 20;
            movie.MpaaRating.FilmRating = "PG-13";
            movie.Title = "Inception";

            var actor = new Actor();
            //a.ActorID = 10;
            actor.FirstName = "Will";
            actor.LastName = "Smith";

            actors.Add(actor);

            movie.Actors = actors;
            //movie.Director.DirectorID = 10;
            movie.Director.FirstName = "Oliver";
            movie.Director.LastName = "Queen";
            movie.ReleaseDate = 2002;
            //movie.Studio.StudioID = 10;
            movie.Studio.StudioName = "Robot";


            MovieInfo movieinfo = _repo.AddMovie(movie);
            var movieReturned = _repo.GetMovieByID(movieinfo.MovieID);

            var actual = new JavaScriptSerializer().Serialize(movieReturned);
            var expected = new JavaScriptSerializer().Serialize(movieinfo);

            Assert.AreEqual(expected, actual);
            //Assert.AreEqual("Inception", movieinfo.Title);

        }


        [Test]
        public void RemoveMovieByIDTest()
        {

            MovieInfo movieinfo = _repo.RemoveMovieByID(18);

            Assert.AreEqual(0, movieinfo.MovieID);
        }


        [Test]
        public void GetBorrowerByIDTest()
        {
            RentalInfo borrower = _repo.GetBorrowerByID(5);

            Assert.AreEqual("Victor", borrower.Borrower.FirstName);
        }


        //[Test]
        //public void GetAllBorrowersInfo()
        //{

        //    List<RentalInfo> rent = new List<RentalInfo>();
        //    RentalInfo rental = new RentalInfo();

        //    rental.RentalDate = DateTime.Parse("2015-02-01");
        //    rental.ReturnDate = DateTime.Parse("2015-03-30");
        //    rental.UserRating = 3;
        //    rental.Borrower.BorrowerID = 2;
        //    //rental.UserNotes = "good movie";
        //    rental.Borrower.FirstName = "Jim";
        //    rental.Borrower.LastName = "Shaw";
        //    rental.Movie.Title = "Brave Heart";
        //    rental.Movie.MovieID = 2;
        //    rental.Movie.MpaaRating.FilmRating = "PG";
        //    rental.Movie.Director.DirectorID = 2;
        //    rental.Movie.Director.FirstName = "Ron";
        //    rental.Movie.Director.LastName = "Howard";
        //    rental.Movie.Studio.StudioID = 2;
        //    rental.Movie.Studio.StudioName = "Universal";
        //    rental.Movie.ReleaseDate = 2014;


        //    rent.Add(rental);

        //    List<RentalInfo> movie = _repo.GetAllBorrowersInfo();

        //    var movieActual = movie.FirstOrDefault(m => m.Movie.MovieID == 2);

        //    var movieExpected = rent.FirstOrDefault(m => m.Movie.MovieID == 2);

        //    var actual = new JavaScriptSerializer().Serialize(movieActual);
        //    var expected = new JavaScriptSerializer().Serialize(movieExpected);


        //    Assert.AreEqual(expected, actual);
        //}

        [Test]
        public void GetAllActorsTest()
        {
            List<Actor> movieinfo = _repo.GetAllActors();

            Assert.AreEqual(1, movieinfo.FirstOrDefault(m => m.ActorID == 1).ActorID);
        }


        [Test]
        public void GetListOfActorsByMovieIDTest()
        {
            List<Actor> actors = _repo.GetListOfActorsByMovieID(2);

            Assert.AreEqual(2, actors.FirstOrDefault(m => m.ActorID == 2).ActorID);

        }

        [Test]
        public void GetAllBorrowersTest()
        {
            List<Borrower> borrowers = _repo.GetAllBorrowers();

            Assert.AreEqual(1, borrowers.FirstOrDefault(b => b.BorrowerID == 1).BorrowerID);
        }

        [Test]
        public void GetAllDirectorsTest()
        {
            List<Director> directors = _repo.GetAllDirectors();

            Assert.AreEqual(1, directors.FirstOrDefault(b => b.DirectorID == 1).DirectorID);
        }

        [Test]
        public void GetAllMpaaRatingsTest()
        {
            List<MpaaRating> mpaaRatings = _repo.GetAllMpaaRatings();

            Assert.AreEqual(1, mpaaRatings.FirstOrDefault(b => b.MpaaRatingID == 1).MpaaRatingID);
        }

        [Test]
        public void GetAllStudiosTest()
        {
            List<Studio> studios = _repo.GetAllStudios();

            Assert.AreEqual(1, studios.FirstOrDefault(b => b.StudioID == 1).StudioID);
        }
    }
}
