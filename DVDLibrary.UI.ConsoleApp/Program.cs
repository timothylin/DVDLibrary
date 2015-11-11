using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DataLayer;

namespace DVDLibrary.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //MovieRepo repo = new MovieRepo();

            //var movies = repo.GetAllMovieInfo();

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}




            //BorrowerByID(2);

            //RemoveMovieByID(6);

            AddMovie("Star Trek", 5, 4, 1, 2013);

      


            Console.ReadLine();

        }

        public static void BorrowerByID(int id)
        {
            MovieRepo repo = new MovieRepo();

            var borrower = repo.GetBorrowerByID(id);

            Console.WriteLine("{0}, {1} has the borrower id number: {2}", borrower.LastName, borrower.FirstName, borrower.BorrowerId);
            

        }


        public static void RemoveMovieByID(int movieID)
        {
            MovieRepo repo = new MovieRepo();

            repo.RemoveMovieByID(movieID);

        }


        public static void AddMovie(string movietitle, int mpaaratingID, int directorID, int studioID, int releaseDate)
        {
            MovieRepo repo = new MovieRepo();

            repo.AddMovie( movietitle,  mpaaratingID,  directorID,  studioID,  releaseDate);

        }


    }
}
