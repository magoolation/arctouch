using Autofac;
using Prism.Autofac;
using Prism.Autofac.Forms;
using ArcTouchApp.Views;
using Xamarin.Forms;
using ArcTouchApp.Repositories;
using System.Diagnostics;
using System;
using ArcTouchApp.Services;
using System.Threading.Tasks;
using Prism.Navigation;

namespace ArcTouchApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            try
            {                
                NavigationService.NavigateAsync("MainMenuPage/NavigationPage/UpcomingMoviesPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }        

        protected override IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

#if DEBUG_
            builder.RegisterType<MockMovieRepository>().AsImplementedInterfaces();
            builder.RegisterType<MockGenreRepository>().AsImplementedInterfaces();
            builder.RegisterType<MockConfigurationRepository>().AsImplementedInterfaces();
#else
            builder.RegisterType<MovieRepository>().AsImplementedInterfaces();
            builder.RegisterType<GenreRepository>().AsImplementedInterfaces();
            builder.RegisterType<ConfigurationRepository>().AsImplementedInterfaces();
#endif
            builder.RegisterType<ImageService>().AsImplementedInterfaces();
            builder.RegisterType<MovieService>().AsImplementedInterfaces();

            return builder.Build();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<UpcomingMoviesPage>();
            Container.RegisterTypeForNavigation<MoviePage>();
            Container.RegisterTypeForNavigation<SearchMoviesPage>();
            Container.RegisterTypeForNavigation<MainMenuPage>();
        }
    }
}
