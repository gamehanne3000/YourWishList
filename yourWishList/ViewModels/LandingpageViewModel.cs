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
        ModalViewModel mv = new ModalViewModel();
        Database DB = new Database();
        private Wish selectedWish;


        public LandingpageViewModel()
        {          
            // Open PopUp for adding item
            GoToModalAddWishCommand = new Command(GoToModalAddWish);


            // ObservableCollection
           
            
        }


        /*
            Properties 
        */
        private ObservableCollection<Wish> MywishCollection; 
        public ObservableCollection<Wish> MyWishCollection 
        {
            get { return MywishCollection; }
            set { MywishCollection = value; OnPropertyChanged(); }
        }

        public Wish SelectedWish
        {
            get { return selectedWish; }
            set { selectedWish = value; OnPropertyChanged(); }
        }

       

        /* 
          Display in a new page the details about the given wish selected by the user
        */
        private void DisplayAWish()
        {
            if (selectedWish != null)
            {
                // Sending the properties to the DetailsViewModel and pushing it to the bindingcontext on the "details" Page
                var viewModel = new DetailsViewModel { SelectedWish = selectedWish, Wishes = MyWishCollection, Position = MyWishCollection.IndexOf(selectedWish) };
                var detailsPage = new DetailsPage();
                detailsPage.BindingContext = viewModel;

                // navigate to the details page
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);

                selectedWish = null;
            }
        }


        /*
           Everytime that the landingPage is at the top of the view stack -> RELOAD with this information 
        */

        public async void RefeshDataForCollectionOfWhises()
        {
            // Refresh the collectionView
            mv.GetAllDataFromDB();

            Console.WriteLine("i am outside");

            // empty the collection 
            //WishCollection.Clear();

            // Repopulate the WishCollection
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
            PopupNavigation.Instance.PushAsync(new Modal());
        }
    }
}







/*

 private ObservableCollection<Wish> wishes;

 wishes = GetWishes();



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

        // ObservableCollection
        WishCollection = new ObservableCollection<Wish>() ;
        WishCollection.CollectionChanged += WishCollection_CollectionChanged;
            
         // EventHandler that tracks when a new item is added in the observableCollection
        private void WishCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < WishCollection.Count; i++)
            {
                Console.WriteLine(i);
            }
            {
                // Identify that an object is added
                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                        Console.WriteLine("{0}: {1}", e.Action, item);
                        Console.WriteLine("{0}: {1}", e.Action, e.NewItems, e.NewStartingIndex);
                    {
                    }
                }
            }
        } 
 
 */