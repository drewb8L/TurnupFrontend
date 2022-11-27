using TurnupFrontendDotNet6.ViewModels;

namespace TurnupFrontendDotNet6.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel productDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = productDetailsViewModel;
	}

    
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		// Extra
		base.OnNavigatedTo(args);
	}
}
