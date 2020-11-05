using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/*
    This for now is only something i can show and not beeing able to use yet because for lack of information in microsoft docs.
    PS: i know that this is the best way to go when using same images across the plattforms 
*/

namespace yourWishList.Images
{
    [ContentProperty(nameof(Source))]

    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            // If no image is to be found => show null = nothing
            if (Source == null)
            {
                return null;
            }

            // An object of my imbedded image using that resource ID
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}

//This was written in the XAML markup but did not work even if i followed the docs to 100%

//  ->  xmlns:local="clr-namespace:yourWishList;assembly=yourWishList"
// and
//  ->  <Image Source=" {local:ImageResource yourWishList.Images.search.png}"/>