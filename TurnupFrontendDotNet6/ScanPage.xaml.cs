using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;
using TurnupFrontendDotNet6.ViewModels;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace TurnupFrontendDotNet6;

public partial class ScanPage : ContentPage
{
    
	public ScanPage(ScanPageViewModel scanPageViewModel)
	{
        InitializeComponent();
        BindingContext = scanPageViewModel;
        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false,
        };
    }

    

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
         Dispatcher.Dispatch(() =>
         {

             EstablishmentCode.Text = e.Results[0].Value;


         });
    }
}
