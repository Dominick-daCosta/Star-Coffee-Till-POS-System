namespace Starbucks_POS.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

[Table("LmtdDrinks")] // Makes a table in the database just for limited time drinks

public class LmtdDrink : Drink
{
    public required DateOnly Launch { get; set; }
    public required DateOnly Removal { get; set; }

    public Boolean Available // Re calculated every time
    {
        get
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
            return today >= Launch && today <= Removal;
        }
    }
    
        
    [SetsRequiredMembers]
    public LmtdDrink()
    {
        ItemCategory = "LmtdDrink";
    }
}