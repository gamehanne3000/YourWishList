using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Services;
using yourWishList.Views;

namespace yourWishList.ViewModels
{
    public class LandingpageViewModel : BaseViewModel
    {
        public ICommand SelectionCommand => new Command(DisplayAWish);
        public ICommand GoToModalAddWishCommand { get; set; }
        Database DB = new Database();
        private Wish _selectedWish;


        public LandingpageViewModel()
        {
            GoToModalAddWishCommand = new Command(GoToModalAddWish);
            _mywishCollection = new ObservableCollection<Wish>();
        }

        private ObservableCollection<Wish> _mywishCollection;
        public ObservableCollection<Wish> MyWishCollection
        {
            get { return _mywishCollection; }
            set { _mywishCollection = value; OnPropertyChanged(); }
        }

        public Wish SelectedWish
        {
            get { return _selectedWish; }
            set { _selectedWish = value; OnPropertyChanged(); }
        }


        /* 
          Display in a new page the details about the given wish selected by the user
        */
        private void DisplayAWish()
        {
            if (_selectedWish != null)
            {
                // Sending the properties to the DetailsViewModel and pushing it to the bindingcontext on the "details" Page
                var viewModel = new DetailsViewModel { SelectedWish = _selectedWish, Wishes = MyWishCollection, Position = MyWishCollection.IndexOf(_selectedWish) };
                var detailsPage = new DetailsPage();
                detailsPage.BindingContext = viewModel;

                // navigate to the details page
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
                _selectedWish = null;
            }
        }


        /*
           Everytime that the landingPage is at the top of the view stack -> RELOAD with this information 
        */

        public async void RefeshDataForCollectionOfWhises()
        {
            _mywishCollection.Clear();
            foreach (var item in await DB.GetAllWhises())
            {
                MyWishCollection.Add(item);
                Console.WriteLine("i am inside");
            }
        }


        /*
            Navigate to PopUp modal  
        */
        private void GoToModalAddWish()
        {
            PopupNavigation.Instance.Popped += (sender, args) =>
            {
                RefeshDataForCollectionOfWhises();
            };
            PopupNavigation.Instance.PushAsync(new Modal(MyWishCollection));
        }
    }
}
