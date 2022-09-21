using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Lieferschein.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace App_Lieferschein.ViewModels
{
    [QueryProperty(nameof(UserName), ParameterKeys.USERNAME)]
    public partial class MainViewModel : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        string userName;
        #endregion

        #region Public
        public MainViewModel()
        {
        }
        #endregion

        #region Commands
        [RelayCommand]
        async void Sign()
        {
            await Shell.Current.GoToAsync(nameof(SignatureView), true, new Dictionary<string, object>()
            {
                {
                    ParameterKeys.DELIVERYNOTE, "123456789"
                }
            });
        }
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
