using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace ArcTouchApp.Views
{
    public partial class MainMenuPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}