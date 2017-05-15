using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcTouchApp.ViewModels
{
    public class MainMenuPageViewModel : BindableBase, IMasterDetailPageOptions
    {
        public MainMenuPageViewModel(INavigationService navigationService)
        {
            Goto = new DelegateCommand<string>((url) =>
            {
                navigationService.NavigateAsync($"NavigationPage/{url}");
            });
        }

        public DelegateCommand<string> Goto { get; set; }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}