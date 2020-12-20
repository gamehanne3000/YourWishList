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
        public Database()
        {

        }

        static readonly List<Wish> wishes = new List<Wish>();

        //Read All  
        public async Task<IEnumerable<Wish>> GetAllWhises()
        {
            return wishes;
        }

        // Insert a wish
        public async Task<bool> AddWish(string name, string price, string image, string url, string description)
        {
            wishes.Add(new Wish() { Name = name, Price = price, Image = image, Url = url, Description = description });
            return true;
        }
    }
}







/*

    This is notes i am saving :)

    // Read
    public async Task<Wish> GetWish(string wishId)
    {
        {
            var wish = await GetAllWhises();
            await Firebase
            .Child("Wishes")
            .OnceAsync<Wish>();
            return wish.Where(a => a. == wishId).FirstOrDefault();
        }
    }

    // Update 
    public async Task UpdateWish(string wishId, string name, string price, string image, string url, string description)
    {
        try
        {
            var toUpdateWish = (await Firebase
            .Child("Wishes")
            .OnceAsync<Wish>()).Where(a => a.Object.WishId == wishId).FirstOrDefault();

            await Firebase
            .Child("Wishes")
            .Child(toUpdateWish.Key)
            .PutAsync(new Wish() { WishId = wishId, Name = name, Price = price, Image = image, Url = url, Description = description });
        }
        catch (Exception e)
        {
            Console.WriteLine($" UPDATE -> Error:{e}");
        }
    }

    // delete a wish
    public async Task DeleteWish(string wishId)
    {
        try
        {
            var toDeletWish = (await Firebase
            .Child("Whises")
            .OnceAsync<Wish>()).Where(a => a.Object.WishId == wishId).FirstOrDefault();
            await Firebase.Child("Wishes").Child(toDeletWish.Key).DeleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($" DELETE -> Error:{e}");
        }
    }

    // This is the way to get hold of the key
    public FirebaseObject<Wish> key { get; }
 
*/

