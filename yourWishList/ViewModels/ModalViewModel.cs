using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Views;

namespace yourWishList.ViewModels
{
    public class ModalViewModel :BaseViewModel
    {
        public ModalViewModel()
        {
            CancelWishCommand = new Command(cancelWish);
            CreateWishCommand = new Command(createWish);
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



   
        /*
            Create button 
        */

        public ICommand CreateWishCommand { get; set; }

        private void createWish()
        {
            Console.WriteLine(Wish.Name);
            

        }

        /*
            Cancel button 
        */

        public ICommand CancelWishCommand { get; set; }


        private void cancelWish()
        {
            Console.WriteLine("hejsan");
        }
    }
}



        /*private ..... image;
        public ..... Image
        {
            get { return }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }*/







/*
 * DELETE AFTERWARDS
 * 

 // Creating a collection of whises 
        private ObservableCollection<Wish> GetWishes()
        {
            return new ObservableCollection<Wish>
            {
                new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
                new Wish { Name = "Dator mus", Price = 790f, Image = "mouse.png", Description = "Logitech MX Master 3 Advanced Trådlös Mus"},
                new Wish { Name = "Tangentbord", Price = 999f, Image = "keyboard.png", Description = "Logitech MX Keys -> Trådlös / Bakgrundsbelyst"},
                new Wish { Name = "Hörlurar", Price = 2090f, Image = "earphones.png", Description = "Corsair Virtuoso RGB trådlöst headset gaming"},
                new Wish { Name = "Gaming mus", Price = 599f, Image = "gamingMouse.png", Description = "Corsair Ironclaw RGB gamingmus (svart)"}
            };
        }

if (selectedWish != null)
            {
                // Sending the properties to the DetailsViewModel and pushing it to the bindingcontext on the "details" Page
                var viewModel = new DetailsViewModel { SelectedWish = selectedWish, Wishes = wishes, Position = wishes.IndexOf(selectedWish) };
                var detailsPage = new DetailsPage();
                detailsPage.BindingContext = viewModel;

                // navigate to the details page
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);

                //await Application.Current.MainPage.Navigation.PushAsync(detailsPage);

                selectedWish = null;
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
*/