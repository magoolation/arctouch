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
            builder.RegisterType<MockMovieRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<MockGenreRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<MockConfigurationRepository>().AsImplementedInterfaces().SingleInstance();
#else
            builder.RegisterType<MovieRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<GenreRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ConfigurationRepository>().AsImplementedInterfaces().SingleInstance();
#endif
            builder.RegisterType<ImageService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<MovieService>().AsImplementedInterfaces().SingleInstance();

            return builder.Build();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<UpcomingMoviesPage>();
            Container.RegisterTypeForNavigation<MoviePage>();
            Container.RegisterTypeForNavigation<SeachMoviePage>();
            Container.RegisterTypeForNavigation<MainMenuPage>();
        }
    }
}
