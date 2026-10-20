using System.Collections.ObjectModel;
using System.Linq;
using Starbucks_POS.Models;

namespace Starbucks_POS.ViewModels;

public class CartViewModel
{
    public ObservableCollection<Product> CartItems { get; set; } = new();
    
    // Create lists for the UI to bind to
    
    public ObservableCollection<Drink> PermanentEspressoDrinks { get; set; } = new();
    
    public ObservableCollection<Drink> LimitedEspressoDrinks { get; set; } = new();
    public ObservableCollection<Drink> FrappuccinoDrinks { get; set; } = new();
    public ObservableCollection<Drink> BrewedDrinks { get; set; } = new();
    public ObservableCollection<Drink> TeaDrinks { get; set; } = new();
    public ObservableCollection<Drink> OtherDrinks { get; set; } = new();

    public CartViewModel()
    {
        LoadMenuFromDatabase();
    }

    private void LoadMenuFromDatabase()
    {
        using var context = new PosContext();
        
        var allDrinks = context.Drinks.ToList(); // All drinks from the database are added to a list
        
        
        // Fliter out Limited time drinks
        var availableDrinks = allDrinks.Where(drink =>
        {
            if (drink is LmtdDrink limitedDrink)
            {
                return limitedDrink.Available; // Only keep it if it's available today
            }
            return true; // Permanent drinks are always kept
        }).ToList();

        
        // Create a List for each type of drink
        
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Espresso"))
        {
            if (drink is LmtdDrink)
                LimitedEspressoDrinks.Add(drink);
            else
                PermanentEspressoDrinks.Add(drink);
        }
        
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Frappuccino"))
        {
            FrappuccinoDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Brewed"))
        {
            BrewedDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Tea"))
        {
            TeaDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Other"))
        {
            OtherDrinks.Add(drink);
        }
        
        
        
    }

    public void AddProduct(Product product)
    {
        CartItems.Add(product);
    }
}