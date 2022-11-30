using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;


namespace TurnupFrontendDotNet6.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
        private readonly TurnupApiService _turnupApi;
        public ProductDetailsViewModel(TurnupApiService turnupApiService)
        {
            
            this._turnupApi = turnupApiService;
        }
        
	    [ObservableProperty] 
        Product product;

        
        
        public async Task AddProductToCart(Product product)
        {
            var model = new UpdateCartModel()
            {
                ProductId = product.Id,
                Quantity = 1

            };
            
           var result = await _turnupApi.AddToCart(product,model );
           if (result.IsAdded)
           {
               await Shell.Current.DisplayAlert($"{product.Title}", "Added to cart", "Ok");
           }
           else
           {
               await Shell.Current.DisplayAlert($"{product.Title}", "There was an issue adding this item", "Ok");
           }

        }

    }
    
    
    
}

