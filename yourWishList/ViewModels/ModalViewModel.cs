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


        /*
            Firebase to rescue 
        */
        public async void AddDatToDB() 
        {
            // Calling Firebase to insert the data   
            Console.WriteLine("funkar här -----------------");
            var succes = await DB.AddWish(wish.Name, wish.Price, wish.Image, wish.Url, wish.Description);
            Console.WriteLine("funkar INTE här -----------------");

            // Succeds to send data to firebase   
            if (succes)
            {
                // Add a new wish to the observableCollection inside landingPageViewModel and bind the context
                var viewModel = new LandingpageViewModel();
                viewModel.MyWishCollection.Add(new Wish { Name = wish.Name, Price = wish.Price, Image = wish.Image, Url = wish.Url, Description = wish.Description });
                var landingpage = new Landingpage();
                landingpage.BindingContext = viewModel;
            }
            else
            {
                Console.WriteLine("Fail to send data to firebase");
            }

        }

      

        public async void GetAllDataFromDB()
        {
            // Check if there is data in Firebase
             if (DB.GetAllWhises() != null)
            {
                // Calling Firebase to insert the data
                await DB.GetAllWhises();
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