using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using yourWishList.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace yourWishList.Services
{
    public class Database
    {
        // Connection with Firebase
        FirebaseClient firebase = new FirebaseClient("https://wishlist-cfb5f.firebaseio.com/");

        public Database()
        {
        }

        public async Task<List<Wish>> GetAllWhises()
        {

            return (await firebase
              .Child("Whises")
              .OnceAsync<Wish>()).Select(item => new Wish
              {
                  Name = item.Object.Name,
                  Price = item.Object.Price,
                  Image = item.Object.Image,
                  Url = item.Object.Url,
                  Description = item.Object.Description,
              }).ToList();
        }








        public static IEnumerable<Wish> Get()
        {
            return new ObservableCollection<Wish>
            {
                new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
            };
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedWish)
        {
            var selectedWish = currentSelectedWish.FirstOrDefault() as Wish;
            Console.WriteLine("FullName: " + selectedWish.Name);
            Console.WriteLine("Email: " + selectedWish.Price);
            Console.WriteLine("Phone: " + selectedWish.Image);
            Console.WriteLine("Phone: " + selectedWish.Description);
        }
    }
}
