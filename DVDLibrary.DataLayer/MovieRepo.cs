using System;
using System.Collections.Generic;
using System.Data;
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

        public List<MovieInfo> Movies { get; set; } 
        public List<RentalInfo> Rentals { get; set; }

        public MovieRepo()
        {
            Movies = new List<MovieInfo>();
            Rentals = new List<RentalInfo>();
        }

        public List<MovieInfo> GetAllMovieInfo()
        {
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
                        Movies.Add(PopulateMovieInfoFromDataReader(dr));
                    }
                }
            }

            return Movies;
        }

        private MovieInfo PopulateMovieInfoFromDataReader(SqlDataReader dr)
        {
            var movie = new MovieInfo();

            movie.MovieId = (int)dr["MovieID"];
            movie.Title = dr["MovieTitle"].ToString();
            movie.MpaaRating = dr["FilmRating"].ToString();
            movie.Director = dr["LastName"].ToString();
            movie.Studio = dr["StudioName"].ToString();
            movie.ReleaseDate = (int) dr["ReleaseDate"];
            //movie.Director = string.Concat(dr["DirectorFirstName"].ToString(), " ", dr["DirectorLastName"].ToString());
            movie.Actors = PopulateActorsFromDataReader(dr);


            return movie;
        }

        private List<Actor> PopulateActorsFromDataReader(SqlDataReader dr)

        {
            return new List<Actor>();
        }



        public RentalInfo GetBorrowerByID(int borrowerID)
        {
            // processes and returns borrower with  number to identify specific borrower

            RentalInfo borrower = new RentalInfo();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "select * " +
                                  " from Borrowers b " +
                                  "where b.BorrowerID = @BorrowerID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        borrower = PopulateBorrowerFromDataReader(dr);
                    }
                }
            }

            return borrower;
        }

        public List<RentalInfo> GetAllBorrowersInfo()
        {
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
                        Rentals.Add(PopulateRentalInfoFromDataReader(dr));
                    }
                }
            }
            return Rentals;
        }


        private RentalInfo PopulateBorrowerFromDataReader(SqlDataReader dr)
        {
            // to save info to the right fields and populate class with borrower

            RentalInfo borrower = new RentalInfo();
            borrower.BorrowerId = (int)dr["BorrowerID"];
            borrower.FirstName = dr["FirstName"].ToString();
            borrower.LastName = dr["LastName"].ToString();
           
            return borrower;
        }


        public void RemoveMovieByID(int movieID)
        {
            //removes a movie by ID number which will be listed on display or inputed directly or with a delete button with movie title

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "delete Movies " +
                                  "where MovieID = @MovieID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();


            }
            
        }




        public void AddMovie(string movietitle, int mpaaratingID, int directorID, int studioID, int releaseDate)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "insert into Movies (MovieTitle, MPAARatingID, DirectorID, StudioID, ReleaseDate)" +
                                  "values(@MovieTitle, @MPAARatingID, @DirectorID, @StudioID, @ReleaseDate)";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@MovieTitle", movietitle);
                cmd.Parameters.AddWithValue("@MPAARatingID", mpaaratingID);
                cmd.Parameters.AddWithValue("@DirectorID", directorID);
                cmd.Parameters.AddWithValue("@StudioID", studioID);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();


            }
        }

      


        private RentalInfo PopulateRentalInfoFromDataReader(SqlDataReader dr)
        {

            var rental = new RentalInfo();

            rental.BorrowerId = (int)dr["BorrowerID"];
            rental.FirstName = dr["FirstName"].ToString();
            rental.LastName = dr["LastName"].ToString();
            rental.Movie = PopulateMovieInfoFromDataReader(dr);

            if (dr["UserNotes"] != DBNull.Value)
                rental.UserNotes = dr["UserNotes"].ToString();

            if (dr["UserRating"] != DBNull.Value)
                rental.UserRating = (int)dr["UserRating"];


            if (dr["DateBorrowed"] != DBNull.Value)
                rental.RentalDate = DateTime.Parse(dr["DateBorrowed"].ToString());


            if (dr["DateReturned"] != DBNull.Value)
                rental.ReturnDate = DateTime.Parse(dr["DateReturned"].ToString());

            return rental;
        }


        public List<RentalInfo> TrackAllDvds()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "TrackAllDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Rentals.Add(PopulateRentalInfoFromDataReader(dr));
                    }
                }
            }

            return Rentals;
        }

        public List<RentalInfo> CheckOutDvd()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "CheckOutDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Rentals.Add(PopulateRentalInfoFromDataReader(dr));
                    }
                }
            }

            return Rentals;
        }

        public List<RentalInfo> CheckInDvd()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "CheckInDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Rentals.Add(PopulateRentalInfoFromDataReader(dr));
                    }
                }
            }

            return Rentals;
        }
    }
}
