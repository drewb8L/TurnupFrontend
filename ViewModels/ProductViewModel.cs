using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TurnupFrontendDotNet6.Services;
using TurnupFrontendDotNet6.Models;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TurnupFrontendDotNet6.Views;

namespace TurnupFrontendDotNet6.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {
        private readonly ProductService _productService;
        private readonly TurnupApiService _turnupApiService;
        
        public ObservableCollection<Product> Products { get; private set; } = new();
        public ObservableObject Establishment { get; set; } = new Establishment();
        
        public ProductViewModel(TurnupApiService turnupApiService)
        {
            Title = "Products";
            _turnupApiService = turnupApiService;
            
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        private string establishmentCode;

        [ObservableProperty] 
        private string establishmentName;
        
        [ObservableProperty] 
        private string establishmentId;

        [ObservableProperty] 
        private string description;  
        
        [ObservableProperty] 
        private string logoUrl;  
        
        [ObservableProperty] 
        private string jumbotronImgUrl;  
        
        


        [RelayCommand]
        public async Task GetProducts(ScanModel scanModel)
        {
            //var scanModel = new ScanModel(establishmentCode);
            
            if (Isloading)
                return;
            try
            {
                Isloading = true;
                if (Products.Any())
                {
                    Products.Clear();
                    establishmentName = "";
                    establishmentId = "";
                    jumbotronImgUrl = "";
                    logoUrl = "";
                    description = "";
                }

                var products = _turnupApiService.GetProducts(scanModel);
                foreach (var product in products.Result)
                {
                    
                    Products.Add(product);
                }

                establishmentId = products.Result.FirstOrDefault().EstablishmentId;
                await GetEstablishmentDetails();

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get products: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrieve list of products", "OK");
            }
            finally
            {             
                Isloading = false;
                IsRefreshing = false;
            }


        }

        [RelayCommand]
        async Task GetProductDetails(Product product)
        {
            if (product ==null) return;

            await Shell.Current.GoToAsync(nameof(ProductDetailsPage), true, new Dictionary<string, object>
            {
                {nameof(Product), nameof(product) }
            });
        }

        [RelayCommand]
        async Task GetEstablishmentDetails()
        {
           var establishment = await _turnupApiService.GetEstablishment(establishmentId);
           establishmentName = establishment.Name;
           description = establishment.Description;
           logoUrl = establishment.LogoUrl;
          jumbotronImgUrl = establishment.JumbotronImgUrl;

        }
    }
}

