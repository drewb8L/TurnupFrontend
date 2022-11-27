using System;
using TurnupFrontendDotNet6.Models;

namespace TurnupFrontendDotNet6.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                        Title = "Hotdog",
                        Description = "It's A Hotdog!",
                        ImageUrl = "http://img.io",
                        Price = 5.00m,
                        EstablishmentId = "abc=123"
                },
                new Product
                    {
                        Id = 2,
                        Title = "Hamburger",
                        Description = "It's A Hamburger!",
                        ImageUrl = "http://img.io",
                        Price = 7.00m,
                        EstablishmentId = "abc=123"
                    },
                new Product
                    {
                        Id = 3,
                        Title = "Stake Sandwich",
                        Description = "It's Pretty Sad.",
                        ImageUrl = "http://img.io",
                        Price = 4.00m,
                        EstablishmentId = "abc=123"
                    },
                new Product
                    {
                        Id = 4,
                        Title = "10pc Chikin Tendies",
                        Description = "These Birds Flock Together.",
                        ImageUrl = "http://img.io",
                        Price = 8.00m,
                        EstablishmentId = "abc=123"
                    },
                new Product
                    {
                        Id = 5,
                        Title = "Curly Fires",
                        Description = "Just like mom used to make, except we dont burn them!",
                        ImageUrl = "http://img.io",
                        Price = 3.00m,
                        EstablishmentId = "abc=123"
                    },
                new Product
                    {
                        Id = 6,
                        Title = "12 Can of Soda",
                        Description = "Why not wash it all down with sugar water!",
                        ImageUrl = "http://img.io",
                        Price = 8.00m,
                        EstablishmentId = "abc=123"
                    },
                new Product
                    {
                        Id = 7,
                        Title = "Key Lime Pie",
                        Description = "Would you trust pie from a burger truck, I wouldn't!",
                        ImageUrl = "http://img.io",
                        Price = 8.00m,
                        EstablishmentId = "abc=123"
                    }
            };

        }
    }
}

