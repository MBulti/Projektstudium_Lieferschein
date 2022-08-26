using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace App_Lieferschein.ViewModels
{
    [QueryProperty(nameof(DeliveryNote), ParameterKeys.DELIVERYNOTE)]
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }

        [ObservableProperty]
        string deliveryNote;

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
