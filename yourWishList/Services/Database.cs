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
                    WishId = item.Object.WishId,
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

        // Read
        public async Task<Wish> GetWish(Guid wishId)
        {
            {
                var wish = await GetAllWhises();
                await Firebase
                .Child("Wishes")
                .OnceAsync<Wish>();
                return wish.Where(a => a.WishId == wishId).FirstOrDefault();
            }
        }

        // Insert a wish
        public async Task AddWish(Guid wishId, string name, int price, string image, string url, string description)
        {
            try
            {
                await firebase
                .Child("Wishes")
                .PostAsync(new Wish() { WishId = wishId, Name = name, Price = price, Image = image, Url = url, Description = description });
            }
            catch (Exception e)
            {
                Console.WriteLine($" INSERT -> Error:{e}");
            }
        }


        // Update 
        public async Task UpdateWish(Guid wishId, string name, int price, string image, string url, string description)
        {
            try
            {
                var toUpdateWish = (await firebase
                .Child("Wishes")
                .OnceAsync<Wish>()).Where(a => a.Object.WishId == wishId).FirstOrDefault();

                await firebase
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
        public async Task DeleteWish(Guid wishId)
        {
            try
            {
                var toDeletWish = (await firebase
                .Child("Whises")
                .OnceAsync<Wish>()).Where(a => a.Object.WishId == wishId).FirstOrDefault();
                await firebase.Child("Wishes").Child(toDeletWish.Key).DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($" DELETE -> Error:{e}");
            }
        }
    }
}


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

