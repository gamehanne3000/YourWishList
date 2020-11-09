using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using yourWishList.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace yourWishList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Landingpage());
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
