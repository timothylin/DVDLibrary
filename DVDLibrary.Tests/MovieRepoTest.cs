using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class MovieRepoTest
    {
        private MovieRepo repo;


        [Test]
        public void GetAllMovieTest()
        {
            repo = new MovieRepo();

            List<MovieInfo> movieinfo = repo.GetAllMovieInfo();

            Assert.AreEqual(1, movieinfo.FirstOrDefault(m=>m.MovieID == 1).MovieID);


        }

        [Test]
        public void GetMovieByID()
        {
            repo = new MovieRepo();

            MovieInfo movie = repo.GetMovieByID(1);

            Assert.AreEqual(1, movie.MovieID);
        }

        [Test]
        public void AddMovieWithInput()
        {
            repo = new MovieRepo();
            List<Actor> actors =  new List<Actor>();
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
            
                      
            MovieInfo movieinfo = repo.AddMovieWithInput(movie);


            Assert.AreEqual("Inception", movieinfo.Title);

        }


        [Test]
        public void RemoveMovieByID()
        {
            repo = new MovieRepo();

            MovieInfo movieinfo = repo.RemoveMovieByID(18);

            Assert.AreEqual(0, movieinfo.MovieID);
        }


        [Test]
        public void GetBorrowerByID()
        {
            repo = new MovieRepo();
            RentalInfo borrower = repo.GetBorrowerByID(5);

            Assert.AreEqual("Victor", borrower.Borrower.FirstName);
        }


        [Test]
        public void GetAllBorrowersInfo()
        {

            repo = new MovieRepo();
            List<RentalInfo> rent =new List<RentalInfo>();
          RentalInfo rental = new RentalInfo();

                rental.RentalDate = DateTime.Parse("02/01/2015");
            rental.ReturnDate = DateTime.Parse("03/30/2015");
            rental.UserRating= 5;
            rental.Borrower.BorrowerID = 1;
            rental.UserNotes = "good movie";
            rental.Borrower.FirstName = "Jim";
            rental.Borrower.LastName = "Shaw";
            rental.Movie.Title = "Brave Heart";
            rental.Movie.MovieID = 2;
            rental.Movie.MpaaRating.FilmRating = "PG";
            rental.Movie.Director.DirectorID = 2;
            rental.Movie.Studio.StudioID = 2;
            rental.Movie.Studio.StudioName = "Universal";
            rental.Movie.ReleaseDate = 2014;


            rent.Add(rental);

            List<RentalInfo> movie = repo.GetAllBorrowersInfo();

            Assert.AreEqual(rent.Select(m=> m.Movie.MovieID ==2), movie.Select(m => m.Movie.MovieID == 2));
        }



    }
}
