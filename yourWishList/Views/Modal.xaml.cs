using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Pages;
using yourWishList.Models;
using yourWishList.ViewModels;

namespace yourWishList.Views
{
    public partial class Modal : PopupPage
    {
        public Modal(ObservableCollection<Wish> myWishCollection)
        {
            InitializeComponent();
            ((ModalViewModel) BindingContext).Collection = myWishCollection;
        }
    }
}
