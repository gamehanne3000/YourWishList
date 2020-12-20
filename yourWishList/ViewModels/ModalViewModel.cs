using System;
using System.Windows.Input;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Services;
using yourWishList.Views;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;

namespace yourWishList.ViewModels
{
    public class ModalViewModel :BaseViewModel
    {
        Database DB = new Database();
        public ICommand CancelWishCommand { get; set; }
        public ICommand CreateWishCommand { get; set; }

        public ModalViewModel()
        {
            CancelWishCommand = new Command(CancelWish);
            CreateWishCommand = new Command(CreateWish);
            wish = new Wish();
        }

        /*
            Properties 
        */
       
        private Wish wish;
        public Wish Wish
        {
            get { return wish; }
            set { wish = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Wish> Collection { get; set; }

        /*
            Firebase to rescue 
        */
        public async void AddDatToDB()
        {
            // Calling Firebase to insert the data   
            await DB.AddWish(wish.Name, wish.Price, wish.Image, wish.Url, wish.Description);
            Collection.Add(wish);
        }

        /*
            Create button 
        */
        private void CreateWish()
        {
            // Using Xamarin essentials i make sure that the users internet is on
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                App.Current.MainPage.DisplayAlert("No Internet", "", "OK");
            }
            else
            {
                // Send data to Firebase
                AddDatToDB();
                // Go back
                PopupNavigation.Instance.PopAsync();
            }
        }


        /*
            Cancel button 
        */
        private void CancelWish()
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}