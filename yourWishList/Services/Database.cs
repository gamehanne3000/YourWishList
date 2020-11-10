using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using yourWishList.Models;

namespace yourWishList.Services
{
    public class Database
    {
        public Database()
        {
        }

        public static IEnumerable<Wish> Get()
        {
            return new ObservableCollection<Wish>
            {
                new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
                new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
                new Wish { Name = "Skärm", Price = 4490f, Image = "display.png", Description = "Xiaomi Mi 34 curved gaming monitor"},
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
