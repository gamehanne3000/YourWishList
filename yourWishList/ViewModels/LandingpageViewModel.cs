using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Views;

namespace yourWishList.ViewModels
{
    public class LandingpageViewModel : BaseViewModel
    {
        public LandingpageViewModel()
        {
            wishes = GetWishes();
            GoToModalAddWishCommand = new Command(goToModalAddWish);
        }
        private ObservableCollection<Wish> wishes;
        public ObservableCollection<Wish> Wishes
        {
            get { return wishes; }
            set
            {
                wishes = value;
                OnPropertyChanged();
            }
        }

        private Wish selectedWish;
        public Wish SelectedWish
        {
            get { return selectedWish; }
            set
            {
                selectedWish = value;
                OnPropertyChanged();
            }
        }

     
        // display in a new page the details about the given wish selected by the user
        public ICommand SelectionCommand => new Command(DisplayAWish);

        private void DisplayAWish()
        {
            if (selectedWish != null)
            {
                // Sending the properties to the DetailsViewModel and pushing it to the bindingcontext on the "details" Page
                var viewModel = new DetailsViewModel { SelectedWish = selectedWish, Wishes = wishes, Position = wishes.IndexOf(selectedWish) };
                var detailsPage = new DetailsPage();
                detailsPage.BindingContext = viewModel;

                // navigate to the details page
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);

                selectedWish = null;
            }
        }

        // -------------------

        //public void getWish(Wish WishCollection)
        //{
        //    var WishCollection = 
        //    ObservableCollection<Wish> WishCollection = new ObservableCollection<Wish> ();
        //    WishCollection.Add(new Wish() { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor" });

           
        //}

        // -------------------

        // Creating a collection of whises 
        private ObservableCollection<Wish> GetWishes()
        {
            return new ObservableCollection<Wish>
            {
                // Display  ------------

                //new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
                //new Wish { Name = "Dator mus", Price = 790f, Image = "mouse.png", Description = "Logitech MX Master 3 Advanced Trådlös Mus"},
                //new Wish { Name = "Tangentbord", Price = 999f, Image = "keyboard.png", Description = "Logitech MX Keys -> Trådlös / Bakgrundsbelyst"},
                //new Wish { Name = "Hörlurar", Price = 2090f, Image = "earphones.png", Description = "Corsair Virtuoso RGB trådlöst headset gaming"},
                //new Wish { Name = "Gaming mus", Price = 599f, Image = "gamingMouse.png", Description = "Corsair Ironclaw RGB gamingmus (svart)"}
            };
        }


        /*
            Navigate to PopUp modal to add a whish 
        */
        public ICommand GoToModalAddWishCommand { get; set; }

        private void goToModalAddWish()
        {
            /*
             From Docs: there is no concept of performing modal stack manipulation, or popping to the root page in modal navigation.
             Which means that a "NavigationPage" instance is not required for performing modal page navigation.

            => This leads me to go for "Modalstack" instead of "NavigationPage" as it spawns a new navigation stack and shows
                pages on top of everything else (hence modal)
             */

            PopupNavigation.Instance.PushAsync(new Modal());
        }
    }
}

