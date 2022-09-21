using Newtonsoft.Json;

namespace App_Lieferschein.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private ILoginService iLoginService;
        
        public LoginViewModel(ILoginService loginService)
        {
            iLoginService = loginService;
        }


        #region Commands
        [RelayCommand]
        async void Login()
        {
            if (await iLoginService.Login("Test", "123"))
            {
                var userDetails = new UserInfoModel();
                userDetails.UserName = "Test";
                userDetails.Enviroment = "PROD";

                if (Preferences.ContainsKey(nameof(App.GlobalSettings.UserInfo)))
                    Preferences.Remove(nameof(App.GlobalSettings.UserInfo));

                Preferences.Set(nameof(App.GlobalSettings.UserInfo), JsonConvert.SerializeObject(userDetails));
                App.GlobalSettings.UserInfo = userDetails;

                await Shell.Current.GoToAsync($"//{nameof(MainView)}", true, new Dictionary<string, object>()
                {
                    {
                        ParameterKeys.DELIVERYNOTE, iLoginService.ToString()
                    }
                });
            }
        }
        #endregion
    }
}
