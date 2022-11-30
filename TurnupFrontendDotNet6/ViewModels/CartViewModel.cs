using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;


namespace TurnupFrontendDotNet6.ViewModels;


public partial class CartViewModel : BaseViewModel
{
    private readonly TurnupApiService _turnupApiService;

    public ObservableCollection<CartItems> Items { get; set; } = new();
    public  Cart Cart { get; private set; } = new Cart();
    public CartViewModel(TurnupApiService turnupApiService)
    {
        Title = "Cart";
        _turnupApiService = turnupApiService;
    }


    [ObservableProperty]
    private string subtotal;

    
    

    [RelayCommand]
    public async Task GetCart()
    {
        if(Isloading) return;

        try
        {
            Isloading = true;
            var result = _turnupApiService.GetCart();
           
            await SetCartDetails(Cart, result);
            if (Items.Any())
            {
                Items.Clear();
            }
            foreach (var item in result.Result.Items)
            {
                Items.Add(item);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {             
            Isloading = false;
            
        }
    }

    private async Task SetCartDetails(Cart myCart, Task<Cart> c)
    {

        myCart.Id = c.Result.Id;
        myCart.EstablishmentId = c.Result.EstablishmentId;
        myCart.Subtotal = c.Result.Subtotal;
        myCart.CustomerId = c.Result.CustomerId;
        Subtotal = c.Result.Subtotal.ToString();
    }

   
    public async Task RemoveItem(Product product, double quantity)
    {
        var model = new UpdateCartModel()
        {
            ProductId = product.Id,
            Quantity = Convert.ToInt32(quantity),
        };
        
        var result = await _turnupApiService.RemoveFromCart(product,model );
        if (result.IsDeleted)
        {
            await Shell.Current.DisplayAlert($"{product.Title}", "Removed from cart", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert($"{product.Title}", "There was an issue removing this item", "Ok");
        }
        
    }

    [RelayCommand]
    public async Task PlaceOrder()
    {
        var order = await _turnupApiService.PlaceOrder();

        if (order.IsOrderPlaced)
        {
            await Shell.Current.DisplayAlert("Order Received", "Your order has been placed successfully", "Ok");
            Items.Clear();
        }
        else
        {
            await Shell.Current.DisplayAlert("Order error", "There was an issue placing this order", "Ok");
        }
        
        

    }
    
}