using System;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using TurnupFrontendDotNet6.Controls.Helpers;
using TurnupFrontendDotNet6.Models;

namespace TurnupFrontendDotNet6.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        public LoadingPageViewModel()
        {
            AuthorizeLogin();
        }

        private async void AuthorizeLogin()
        {
            var token = await SecureStorage.GetAsync("token");

            if (string.IsNullOrEmpty(token))
            {
                await GoToLoginPage();
            }
            else
            {
                var Jwtoken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                if (Jwtoken.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove("token");
                    await Shell.Current.DisplayAlert("Token Expired", "Please login again.", "Ok");
                    await GoToLoginPage();
                }
                else
                {
                    var name = Jwtoken.Claims.FirstOrDefault(q => q.Type.Equals("Name"))?.Value;
                    var role = Jwtoken.Claims.FirstOrDefault(q => q.Type.Equals("Role"))?.Value;
                    var email = Jwtoken.Claims.FirstOrDefault(q => q.Type.Equals("email"))?.Value;
                    var userId = Jwtoken.Claims.FirstOrDefault()?.Value;
                    App.AppUserInfo = new AppUserInfo()
                    {
                        Name = name,
                        Email = email,
                        Role = role,
                        UserId = userId
                    };
                    MenuBuilder.BuildMenu();
                    await GoToMainPage();
                }
            }
        }

            
        // Change to register page
        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }


        private async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}