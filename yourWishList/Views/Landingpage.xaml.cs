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
            InitializeComponent();
        }

        // Create a property of the type "Wish" inside ObservableCollection
        public ObservableCollection<Wish> allWihises { get; set; }

        // when .....
        protected override void OnAppearing()
        {
            base.OnAppearing();
            allWihises = new ObservableCollection<Wish>(Database.Get());
            CollectionOfWhishes.ItemsSource = allWihises;
        }
    }
}
