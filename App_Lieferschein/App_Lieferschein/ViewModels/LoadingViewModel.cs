using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.ViewModels
{
    public partial class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
            await Task.Delay(500);
            string userDetailsStr = Preferences.Get(nameof(App.GlobalSettings.UserInfo), "");

            if (string.IsNullOrWhiteSpace(userDetailsStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
            }
            else
            {
                Preferences.Remove(nameof(App.GlobalSettings.UserInfo));
                var userInfo = JsonConvert.DeserializeObject<UserInfoModel>(userDetailsStr);
                App.GlobalSettings.UserInfo = userInfo;
                await Shell.Current.GoToAsync($"//{nameof(MainView)}");
            }
        }
    }
}
