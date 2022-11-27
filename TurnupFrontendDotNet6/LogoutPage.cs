using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupFrontendDotNet6.ViewModels;

namespace TurnupFrontendDotNet6;

public partial class LogoutPage : ContentPage
{
    public LogoutPage(LogoutViewModel logoutViewModel)
    {
        Content = new VerticalStackLayout()
        {
            Children =
            {
                new Label()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = "Logged Out"
                }
            }

        };

        BindingContext = logoutViewModel;
    }
}