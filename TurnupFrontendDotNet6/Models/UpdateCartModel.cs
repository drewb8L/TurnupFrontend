namespace TurnupFrontendDotNet6.Models;

public class UpdateCartModel
{
    public UpdateCartModel()
    {
        
    }

    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}