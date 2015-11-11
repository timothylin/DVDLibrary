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

            //var rentals = repo.CheckInDvd();

            //foreach (var rental in rentals)
            //{
            //    Console.WriteLine("Borrower ID: {0}", rental.BorrowerID);
            //    Console.WriteLine("Borrower First Name: {0}", rental.FirstName);
            //    Console.WriteLine("Borrower Last Name: {0}", rental.LastName);
            //    Console.WriteLine("Rental Date: {0}", rental.RentalDate);
            //    Console.WriteLine("Return Date: {0}", rental.ReturnDate);
            //    Console.WriteLine("User Notes: {0}", rental.UserNotes);
            //    Console.WriteLine("User Rating: {0}", rental.UserRating);
            //    Console.WriteLine("Movie Title: {0}", rental.Movie.Title);
            //    Console.WriteLine("Movie ID: {0}", rental.Movie.MovieID);
            //    Console.WriteLine("MPAA Rating: {0}", rental.Movie.MpaaRating);
            //    Console.WriteLine("Director: {0}", rental.Movie.Director);
            //    Console.WriteLine("Release Date: {0}", rental.Movie.ReleaseDate);
            //    Console.WriteLine("Studio: {0}", rental.Movie.Studio);

            //    foreach (var actor in rental.Movie.Actors)
            //    {
            //        Console.WriteLine("Actor ID: {0}", actor.ActorID);
            //        Console.WriteLine("Actor First Name: {0}", actor.Firstname);
            //        Console.WriteLine("Actor Last Name: {0}", actor.Lastname);
            //    }
            //}

            AddMovie("Star Trek", 5, 4, 1, 2013);

            Console.ReadLine();

        }

        public static void BorrowerByID(int id)
        {
            MovieRepo repo = new MovieRepo();

            var borrower = repo.GetBorrowerByID(id);

            Console.WriteLine("{0}, {1} has the borrower id number: {2}", borrower.LastName, borrower.FirstName, borrower.BorrowerID);
            

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
