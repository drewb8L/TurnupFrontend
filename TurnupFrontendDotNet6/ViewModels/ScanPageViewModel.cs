using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;

namespace TurnupFrontendDotNet6.ViewModels;

public partial class ScanPageViewModel : BaseViewModel
{
    public ScanPageViewModel(ProductViewModel productViewModel)
    {
        this._productViewModel = productViewModel;
    }

    

    [ObservableProperty] 
    private string establishmentCode;

    private ProductViewModel _productViewModel;

    [RelayCommand]
    async Task GetProducts()
    {

        var scanModel = new ScanModel(establishmentCode);
        
        await _productViewModel.GetProducts(scanModel);

        await Shell.Current.GoToAsync(nameof(EstablishmentPage));

    }

}