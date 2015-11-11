﻿using System;
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
            MovieRepo repo = new MovieRepo();

            var rentals = repo.CheckInDvd();

            foreach (var rental in rentals)
            {
                Console.WriteLine("Borrower ID: {0}", rental.BorrowerId);
                Console.WriteLine("Borrower First Name: {0}", rental.FirstName);
                Console.WriteLine("Borrower Last Name: {0}", rental.LastName);
                Console.WriteLine("Rental Date: {0}", rental.RentalDate);
                Console.WriteLine("Return Date: {0}", rental.ReturnDate);
                Console.WriteLine("User Notes: {0}", rental.UserNotes);
                Console.WriteLine("User Rating: {0}", rental.UserRating);
                Console.WriteLine("Movie Title: {0}", rental.Movie.Title);
                Console.WriteLine("Movie ID: {0}", rental.Movie.MovieId);
                Console.WriteLine("MPAA Rating: {0}", rental.Movie.MpaaRating);
                Console.WriteLine("Director: {0}", rental.Movie.Director);
                Console.WriteLine("Release Date: {0}", rental.Movie.ReleaseDate);
                Console.WriteLine("Studio: {0}", rental.Movie.Studio);

                foreach (var actor in rental.Movie.Actors)
                {
                    Console.WriteLine("Actor ID: {0}", actor.ActorId);
                    Console.WriteLine("Actor First Name: {0}", actor.Firstname);
                    Console.WriteLine("Actor Last Name: {0}", actor.Lastname);
                }
            }

            Console.ReadLine();

        }
    }
}
