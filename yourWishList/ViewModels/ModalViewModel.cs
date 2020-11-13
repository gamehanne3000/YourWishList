using System;
using System.Windows.Input;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Services;
using yourWishList.Views;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;

namespace yourWishList.ViewModels
{
    public class ModalViewModel :BaseViewModel
    {
        Database DB = new Database();
        public ICommand CancelWishCommand { get; set; }
        public ICommand CreateWishCommand { get; set; }
        private Wish wish;

        public ModalViewModel()
        {
            CancelWishCommand = new Command(CancelWish);
            CreateWishCommand = new Command(CreateWish);
            wish = new Wish();
        }

        /*
            Properties 
        */
        public Wish Wish
        {
            get { return wish; }
            set { wish = value; OnPropertyChanged(); }
        }

        /*
            Firebase to rescue 
        */
        public async void AddDatToDB() 
        {
            // Calling Firebase to insert the data   
            var succes = await DB.AddWish(wish.WishId, wish.Name, wish.Price, wish.Image, wish.Url, wish.Description);

            // Succeds to send data to firebase   
            if (succes)
            {
                // Add a new wish to the observableCollection inside landingPageViewModel and bind the context
                var viewModel = new LandingpageViewModel();
                viewModel.WishCollection.Add(new Wish { WishId = wish.WishId, Name = wish.Name, Price = wish.Price, Image = wish.Image, Url = wish.Url, Description = wish.Description });
                var landingpage = new Landingpage();
                landingpage.BindingContext = viewModel;
            }
            else
            {
                Console.WriteLine("Fail to send data to firebase");
            }
        }


        public async void GetDataFromDB()
        {
            // Check if there is data in Firebase
             if (DB.GetAllWhises() != null)
            {
                // Calling Firebase to insert the data
                await DB.GetAllWhises();
                Console.WriteLine("congrats you have a wish");
            }
            else
            {
                Console.WriteLine("There is no data to fetch");
            }
            
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