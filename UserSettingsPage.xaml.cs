using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupFrontendDotNet6;

public partial class UserSettingsPage : ContentPage
{
    public UserSettingsPage()
    {
        InitializeComponent();
        SetValues();
    }
    
    private void SetValues()
    {
        if (App.AppUserInfo is not null)
        {
            lblName.Text = App.AppUserInfo.Name;
            lblRole.Text = App.AppUserInfo.Role;
            lblEmail.Text = App.AppUserInfo.Email;
        }
    }
}