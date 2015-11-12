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

            Assert.AreEqual("Good Burger", movie.Title);
        }



    }
}
