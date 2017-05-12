using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcTouchApp.Models;
using ArcTouchApp.Repositories;
using ArcTouchApp.DTOS;
using System.Linq;

namespace ArcTouchApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IImageService _imageService;
        private IEnumerable<GenreDTO> _genres;
        

        public MovieService(IMovieRepository movieRepo, IGenreRepository genreRepo,
            IImageService imageService)
        {
            _movieRepository = movieRepo;
            _genreRepository = genreRepo;            
            _imageService = imageService;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            if (_genres == null)
                _genres = await _genreRepository.GetGenreListAsync();

            var dto = await _movieRepository.GetMovieAsync(id);
            if (dto != null)
            {
                return new Movie()
                {
                    Id = dto.id,
                    Title = dto.title,
                    ReleaseDate = dto.release_date,
                    Genre = string.Join(", ", dto.genres.Select(g => g.name).ToArray()),
                    ImageUrl = GetImageUrl("w780", dto.poster_path ?? dto.backdrop_path)
                };
            }
            throw new InvalidOperationException("Invalid movie ID");
        }

        public async Task<IEnumerable<MovieInfo>> GetMoviesByTitleAsync(string title)
        {
            if (_genres == null)
                _genres = await _genreRepository.GetGenreListAsync();

            var result = await _movieRepository.SearchMovieByTitle(title);
            if (result != null)
            {
                return result.Select(r => new MovieInfo()
                {
                    Id = r.id,
                    Title = r.title,
                    ReleaseDate = r.release_date,
                    Genre = GetMovieGenres(r.genre_ids),
                    ImageUrl = GetImageUrl("w500", r.poster_path ?? r.backdrop_path)
                });
            }
            throw new InvalidOperationException("No results found.");
        }

        public async Task<IEnumerable<MovieInfo>> GetUpcomingMoviesAsync(int page = 1)
        {
            if (_genres == null)
                _genres = await _genreRepository.GetGenreListAsync();

            var movies = await _movieRepository.GetUpcomingMoviesAsync(page);
            if (movies != null)
            {
                return movies.Select(movie => new MovieInfo()
                {
                    Id = movie.id,
                    Title = movie.title,
                    ReleaseDate = movie.release_date,
                    ImageUrl = GetImageUrl("w500", movie.poster_path ?? movie.backdrop_path ?? null),
                    Genre = GetMovieGenres(movie.genre_ids)
                });
            }
            throw new InvalidOperationException("No upcoming movies found.");
        }

        private string GetMovieGenres(int[] genre_ids)
        {
            List<string> genres = new List<string>();
            foreach (var id in genre_ids)
            {
                genres.Add(_genres.Where(g => g.id == id)
                    .Select(g => g.name)
                    .First());
            }
            return string.Join(", ", genres.ToArray());
        }

        private string GetImageUrl(string size, string path)
        {
            return _imageService.ResolvePosterImageAsync(size, path).GetAwaiter().GetResult();
        }
    }
}