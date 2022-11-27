using CommunityToolkit.Mvvm.ComponentModel;

namespace TurnupFrontendDotNet6.Models;

public class Establishment : ObservableObject
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string LogoUrl { get; set; }

    public string JumbotronImgUrl { get; set; }
}