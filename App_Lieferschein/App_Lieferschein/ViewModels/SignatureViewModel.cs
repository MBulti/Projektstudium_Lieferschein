using App_Lieferschein.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.ViewModels
{
    [QueryProperty(nameof(DeliveryNote), ParameterKeys.DELIVERYNOTE)]
    public partial class SignatureViewModel : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        ObservableCollection<IDrawingLine> lines = new();

        [ObservableProperty]
        ImageSource imgSource = null;

        [ObservableProperty]
        string deliveryNote;
        #endregion

        #region Commands
        [RelayCommand]
        void ClearSignature()
        {
            Lines.Clear();
        }
        [RelayCommand]
        async void GetSignature()
        {
            var stream = await DrawingView.GetImageStream(lines, new Size(500, 200), Colors.White);
            ImgSource = ImageSource.FromStream(() => stream);
        }
        #endregion
    }
}
