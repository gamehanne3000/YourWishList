using System;
using System.Collections.ObjectModel;
using yourWishList.Models;

namespace yourWishList.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
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


    }
}
