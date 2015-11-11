using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DataLayer.Config;
using DVDLibrary.Models;

namespace DVDLibrary.DataLayer
{
    public class MovieRepo
    {

        public List<MovieInfo> GetAllMovieInfo()
        {
            List<MovieInfo> movies = new List<MovieInfo>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select m.MovieId, m.MovieTitle, mpaa.FilmRating, m.ReleaseDate, " +
                                   "d.LastName, s.StudioName "+
                                    "from Movies m "+
                                    "Join Directors d "+
                                    "on m.DirectorID = d.DirectorID "+
                                    "Join studios s "+
                                    "on m.StudioID = s.StudioID "+
                                    "join MPAARatings mpaa "+
                                    "on m.MPAARatingID = mpaa.MPAARatingID ";
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        movies.Add(PopulateMovieInfoFromDataReader(dr));
                    }
                }
            }

            return movies;
        }

        private MovieInfo PopulateMovieInfoFromDataReader(SqlDataReader dr)
        {
            MovieInfo movie = new MovieInfo();

            movie.MovieId = (int)dr["MovieID"];
            movie.Title = dr["MovieTitle"].ToString();
            movie.MpaaRating = dr["FilmRating"].ToString();
            movie.Director = dr["LastName"].ToString();
            movie.Studio = dr["StudioName"].ToString();
            movie.ReleaseDate = (int)dr["ReleaseDate"];

            return movie;
        }

        public List<RentalInfo> GetAllBorrowersInfo()
        {
            List<RentalInfo> rentals = new List<RentalInfo>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select mb.DateBorrowed, mb.DateReturned, mb.UserNotes, mb.UserRating, "+
                                    "b.FirstName, b.LastName,m.MovieTitle "+
                                    "from MovieBorrower mb "+
                                    "join Borrowers b "+
                                    "on b.BorrowerID = mb.BorrowerID "+
                                    "join Movies m "+
                                    "on m.MovieID = mb.MovieID";
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        rentals.Add(PopulateRentalInfoFromDataReader(dr));
                    }
                }
            }

            return rentals;
        }

        private RentalInfo PopulateRentalInfoFromDataReader(SqlDataReader dr)
        {
            RentalInfo rental = new RentalInfo();

            rental.BorrowerId = (int)dr["BorrowerID"];
            rental.FirstName = dr["FirstName"].ToString();
            rental.LastName = dr["LastName"].ToString();
            rental.Movie.Title = dr["MovieTitle"].ToString();

            if (dr["UserNotes"] != DBNull.Value)
                rental.UserNotes = dr["UserNotes"].ToString();

            if (dr["UserRating"] != DBNull.Value)
                rental.UserRating = (int)dr["UserRating"];


            if (dr["DateBorrowed"] != DBNull.Value)
                rental.RentalDate = (DateTime)dr["RentalDate"];


            if (dr["DateReturned"] != DBNull.Value)
                rental.ReturnDate = (DateTime)dr["DateReturned"];

            return rental;
        }
    }
}
