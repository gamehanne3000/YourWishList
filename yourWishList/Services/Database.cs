using System;
using System.Collections.Generic;
using System.Linq;
using yourWishList.Models;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace yourWishList.Services
{
    public class Database
    {
        // Connection with Firebase
        FirebaseClient Firebase = new FirebaseClient("https://wishlist-cfb5f.firebaseio.com/");

        public Database()
        {
           
        }

        static readonly List<Wish> wishes = new List<Wish>();

        //Read All  
        public async Task<IEnumerable<Wish>> GetAllWhises()
        {
            try
            {
                return wishes;
            }
            catch (Exception e)
            {
                Console.WriteLine($" READ ALL -> Error:{e}");
                return null;
            }
        }

        // Insert a wish
        public async Task AddWish(string name, string price, string image, string url, string description)
        {
            try
            {
                await Firebase
                .Child("Wishes")
                .PostAsync(new Wish() { Name = name, Price = price, Image = image, Url = url, Description = description });
            }
            catch (Exception e)
            {
                Console.WriteLine($" INSERT -> Error:{e}");
            }
        }
    }
}
