using System;
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
        public ObservableCollection<Wish> WishCollection { get; set; }
        public ICommand GoToModalAddWishCommand { get; set; }
        private ObservableCollection<Wish> wishes;
        ModalViewModel mv = new ModalViewModel();
        Database DB = new Database();
        private Wish selectedWish;

        public LandingpageViewModel()
        {
            // For Showing purposes
            wishes = GetWishes();

            // NEW ObservableCollection
            WishCollection = new ObservableCollection<Wish>();
            WishCollection.CollectionChanged += WishCollection_CollectionChanged;

            // Open PopUp for adding item
            GoToModalAddWishCommand = new Command(GoToModalAddWish);
        }

        /*
            Properties 
        */
        public ObservableCollection<Wish> Wishes
        {
            get { return wishes; }
            set { wishes = value; OnPropertyChanged(); }
        }
        public Wish SelectedWish
        {
            get { return selectedWish; }
            set { selectedWish = value; OnPropertyChanged(); }
        }

        // EventHandler that tracks when a new item is added in the observableCollection
        private void WishCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e){
            {
                // Identify that an object is added
                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        Console.WriteLine("{0}: {1}", e.Action, item);
                        Console.WriteLine(string.Join(", ", item));
                    }
                }
            }
        } 


        /* 
          Display in a new page the details about the given wish selected by the user
        */
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

        
        // For Showing purposes
        private ObservableCollection<Wish> GetWishes()
        {
            return new ObservableCollection<Wish>
            {
                new Wish {
                    Name = "Skärm",
                    Price = "4490",
                    Image = "display.png",
                    Description = "Xiaomi Mi 34 curved gaming monitor",
                    Url = "www.yourWislist1.com"
                },
                new Wish {
                    Name = "Dator mus",
                    Price = "790",
                    Image = "mouse.png",
                    Description = "Logitech MX Master 3 Advanced Trådlös Mus",
                    Url = "www.yourWislist2.com"
                },
                new Wish {
                    Name = "Tangentbord",
                    Price = "999",
                    Image = "keyboard.png",
                    Description = "Logitech MX Keys -> Trådlös / Bakgrundsbelyst",
                    Url = "www.yourWislist3.com"
                },
                new Wish {
                    Name = "Hörlurar",
                    Price = "2090",
                    Image = "earphones.png",
                    Description = "Corsair Virtuoso RGB trådlöst headset gaming",
                    Url = "www.yourWislist4.com"
                },
                new Wish {
                    Name = "Gaming mus",
                    Price = "599",
                    Image = "gamingMouse.png",
                    Description = "Corsair Ironclaw RGB gamingmus (svart)",
                    Url = "www.yourWislist5.com"
                }
            };
        }


        /*
           Everytime that the landingPage is at the top of the view stack -> RELOAD with this information 
        */
        public void RefeshDataForCollectionOfWhises()
        {
            Console.WriteLine("refreshing the collectionView");
            mv.GetDataFromDB();
                        
            foreach (var items in WishCollection)
            {
                Console.WriteLine(items);
            }
        } 


        /*
            Navigate to PopUp modal  
        */
        private void GoToModalAddWish()
        {
            PopupNavigation.Instance.PushAsync(new Modal());
        }
    }
}

