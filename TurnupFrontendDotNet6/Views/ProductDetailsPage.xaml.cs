using CommunityToolkit.Mvvm.ComponentModel;
using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.ViewModels;

namespace TurnupFrontendDotNet6.Views;


public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel productDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = productDetailsViewModel; 
	}

	
}
