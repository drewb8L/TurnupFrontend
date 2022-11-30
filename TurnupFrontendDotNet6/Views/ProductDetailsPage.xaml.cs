using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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


	private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	{
		var data = ((VisualElement)sender).BindingContext as ProductDetailsViewModel;

		data.AddProductToCart(data.Product);
	}
}
