using CommunityToolkit.Mvvm.Input;

namespace TurnupFrontendDotNet6.ViewModels;

public partial class LogoutViewModel : BaseViewModel
{
    public LogoutViewModel()
    {
        Logout();
    }

    [RelayCommand]
    async void Logout()
    {
        SecureStorage.Remove("token");
        App.AppUserInfo = null;
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}"); 
    }
}