using Xamarin.Forms;
using yourWishList.ViewModels;

namespace yourWishList.Views
{
    public partial class Landingpage : ContentPage
    {
        public Landingpage()
        {
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((LandingpageViewModel)BindingContext).RefeshDataForCollectionOfWhises();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((LandingpageViewModel)BindingContext).RefeshDataForCollectionOfWhises();
        }
    }
}
