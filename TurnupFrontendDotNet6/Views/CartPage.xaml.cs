using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.ViewModels;

namespace TurnupFrontendDotNet6.Views;

public partial class CartPage : ContentPage
{
    public CartPage(CartViewModel cartViewModel)
    {
        InitializeComponent();
        BindingContext = cartViewModel;
    }

   
}