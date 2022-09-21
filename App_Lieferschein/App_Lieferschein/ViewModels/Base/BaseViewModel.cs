using CommunityToolkit.Mvvm.ComponentModel;

namespace App_Lieferschein.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string title;

        public BaseViewModel()
        {

        }
    }
}
