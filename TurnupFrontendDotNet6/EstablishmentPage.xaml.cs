using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.ViewModels;
using TurnupFrontendDotNet6.Views;

namespace TurnupFrontendDotNet6;

public partial class EstablishmentPage : ContentPage
{
	public EstablishmentPage(ProductViewModel productViewModel)
	{
		InitializeComponent();
		BindingContext = productViewModel;
		
    }

	private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	{
		var product = ((VisualElement)sender).BindingContext as Product;
		if (product is null) return;
		
		await Shell.Current.GoToAsync(nameof(ProductDetailsPage), true, new Dictionary<string, object>
		{
		    {"Product", product }
		});
	}
}
