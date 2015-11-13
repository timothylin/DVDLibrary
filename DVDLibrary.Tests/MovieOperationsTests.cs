using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{

    [TestFixture]
    public class MovieOperationsTests
    {
        private MovieOperations _repo { get; set; }
        private Response response { get; set; }
        private MovieRepo movieRepo { get; set; }

        [SetUp]
        public void Setup()
        {
            _repo = new MovieOperations();
            response = new Response();
            movieRepo = new MovieRepo();
        }

        [Test]
        public void GetAllMovies()
        {
            var resp = _repo.GetAllMovies();
            //var response = movieRepo.GetAllMovieInfo();

            Assert.AreEqual(response.Success, resp.Success);
            
        }

        [Test]
        public void GetMovieByID()
        {
            var resp = _repo.GetMovieByID(1);
            //var response = movieRepo.GetAllMovieInfo();

            Assert.AreEqual(true, resp.Success);

        }

        //[Test]
        //public void AddMovie()
        //{
        //    MovieInfo movie = new MovieInfo();
        //    movie.MovieID = 1;
        //    movie.Actors
        //    var resp = _repo.AddMovie(movie);

        //    Assert.AreEqual(false, resp.Success);
        //}



    }
}
