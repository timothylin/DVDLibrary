using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DVDLibrary.DataLayer.Config;
using DVDLibrary.Models;

namespace DVDLibrary.DataLayer
{
    public class MovieRepo
    {

        public static List<MovieInfo> Movies { get; set; }
        public static List<RentalInfo> Rentals { get; set; }

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
                cmd.CommandText = "select m.MovieID, m.MovieTitle, mpaa.FilmRating, m.ReleaseDate, " +
                                   "d.DirectorID, d.FirstName, d.LastName, s.StudioID, s.StudioName " +
                                    "from Movies m " +
                                    "Join Directors d " +
                                    "on m.DirectorID = d.DirectorID " +
                                    "Join studios s " +
                                    "on m.StudioID = s.StudioID " +
                                    "join MPAARatings mpaa " +
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

        public MovieInfo GetMovieByID(int movieID)
        {
            MovieInfo movie = new MovieInfo();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "select m.MovieID, m.MovieTitle, mpaa.FilmRating, m.ReleaseDate, d.DirectorID, d.FirstName, " +
                                   "d.LastName, s.StudioName, s.StudioID " +
                                    "from Movies m " +
                                    "Join Directors d " +
                                    "on m.DirectorID = d.DirectorID " +
                                    "Join studios s " +
                                    "on m.StudioID = s.StudioID " +
                                    "join MPAARatings mpaa " +
                                    "on m.MPAARatingID = mpaa.MPAARatingID " +
                                    "where m.MovieID = @movieID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        movie = PopulateMovieInfoFromDataReader(dr);
                    }
                }
            }

            return movie;
        }

        public MovieInfo AddMovieWithInput(MovieInfo movie)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", movie.Director.FirstName);
                p.Add("@LastName", movie.Director.LastName);
                p.Add("DirectorID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("InsertDirector", p, commandType: CommandType.StoredProcedure);

                int directorID = p.Get<int>("DirectorID");


                Console.Write(" New Director Id = {0}", directorID);


                var pn = new DynamicParameters();

                pn.Add("@StudioName", movie.Studio.StudioName);

                pn.Add("StudioID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("InsertStudio", pn, commandType: CommandType.StoredProcedure);


                var studioID = pn.Get<int>("StudioID");

                Console.Write("New Studio Id = {0}", studioID);


                var pns = new DynamicParameters();
                pns.Add("@FilmRating", movie.MpaaRating.FilmRating);

                pns.Add("MPAARatingID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("InsertMPAARatings", pns, commandType: CommandType.StoredProcedure);

                var mpaaRatingID = pns.Get<int>("MPAARatingID");

                Console.Write("New MPAARating Id = {0}", mpaaRatingID);


                var pnsm = new DynamicParameters();
                pnsm.Add("@MovieTitle", movie.Title);
                pnsm.Add("@MPAARatingID", mpaaRatingID);
                pnsm.Add("@DirectorID", directorID);
                pnsm.Add("@StudioID", studioID);
                pnsm.Add("@ReleaseDate", movie.ReleaseDate);

                pnsm.Add("MovieID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("InsertMovies", pnsm, commandType: CommandType.StoredProcedure);

                var movieID = pnsm.Get<int>("MovieID");

                Console.Write("New Movie Id = {0}", movieID);

                var pa = new DynamicParameters();

                foreach (var actor in movie.Actors)
                {
                    pa.Add("@FirstName", actor.FirstName);
                    pa.Add("@LastName", actor.LastName);
                }

                pa.Add("ActorID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("InsertActor", pa, commandType: CommandType.StoredProcedure);

                var actorID = pa.Get<int>("ActorID");

                var pma = new DynamicParameters();
                pma.Add("@MovieID", movieID);
                pma.Add("@ActorID", actorID);

                cn.Execute("InsertMovieActors", pnsm, commandType: CommandType.StoredProcedure);

                return GetMovieByID(movieID);
            }
        }

        public MovieInfo RemoveMovieByID(int movieID)
        {
            //removes a movie by ID number which will be listed on display or inputed directly or with a delete button with movie title

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand();
                cmd.CommandText = "delete MovieActors " +
                                  "where MovieID = @MovieID " +
                                  "delete MovieBorrower " + 
                                  "where MovieId = @MovieID " +
                                  "delete Movies " +
                                  "where MovieID = @MovieID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();

                return GetMovieByID(movieID);

            }

        }

        public List<RentalInfo> GetAllBorrowersInfo()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select mb.DateBorrowed, mb.DateReturned, mb.UserNotes, mb.UserRating, " +
                                    "b.FirstName, b.LastName,m.MovieTitle " +
                                    "from MovieBorrower mb " +
                                    "join Borrowers b " +
                                    "on b.BorrowerID = mb.BorrowerID " +
                                    "join Movies m " +
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

        private List<Actor> GetListOfActorsByMovieID(int movieID)
        {
            List<Actor> actors = new List<Actor>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {

                var p = new DynamicParameters();
                p.Add("@MovieID", movieID);
                actors = cn.Query<Actor>("GetActorsByMovieID", p, commandType: CommandType.StoredProcedure).ToList();

            }

            return actors;
        }

        public List<Actor> GetAllActors()

        {

            List<Actor> actors = new List<Actor>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                actors = cn.Query<Actor>("select * from Actors").ToList();
            }

            return actors;
        }

        private RentalInfo PopulateRentalInfoFromDataReader(SqlDataReader dr)

        {

            var rental = new RentalInfo();

            rental.Borrower.BorrowerID = (int)dr["BorrowerID"];
            rental.Borrower.FirstName = dr["FirstName"].ToString();
            rental.Borrower.LastName = dr["LastName"].ToString();
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

        private RentalInfo PopulateBorrowerFromDataReader(SqlDataReader dr)
        {
            // to save info to the right fields and populate class with borrower

            RentalInfo borrower = new RentalInfo();
            borrower.Borrower.BorrowerID = (int)dr["BorrowerID"];
            borrower.Borrower.FirstName = dr["FirstName"].ToString();
            borrower.Borrower.LastName = dr["LastName"].ToString();

            return borrower;
        }

        private MovieInfo PopulateMovieInfoFromDataReader(SqlDataReader dr)
        {
            var movie = new MovieInfo();

            movie.MovieID = (int)dr["MovieID"];
            movie.Title = dr["MovieTitle"].ToString();
            movie.MpaaRating.FilmRating = dr["FilmRating"].ToString();
            movie.Director.DirectorID = (int)dr["DirectorID"];
            movie.Director.FirstName = dr["FirstName"].ToString();
            movie.Director.LastName = dr["LastName"].ToString();
            movie.Studio.StudioID = (int) dr["StudioID"];
            movie.Studio.StudioName = dr["StudioName"].ToString();
            movie.ReleaseDate = (int)dr["ReleaseDate"];
            movie.Actors = GetListOfActorsByMovieID(movie.MovieID);


            return movie;
        }
    }
}
