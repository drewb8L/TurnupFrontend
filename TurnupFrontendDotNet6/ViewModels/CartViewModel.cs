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
    private decimal subtotal;
    

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

            SetProperties();

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
    }

    private void SetProperties()
    {
        subtotal = Cart.Subtotal;
    }
}