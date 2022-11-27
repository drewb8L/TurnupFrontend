using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurnupFrontendDotNet6.Controls.Helpers;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;
using Debug = System.Diagnostics.Debug;

namespace TurnupFrontendDotNet6.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
   
   private const string InvalidLogin = "Invalid Login Attempt!";
   public LoginViewModel(TurnupApiService turnupApiService)
   {
      this.turnupApiService = turnupApiService;
   }
   [ObservableProperty] 
   string email;
   [ObservableProperty] 
   string password;
   private TurnupApiService turnupApiService;
   
   

   [RelayCommand]
   async Task Login()
   {
      if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
      {
        await LoginMessage("Invalid Login Attempt!");
      }
      else
      {
         var loginModel = new LoginModel(email, password);
         var response = await turnupApiService.Login(loginModel);
         await LoginMessage(turnupApiService.StatusMessage);
         
         if (!string.IsNullOrEmpty(response?.Token))
         {
            await SecureStorage.SetAsync("token", response.Token);
            var token = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;
            var name = token.Claims.FirstOrDefault(q => q.Type.Equals("Name"))?.Value;
            var role = token.Claims.FirstOrDefault(q => q.Type.Equals("Role"))?.Value;
            var userId = token.Claims.FirstOrDefault()?.Value;
            App.AppUserInfo = new AppUserInfo()
            {
               Name = name,
               Email = email,
               Role = role,
               UserId = userId
            };
            

           
            MenuBuilder.BuildMenu();
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
         }
         else
         {
            await LoginMessage(InvalidLogin);
            password = string.Empty;
            Shell.Current.GoToAsync(nameof(LoginPage));

         }
         
      }
   }

   async Task LoginMessage(string msg)
   {
      await Shell.Current.DisplayAlert("Login Attempt Result",msg, "OK");
      password = string.Empty;
   }
}