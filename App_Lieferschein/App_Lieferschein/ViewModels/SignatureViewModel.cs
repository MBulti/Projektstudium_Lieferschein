using CommunityToolkit.Maui.Views;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using App_Lieferschein.DependencyServices;
using Size = Microsoft.Maui.Graphics.Size;
using Syncfusion.Pdf.Parsing;

namespace App_Lieferschein.ViewModels
{
    [QueryProperty(nameof(DeliveryNote), ParameterKeys.DELIVERYNOTE)]
    public partial class SignatureViewModel : BaseViewModel
    {
        #region Declaration
        private IDataService iDataService;
        #endregion

        #region Properties
        [ObservableProperty]
        ObservableCollection<IDrawingLine> lines = new();

        [ObservableProperty]
        string deliveryNote;
        #endregion

        #region Public
        public SignatureViewModel(IDataService dataService)
        {
            iDataService = dataService;
        }
        #endregion

        #region Commands
        [RelayCommand]
        void ClearSignature()
        {
            Lines.Clear();
        }
        [RelayCommand]
        async void AddSignatureToPDF()
        {
            var stream = await DrawingView.GetImageStream(lines, new Size(500, 200), Colors.White);
            
            PdfLoadedDocument document = new PdfLoadedDocument(await iDataService.GetPDFStream(DeliveryNote));
            document.Pages[0].Graphics.DrawImage(new PdfBitmap(stream), new RectangleF(150, 400, 90, 30));

            using MemoryStream memoryStream = new();
            document.Save(memoryStream);
            document.Close();
            SaveService saveService = new();
            saveService.SaveAndView("Test.pdf", "application/pdf", memoryStream);
        }
        #endregion
    }
}
