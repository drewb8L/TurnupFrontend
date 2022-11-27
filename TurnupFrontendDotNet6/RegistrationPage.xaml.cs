using TurnupFrontendDotNet6.ViewModels;

namespace TurnupFrontendDotNet6;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel registrationViewModel)
	{
		InitializeComponent();
		BindingContext = registrationViewModel;
	}
}
