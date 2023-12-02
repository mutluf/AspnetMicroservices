﻿namespace Shopping.RazorWebApp.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
