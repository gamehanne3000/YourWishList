using System;
namespace yourWishList.Models
{
    public class Wish
    {
        public Guid WishId { get; set; } // Some cool key for each wish
        public string Image { get; set; } // { Display an image} => optional -> otherwise a default image
        public string Name { get; set; } // Playstation 5
        public string Price { get; set; } // 4 500 kr
        public string Url { get; set; } // www.happy.com
        public string Description { get; set; } // Some good text here :)
    }
}
