using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupFrontendDotNet6.Controls;

public partial class FlyoutHeader : StackLayout
{
    public FlyoutHeader() 
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
        }
    }
}