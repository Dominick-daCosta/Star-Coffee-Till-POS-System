using System.ComponentModel.DataAnnotations;

namespace Starbucks_POS.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

// Sets up the JSON reader so that it will separate drinks based on item type
[JsonPolymorphic(TypeDiscriminatorPropertyName = "ItemType")]
[JsonDerivedType(typeof(Drink), typeDiscriminator: "Permanent")]
[JsonDerivedType(typeof(LmtdDrink), typeDiscriminator: "Limited")]

[Table("Drinks")] // Makes a table in the database just for drinks
public class Drink : Product
{
    [MaxLength(50)]
    public required string DrinkCategory { get; init; }
    
    
    public Drink() { ItemCategory = "Drink"; }



}