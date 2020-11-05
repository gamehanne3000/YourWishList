using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace yourWishList.ViewModels
{
    // This class handles the changes in the logic and corresponds with the frontend, aka.. what is shown to the user
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
