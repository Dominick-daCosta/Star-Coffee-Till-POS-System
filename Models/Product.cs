namespace Starbucks_POS.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } // e.g., "Espresso", "Iced Tea", "Cold Foam"
}