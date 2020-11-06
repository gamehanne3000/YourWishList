using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using yourWishList.Models;
using yourWishList.Views;

namespace yourWishList.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public DetailsViewModel()
        {
            GoBackCommand = new Command(goBack);
        }

        ObservableCollection<Wish> wishes;
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

        private int position;
        public int Position
        {
            get
            {
                if (position != wishes.IndexOf(selectedWish))
                    return wishes.IndexOf(selectedWish);

                return position;
            }
            set
            {
                position = value;
                selectedWish = wishes[position];

                // Listen to this property but also what is selected
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedWish));
            }
        }

        public ICommand GoBackCommand { get; set; }
        
        public void goBack()
        {
            Console.WriteLine("Hello, World!");
            Application.Current.MainPage = new NavigationPage(new Landingpage());
        }

    }
}
