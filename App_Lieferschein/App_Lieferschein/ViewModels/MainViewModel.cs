using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }

        #region Commands
        [RelayCommand]
        async void Signout()
        {

            if (Preferences.ContainsKey(nameof(App.GlobalSettings.UserInfo)))
                Preferences.Remove(nameof(App.GlobalSettings.UserInfo));

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }
        #endregion
    }
}
