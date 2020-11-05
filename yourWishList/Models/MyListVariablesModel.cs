using System;
namespace yourWishList.Models
{
    public class MylistVariablesModel
    {
        public string Image { get; set; } // { Display an image} => optional -> otherwise a default image
        public string Name { get; set; } // Playstation 5
        public float Price { get; set; } // 4 500 kr
        public string Description { get; set; } // Some good text here :)


        //public string NameOfListItem      { get; set; }   // Playstation 5
        //public string PriceOfListItem     { get; set; }   // 4 500 kr

        //public string Title               { get; set; }   // My birthday 2020 !
        //public string AuthorForGeneral    { get; set; }   // by Johannes Ryberg
        //public string DateForGeneral      { get; set; }   // 16 Juli

        //public string ImageForDetail      { get; set; }   // { Displayed image} => optional
        //public string DesciptionForDetail { get; set; }   // Some good text here :)
        //public bool   AcceptForDetail     { get; set; }   // { this is a checkbox } -> true or false
        //public string LinkForDetail       { get; set; }   // www.playstation5.com
    }

}
