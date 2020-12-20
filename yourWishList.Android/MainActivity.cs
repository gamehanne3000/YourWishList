using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using yourWishList.ViewModels;

namespace yourWishList.Droid
{
    [Activity(Label = "yourWishList", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        LandingpageViewModel landPage = new LandingpageViewModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // I)mplementation Rg.Plugins for Android
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                Console.WriteLine("Android back button: There are some pages in the PopupStack");
            }
            else
            {
                Console.WriteLine("Android back button: There are not any pages in the PopupStack");
            }
        }

        // Before Activity A is destroyed, Android automatically calls OnSaveInstanceState and passes in a Bundle that we can use to store our instance state
        protected override void OnSaveInstanceState(Bundle outState)
        {

            
            if (outState != null)
            {
            Console.WriteLine("state is saved");
            landPage.RefeshDataForCollectionOfWhises();
            }



            // always call the base implementation!
            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            Console.WriteLine("state is reloaded");
            base.OnRestoreInstanceState(savedInstanceState);
        }

    }
}