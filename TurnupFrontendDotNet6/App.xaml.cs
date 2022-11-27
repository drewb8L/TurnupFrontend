using TurnupFrontendDotNet6.Models;
using TurnupFrontendDotNet6.Services;

namespace TurnupFrontendDotNet6;

public partial class  App : Application
{
	public static AppUserInfo AppUserInfo;
	public TurnupApiService ApiService { get; private set; }
	public App(TurnupApiService turnupApiService)
	{
       
        InitializeComponent();
        MainPage = new AppShell();
        ApiService = turnupApiService;
		

	}
}

