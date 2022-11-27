namespace TurnupFrontendDotNet6.Models;

public class ScanModel
{
    public ScanModel(string establishmentGuid)
    {
        EstablishmentGuid = establishmentGuid;
    }
    public string EstablishmentGuid { get; set; }
}