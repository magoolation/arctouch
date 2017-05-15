using ArcTouchApp.Models;
using ArcTouchApp.Services;
using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace ArcTouchApp.ViewModels
{
    public class MoviePageViewModel : BindableBase, INavigationAware
    {
        private readonly IMovieService _movieService;

        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        public MoviePageViewModel(IMovieService movieService)
        {
            _movieService = movieService;

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("id"))
            {
                var id = Convert.ToInt32(parameters["id"]);
                Movie = await _movieService.GetMovieAsync(id).ConfigureAwait(false);
            }
        }
    }
}
