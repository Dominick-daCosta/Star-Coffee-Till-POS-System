namespace Starbucks_POS.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("LmtdDrinks")] // Makes a table in the database just for limited time drinks

public class LmtdDrink : Drink
{
    public required DateOnly Launch { get; init; }
    public required DateOnly Removal { get; init; }

    public Boolean Available // Re calculated every time
    {
        get
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
            return today >= Launch && today <= Removal;
        }
    }
    
        
    
    public LmtdDrink()
    {
        ItemCategory = "LmtdDrink";
    }
}