using TurnupFrontendDotNet6.ViewModels;
namespace TurnupFrontendDotNet6;

public partial class EstablishmentPage : ContentPage
{
	public EstablishmentPage(ProductViewModel productViewModel)
	{
		InitializeComponent();
		BindingContext = productViewModel;

		//Saving data
  //      Preferences.Set("saveDetails", true);
		//var details = Preferences.Get("saveDetails", false);

		
    }
}
