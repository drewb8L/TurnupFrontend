using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TurnupFrontendDotNet6.Models;


namespace TurnupFrontendDotNet6.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
	    [ObservableProperty] 
        Product product;

    }
    
    
}

