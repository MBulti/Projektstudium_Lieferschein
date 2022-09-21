using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace App_Lieferschein.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        #region Declaration
        private ILoginService iLoginService;
        #endregion

        #region Properties
        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;
        #endregion

        public LoginViewModel(ILoginService loginService)
        {
            iLoginService = loginService;
        }

        #region Commands
        [RelayCommand]
        async void Login()
        {
            if (await iLoginService.Login(UserName, Password))
            {
                var userInfo = new UserInfoModel();
                userInfo.UserName = UserName;
                userInfo.Enviroment = "PROD";

                if (Preferences.ContainsKey(nameof(App.GlobalSettings.UserInfo)))
                    Preferences.Remove(nameof(App.GlobalSettings.UserInfo));

                Preferences.Set(nameof(App.GlobalSettings.UserInfo), JsonConvert.SerializeObject(userInfo));
                App.GlobalSettings.UserInfo = userInfo;

                await Shell.Current.GoToAsync($"//{nameof(MainView)}", false, new Dictionary<string, object>()
                {
                    {
                        ParameterKeys.USERNAME, userInfo.UserName
                    }
                });
            }
        }
        #endregion
    }
}
