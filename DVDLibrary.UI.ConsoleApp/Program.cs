using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.DataLayer;

namespace DVDLibrary.UI.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repo = new MovieRepo();

            var rentals = repo.GetAllBorrowersInfo();

            foreach (var rental in rentals)
            {
                Console.WriteLine("Movie Title: {0}", rental.Movie.Title);
                //Console.WriteLine("Movie ID: {0}", rental.MovieID);
                //Console.WriteLine("MPAA Rating: {0}", rental.MpaaRating.FilmRating);

                Console.WriteLine("Director: {0} {1}", rental.Movie.Director.FirstName, rental.Movie.Director.LastName);
                Console.WriteLine("Borrower: {0} {1}", rental.Borrower.FirstName, rental.Borrower.LastName);
                //Console.WriteLine("Release Date: {0}", rental.ReleaseDate);
                //Console.WriteLine("Studio: {0}", rental.Studio.StudioName);

                //foreach (var actor in rental.Actors)
                //{
                //    Console.WriteLine("Actor ID: {0}", actor.ActorID);
                //    Console.WriteLine("Actor First Name: {0}", actor.FirstName);
                //    Console.WriteLine("Actor Last Name: {0}", actor.LastName);
                //}

            }


            Console.ReadLine();
            //MovieRepo repo = new MovieRepo();

            //var movies = repo.GetAllMovieInfo();

            //MovieOperations ops = new MovieOperations();

            //var response = ops.GetAllMovies();

            //foreach (var movie in response.Movies)
            //{
            //    Console.WriteLine("Movie Title: {0}", movie.Title);
            //    Console.WriteLine("Movie ID: {0}", movie.MovieID);
            //    Console.WriteLine("MPAA Rating: {0}", movie.MpaaRating);
            //    Console.WriteLine("Director: {0}", movie.Director);
            //    Console.WriteLine("Release Date: {0}", movie.ReleaseDate);
            //    Console.WriteLine("Studio: {0}", movie.Studio);
            //}

            //Console.ReadLine();

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}

            //MovieRepo repo = new MovieRepo();

            //var movie = repo.GetMovieByID(7);

            //Console.WriteLine(movie);

            //Console.ReadLine();

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
            //        Console.WriteLine("Actor First Name: {0}", actor.FirstName);
            //        Console.WriteLine("Actor Last Name: {0}", actor.LastName);
            //    }
            //}

            //    AddMovie("Star Trek", 5, 4, 1, 2013);


            //    Console.ReadLine();

            //}

            //public static void BorrowerByID(int id)
            //{
            //    MovieRepo repo = new MovieRepo();

            //    var borrower = repo.GetBorrowerByID(id);

            //    Console.WriteLine("{0}, {1} has the borrower id number: {2}", borrower.LastName, borrower.FirstName, borrower.BorrowerID);


            //}


            //public static void RemoveMovieByID(int movieID)
            //{
            //    MovieRepo repo = new MovieRepo();

            //    repo.RemoveMovieByID(movieID);

            //}

            //public static void AddMovie(string movietitle, int mpaaratingID, int directorID, int studioID, int releaseDate)
            //{
            //    MovieRepo repo = new MovieRepo();

            //    repo.AddMovie( movietitle,  mpaaratingID,  directorID,  studioID,  releaseDate);

            //}


        }
    }
}
