using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Services;
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
    }
}
