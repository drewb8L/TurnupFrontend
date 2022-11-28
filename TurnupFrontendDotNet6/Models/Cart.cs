using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TurnupFrontendDotNet6.Models;


public class Cart : ObservableObject
{
    public int Id { get; set; }
    public string CustomerId { get; set; }

    public List<CartItems>? Items { get; set; } = new();
    public decimal Subtotal { get; set; }
    public string EstablishmentId { get; set; }
}

// [ObservableObject]