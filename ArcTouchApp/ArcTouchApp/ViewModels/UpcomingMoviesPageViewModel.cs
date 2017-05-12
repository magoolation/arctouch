using ArcTouchApp.Models;
using ArcTouchApp.Repositories;
using ArcTouchApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcTouchApp.ViewModels
{
    public class UpcomingMoviesPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMovieService _movieService;

        private MovieInfo _selectedMovie;
        public MovieInfo SelectedMovie
        {
            get { return _selectedMovie; }
            set { SetProperty(ref _selectedMovie, value); }
        }
        
        public DelegateCommand<MovieInfo> GoToMovie { get; set; }

        private ObservableCollection<MovieInfo> _movies;
        public ObservableCollection<MovieInfo> UpcomingMovies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public UpcomingMoviesPageViewModel(IMovieService movieService, INavigationService navigationService)
        {
            _movieService = movieService;

            GoToMovie = new DelegateCommand<MovieInfo>((movie) =>
            {
                var p = new NavigationParameters();
                p.Add("id", movie.Id);
                navigationService.NavigateAsync("MoviePage", p);
            });
            InfinityScroll = new DelegateCommand<MovieInfo>(GetNextPage);
        }

        public DelegateCommand<MovieInfo> InfinityScroll { get; set; }
        private int _currentPage = 0;

        private async void GetNextPage(MovieInfo lastItem)
        {
            if(_movies.Last() == lastItem)
            {
                var movies = await _movieService.GetUpcomingMoviesAsync(++_currentPage);
                if(movies != null)
                {
                    foreach (var movie in movies)
                        _movies.Add(movie);
                }
            }
        }
        

        public void OnNavigatedFrom(NavigationParameters parameters)
        {            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {            
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("movies"))
            {
                var movies = (IEnumerable<MovieInfo>)parameters["movies"];
                UpcomingMovies = new ObservableCollection<MovieInfo>(movies);
            }
            else
            {
                var movies = await _movieService.GetUpcomingMoviesAsync(++_currentPage);
                UpcomingMovies = new ObservableCollection<MovieInfo>(movies);
            }
        }
    }
}
