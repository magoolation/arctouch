using ArcTouchApp.Models;
using ArcTouchApp.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchPOC
{
    class Program
    {
        private static MovieRepository _movieRepo;
        private static IEnumerable<Genre> _genres;
        private static GenreRepository _genreRepo;
        private static ConfigurationRepository _configRepo;

        static void Main(string[] args)
        {
            _genreRepo = new GenreRepository();
            _genres = _genreRepo.GetGenreListAsync().Result;
            _movieRepo = new MovieRepository(_genres);
            _configRepo = new ConfigurationRepository();

            Task.WaitAll(Genres(), Upcoming(),
                GetMovie(),
                SearchMovies(),
                GetConfiguration());
            Console.WriteLine("Press ENTER to finish.");
            Console.ReadLine();
        }

        private static async Task GetConfiguration()
        {
            var config = await _configRepo.GetConfigurationsAsync();
            Console.WriteLine($"{config.images.base_url}");
            foreach (var size in config.images.poster_sizes)
            {
                Console.WriteLine($"{size}");
            }
        }

        private static async Task Genres()
        {
            Console.WriteLine();
            Console.WriteLine("Get Genres");
            Console.WriteLine();
            var genres = await _genreRepo.GetGenreListAsync();
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.Name}");
            }
        }

        private static async Task           ()
        {
            Console.WriteLine();
            Console.WriteLine("Get Upcoming movies");
            Console.WriteLine();            
            try
            {
                var upcoming = await _movieRepo.GetUpcomingMoviesAsync();
                foreach (var movie in upcoming)
                {
                    Console.WriteLine($"{movie.Title}\n{movie.Genre}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task GetMovie()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Get a movie");
                Console.WriteLine();
                var movie = await _movieRepo.GetMovieAsync(283995);
                Console.WriteLine($"{movie.Title}\n{movie.Genre}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task SearchMovies()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Search by Title");
                Console.WriteLine();

                var movies = await _movieRepo.SearchMovieByTitle("Fast");
                foreach(var movie in movies)
                {
                    Console.WriteLine($"{movie.Title}\n{movie.Genre}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}