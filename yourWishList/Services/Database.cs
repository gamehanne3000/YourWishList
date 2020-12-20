using System;
using System.Collections.Generic;
using System.Linq;
using yourWishList.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace yourWishList.Services
{
    public class Database
    {
        // Connection with Firebase
        FirebaseClient Firebase = new FirebaseClient("https://wishlist-cfb5f.firebaseio.com/");

        public Database()
        {

        }

        //Read All  
        public async Task<IEnumerable<Wish>> GetAllWhises()
        {
            try
            {
                return (await Firebase
                .Child("Whises")
                .OnceAsync<Wish>()).Select(item =>
                new Wish
                {
                    Name = item.Object.Name,
                    Price = item.Object.Price,
                    Image = item.Object.Image,
                    Url = item.Object.Url,
                    Description = item.Object.Description,

                }).ToList();
            }    
            catch(Exception e)    
            {    
                Console.WriteLine($" READ ALL -> Error:{e}");    
                return null;    
            }
        }

        // Insert a wish
        public async Task<bool> AddWish(string name, string price, string image, string url, string description)
        {
            try
            {
                await Firebase
                .Child("Wishes")
                .PostAsync(new Wish() { Name = name, Price = price, Image = image, Url = url, Description = description });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($" INSERT -> Error:{e}");
                return false;
            }
        } 
    }
}






/*

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














/* SAVE
 
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
*/

