using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;

namespace TurnupFrontendDotNet6.ViewModels;

public partial class RegistrationViewModel : BaseViewModel
{
    public RegistrationViewModel(TurnupApiService turnupApiService)
    {
        this._turnupApiService = turnupApiService;
    }

    private TurnupApiService _turnupApiService;

    [ObservableProperty] private string name;
    [ObservableProperty] private string email;
    [ObservableProperty] private string password;

    private const string RegistrationSuccess = "Registration Complete!";
    private const string RegistrationFail = "Registration Attempt Failed";

    [RelayCommand]
    async Task Register()
    {
        var registrationModel = new RegistrationModel(name, email, password);
        
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
        {
            await RegisterMessage(RegistrationFail);
        }

        var response = await _turnupApiService.Register(registrationModel);
        if (!string.IsNullOrWhiteSpace(response?.Token))
        {
            await RegisterMessage(RegistrationSuccess);
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
        
        else
        {
            await RegisterMessage(RegistrationFail);
        }
    }

    [RelayCommand]
    async Task NavigateToLogin()
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }
    
    async Task RegisterMessage(string msg)
    {
        await Shell.Current.DisplayAlert("Registration",msg, "OK");
        password = string.Empty;
    }
}