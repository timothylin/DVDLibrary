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
                cmd.CommandText = "select * " +
                                  "FROM Movies m ";
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

            //movie.MovieID = (int)dr["MovieID"];
            //movie.Title = dr["Title"].ToString();
            //movie.MPAARating = dr["Rating"].ToString();
            //movie.UserRating = dr["UserRating"].ToString();
            //movie.ActorLastname = dr["Actors"].ToString();
            //movie.UserNotes = dr["UserNotes"].ToString();
            //movie.Studio = dr["Studio"].ToString();

            //if (dr["ReleaseDate"] != DBNull.Value)
            //    movie.ReleaseDate = (DateTime)dr["ReleaseDate"];

            return movie;
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


    }
}
