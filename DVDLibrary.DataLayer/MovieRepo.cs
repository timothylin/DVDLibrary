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

            movie.MovieID = (int)dr["MovieID"];
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
    }
}
