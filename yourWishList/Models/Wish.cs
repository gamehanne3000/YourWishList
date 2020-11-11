using System;
namespace yourWishList.Models
{
    public class Wish
    {
        public string Image { get; set; } // { Display an image} => optional -> otherwise a default image
        public string Name { get; set; } // Playstation 5
        public float Price { get; set; } // 4 500 kr
        public float Url { get; set; } 
        public string Description { get; set; } // Some good text here :)
    }
}
