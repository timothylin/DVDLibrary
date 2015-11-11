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
            MovieRepo repo = new MovieRepo();

            var movies = repo.GetAllMovieInfo();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Title);
            }

            Console.ReadLine();

        }
    }
}
