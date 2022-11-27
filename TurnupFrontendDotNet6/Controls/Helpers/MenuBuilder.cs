namespace TurnupFrontendDotNet6.Controls.Helpers;

public static class MenuBuilder
{
    public static void BuildMenu()
    {
        Shell.Current.Items.Clear();
        Shell.Current.FlyoutHeader = new FlyoutHeader();

        var role = App.AppUserInfo.Role;

        if (role.Equals("customer"))
        {
            var flyoutItem = new FlyoutItem()
            {
                Title = "Main Page Customer",
                Route = nameof(MainPage),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    new ShellContent
                    {
                        Icon = "menu.png",
                        Title = "Scan",
                        ContentTemplate = new DataTemplate(typeof(ScanPage))
                    },
                    new ShellContent
                    {
                        Icon = "tray.png",
                        Title = "Orders",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    },
                    new ShellContent()
                    {
                        Icon = "login.png",
                        Title = "Account Settings",
                        ContentTemplate = new DataTemplate(typeof(UserSettingsPage))
                    }
                }
            };
            if (!Shell.Current.Items.Contains(flyoutItem))
            {
                Shell.Current.Items.Add(flyoutItem);
            }
        }

        if (role.Equals("establishment"))
        {
            var flyoutItem = new FlyoutItem()
            {
                Title = "Main Page Establishment",
                Route = nameof(MainPage),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    new ShellContent()
                    {
                        Icon = "menu.png",
                        Title = "Home",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    },
                    new ShellContent()
                    {
                        Icon = "take_away.png",
                        Title = "Pending Orders",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    }
                }
            };
            if (!Shell.Current.Items.Contains(flyoutItem))
            {
                Shell.Current.Items.Add(flyoutItem);
            }
        }


        var commonFlyoutItems = new FlyoutItem()
        {
            Title = "login",
            Route = nameof(LoginPage),
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items =
            {
                new ShellContent()
                {
                    Icon = "login.png",
                    Title = "Logout",
                    ContentTemplate = new DataTemplate(typeof(LogoutPage))
                }
            }
        };
        if (!Shell.Current.Items.Contains(commonFlyoutItems))
        {
            Shell.Current.Items.Add(commonFlyoutItems);
        }
    }
}