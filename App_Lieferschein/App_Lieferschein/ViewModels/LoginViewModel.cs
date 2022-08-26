using Newtonsoft.Json;

namespace App_Lieferschein.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        #region Commands
        [RelayCommand]
        async void Login()
        {
            var userDetails = new UserInfoModel();
            userDetails.UserName = "Test";
            userDetails.Enviroment = "PROD";

            if (Preferences.ContainsKey(nameof(App.GlobalSettings.UserInfo)))
                Preferences.Remove(nameof(App.GlobalSettings.UserInfo));

            Preferences.Set(nameof(App.GlobalSettings.UserInfo), JsonConvert.SerializeObject(userDetails));
            App.GlobalSettings.UserInfo = userDetails;

            await Shell.Current.GoToAsync($"//{nameof(MainView)}");
        }
        #endregion
    }
}
