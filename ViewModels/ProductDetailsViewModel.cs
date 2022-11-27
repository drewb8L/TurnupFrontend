using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TurnupFrontendDotNet6.Models;
namespace TurnupFrontendDotNet6.ViewModels
{
    [QueryProperty(nameof(Product), nameof(_product))]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
	    [ObservableProperty] 
        private Product _product;

        


    }
}

