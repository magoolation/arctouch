using ArcTouchApp.Models;
using ArcTouchApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace ArcTouchApp.ViewModels
{
    public class SearchMoviesPageViewModel : BindableBase
    {
        private readonly IMovieService _movieService;

        public SearchMoviesPageViewModel(IMovieService movieService, INavigationService navigationService)
        {
            _movieService = movieService;

            Search = new DelegateCommand(async () =>
            {
                Movies = new ObservableCollection<MovieInfo>(await _movieService.GetMoviesByTitleAsync(SearchCriteria).ConfigureAwait(false));
            });

            GoToMovie = new DelegateCommand<MovieInfo>(movie =>
            {
                var p = new NavigationParameters();
                p.Add("id", movie.Id);
                navigationService.NavigateAsync("MoviePage", p);
            });

        }

        private string _searchCriteria;
        public string SearchCriteria
        {
            get { return _searchCriteria; ; }
            set { SetProperty(ref _searchCriteria, value); }
        }

        private ObservableCollection<MovieInfo> _movies;
        public ObservableCollection<MovieInfo> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public DelegateCommand<MovieInfo> GoToMovie { get; set; }
        public DelegateCommand Search { get; set; }
    }    
}