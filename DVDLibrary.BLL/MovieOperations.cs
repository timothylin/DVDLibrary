﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DataLayer;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public class MovieOperations
    {
        private static MovieRepo _repo = new MovieRepo();
        private Response _response;

        public MovieOperations()
        {
            _response = new Response();
        }

        public Response GetAllMovies()
        {
            _response = new Response();
            _response.Movies = _repo.GetAllMovieInfo();

            return _response;
        }

        public Response GetMovieByID(int movieID)
        {
            _response = new Response();
            var movie = _repo.GetMovieByID(movieID);

            if (movie != null)
            {
                _response.Success = true;
                _response.Movie = movie;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }

        public Response AddMovie(string movieTitle, string filmRating, string dFirstName, string dLastName, string studioName, int releaseDate)
        {
            _response = new Response();
            return _response;
        }

        public Response RemoveMovie(int movieID)
        {
            _response = new Response();
            return _response;
        }

        public Response TrackDvd()
        {
            _response = new Response();
            _response.Rentals = _repo.TrackAllDvds();
            return _response;
        }

        public Response CheckIn()
        {
            _response = new Response();
            _response.Rentals = _repo.CheckInDvd();
            return _response;
        }

        public Response CheckOut()
        {
            _response = new Response();
            _response.Rentals = _repo.CheckOutDvd();
            return _response;
        }

        public Response SearchByTitle(string title)
        {
            _response = new Response();
            return _response;
        }

        public Response GetAllBorrowers()
        {
            _response = new Response();
            _response.Rentals = _repo.GetAllBorrowersInfo();
            return _response;
        }

        public Response GetBorrowerByID(int borrowerID)
        {
            _response = new Response();
            var rental = _repo.GetBorrowerByID(borrowerID);

            if (rental != null)
            {
                _response.Success = true;
                _response.Rental = rental;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }
    }
}
