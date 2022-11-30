using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using TurnupFrontendDotNet6.Models;
using JsonArray = System.Text.Json.Nodes.JsonArray;

namespace TurnupFrontendDotNet6.Services;

public class TurnupApiService
{
    private HttpClient _httpClient;

    public static string BaseAddress = "http://192.168.50.12:8011";
    // public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
    //     ? "http://192.168.50.12:8011"
    //     : "http://localhost:8011";

    public string StatusMessage;

    public TurnupApiService()
    {
        _httpClient = new() { BaseAddress = new Uri(BaseAddress) };
    }

    public async Task<ObservableCollection<Product>> GetProducts(ScanModel scanModel)
    {
        try
        {
            var response = await _httpClient
                .GetStringAsync("/api/Scan?establishmentCode=" + scanModel.EstablishmentGuid).ConfigureAwait(false);
            var products = JsonArray.Parse(response);
            return JsonConvert.DeserializeObject<ObservableCollection<Product>>(products.ToString());
        }
        catch (Exception e)
        {
            StatusMessage = "Failed to retrieve products!";
            return default;
        }
    }

    public async Task<Establishment> GetEstablishment(string establishmentId)
    {
        var response = await _httpClient.GetStringAsync("api/product/establishment?establishmentId=" + establishmentId)
            .ConfigureAwait(false);
        return JsonConvert.DeserializeObject<Establishment>(response);
    }

    public async Task<AuthResponseModel> Register(RegistrationModel registrationModel)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Authentication/Register?role=1", registrationModel);
            response.EnsureSuccessStatusCode();
            StatusMessage = "Registration Successful";
            return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception)
        {
            StatusMessage = "Failed to login successfully";
            return default;
        }
    }

    public async Task<AuthResponseModel> Login(LoginModel loginModel)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Authentication/login", loginModel);
            response.EnsureSuccessStatusCode();
            StatusMessage = "Login successful";
            return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception)
        {
            StatusMessage = "Failed to login successfully";
            return default;
        }
    }

    public async Task SetAuthToken()
    {
        var token = await SecureStorage.GetAsync("token").ConfigureAwait(false);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<Cart> GetCart()
    {
        await SetAuthToken().ConfigureAwait(false);
        try
        {
            var establishmentId = await SecureStorage.GetAsync("EstablishmentId");
            var response = await _httpClient.GetStringAsync("/api/cart?establishmentId=" + establishmentId)
                .ConfigureAwait(false);
            if (response.Contains("id\":0")) // No items in cart response => {"id":0,"customerId":null,"items":null,"subtotal":0,"establishmentId":null}
            {
                StatusMessage = "Failed to successfully retrieve cart";
                
            }
            var cart = JsonArray.Parse(response);
            
            return JsonConvert.DeserializeObject<Cart>(cart.ToString());
        }
        catch (Exception)
        {
            StatusMessage = "Failed to successfully retrieve cart";
            return default;
        }
    }

    public async Task<CartResponse> AddToCart(Product product, UpdateCartModel model)
    {
        var cartResponse = new CartResponse();

        try
        {
            await SetAuthToken().ConfigureAwait(false);
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post,
                $"/api/Cart/add-items?productId={model.ProductId}&quantity={model.Quantity}"));
            response.EnsureSuccessStatusCode();

            cartResponse.IsAdded = true;
            return cartResponse;
        }
        catch (Exception e)
        {
            return default;
        }
    }

    public async Task<CartResponse> RemoveFromCart(Product product, UpdateCartModel model)
    {
        throw new NotImplementedException();    
    }

    public async Task<OrderResponse> PlaceOrder()
    {
        var order = new OrderResponse();
        try
        {
            order.IsOrderPlaced = false;
            await SetAuthToken().ConfigureAwait(false);
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get,
                "/api/Order/place-order"));
            response.EnsureSuccessStatusCode();
            order.IsOrderPlaced = true;
            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}