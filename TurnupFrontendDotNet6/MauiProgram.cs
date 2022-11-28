
using TurnupFrontendDotNet6.Models;
using ZXing.Net.Maui;
using TurnupFrontendDotNet6.ViewModels;
using TurnupFrontendDotNet6.Services;
using TurnupFrontendDotNet6.Views;


namespace TurnupFrontendDotNet6;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Pages
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddTransient<EstablishmentPage>();
		builder.Services.AddTransient<ProductDetailsPage>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<LogoutPage>();
		builder.Services.AddSingleton<RegistrationPage>();
		builder.Services.AddSingleton<ScanPage>();
		builder.Services.AddTransient<CartPage>();
		
		
		
		
		// Services
		builder.Services.AddSingleton<TurnupApiService>();
		builder.Services.AddSingleton<ProductService>();
		
		// ViewModels
		builder.Services.AddSingleton<ProductViewModel>();
		// Transient is a new instance every page visit
		builder.Services.AddTransient<ProductDetailsViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<LogoutViewModel>();
		builder.Services.AddSingleton<RegistrationViewModel>();
		builder.Services.AddSingleton<ScanPageViewModel>();
		builder.Services.AddScoped<CartViewModel>();
		
		
		
		
		
		

        return builder.Build();
	}
}

