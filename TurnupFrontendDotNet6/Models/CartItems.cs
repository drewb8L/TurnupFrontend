namespace TurnupFrontendDotNet6.Models;

public class CartItems
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImgUrl { get; set; }
    public int Quantity { get; set; }
}