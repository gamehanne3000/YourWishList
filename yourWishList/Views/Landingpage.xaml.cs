using Xamarin.Forms;
using yourWishList.ViewModels;

namespace yourWishList.Views
{
    public partial class Landingpage : ContentPage
    {
        public Landingpage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((LandingpageViewModel)BindingContext).RefeshDataForCollectionOfWhises();
        }
    }
}
