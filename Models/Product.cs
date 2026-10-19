namespace Starbucks_POS.Models;

public class Product
{
    public int Id { get; set; }
    public required string ItemCategory { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required string TextBlockName { get; set; }
    public required string HexCode { get; set; }
}