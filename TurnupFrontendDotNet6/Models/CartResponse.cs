namespace TurnupFrontendDotNet6.Models;

public class CartResponse
{
    public string ProductName { get; set; }
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public decimal Subtotal { get; set; }
    public bool IsAdded { get; set; }

    public bool IsDeleted { get; set; }
}