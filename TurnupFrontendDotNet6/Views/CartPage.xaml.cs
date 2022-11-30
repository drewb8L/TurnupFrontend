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

    private int quantity;
    

    private void Stepper_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        quantity = Convert.ToInt32(value);
        
    }


    private void Button_OnClicked(object sender, EventArgs e)
    {
        // quantity value check
        var data = ((VisualElement)sender).BindingContext as CartViewModel;
        
    }

    private void OrderButton_OnClicked(object sender, EventArgs e)
    {
        
    }
}