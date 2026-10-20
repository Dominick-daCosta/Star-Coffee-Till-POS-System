using System.ComponentModel.DataAnnotations;

namespace Starbucks_POS.Models;

public class Product
{
    public int Id { get; init; }
    
    [MaxLength(50)]
    public string ItemCategory { get; init; } = "";
    [MaxLength(100)]
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    [MaxLength(100)]
    public required string TextBlockName { get; init; }
    [MaxLength(7)]
    public required string HexCode { get; init; }
}