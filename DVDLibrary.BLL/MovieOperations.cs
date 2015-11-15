using System;
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
        private MovieRepo _repo = new MovieRepo();
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

        public Response AddMovie(MovieInfo movieToAdd)
        {
            _response = new Response();

            var movie = _repo.AddMovieWithInput(movieToAdd);

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

        public Response RemoveMovie(int movieID)
        {
            _response = new Response();

            var movie = _repo.RemoveMovieByID(movieID);

            if (movie == null)
            {
                _response.Success = true;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }

        public Response TrackDvd(int movieID)
        {
            _response = new Response();
            _response.Rentals = _repo.TrackDvdByMovieID(movieID);
            return _response;
        }

        //public Response CheckIn()
        //{
        //    _response = new Response();
        //    _response.Rentals = _repo.CheckInDvd();
        //    return _response;
        //}

        //public Response CheckOut()
        //{
        //    _response = new Response();
        //    _response.Rentals = _repo.CheckOutDvd();
        //    return _response;
        //}

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
        //***********************************************************************
        //***********Ussing for the dropdownList for Add/HomeController********* 
        public List<MpaaRating> GetMPAARatingsList()
        {
            var ratings = _repo.GetAllMpaaRatings();
            return ratings;
        } 
        //*************************************************************************
    }
}
