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
    public ObservableCollection<Drink> PermanentFrappuccinoDrinks { get; set; } = new();
    public ObservableCollection<Drink> LimitedFrappuccinoDrinks { get; set; } = new();
    public ObservableCollection<Drink> PermanentBrewedDrinks { get; set; } = new();
    public ObservableCollection<Drink> LimitedBrewedDrinks { get; set; } = new();
    public ObservableCollection<Drink> PermanentTeaDrinks { get; set; } = new();
    public ObservableCollection<Drink> LimitedTeaDrinks { get; set; } = new();
    public ObservableCollection<Drink> PermanentOtherDrinks { get; set; } = new();
    public ObservableCollection<Drink> LimitedOtherDrinks { get; set; } = new();

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
            if (drink is LmtdDrink)
                LimitedFrappuccinoDrinks.Add(drink);
            else
                PermanentFrappuccinoDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Brewed"))
        {
            if (drink is LmtdDrink)
                LimitedBrewedDrinks.Add(drink);
            else
                PermanentBrewedDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Tea"))
        {
            if (drink is LmtdDrink)
                LimitedTeaDrinks.Add(drink);
            else
                PermanentTeaDrinks.Add(drink);
        }
        foreach (var drink in availableDrinks.Where(d => d.DrinkCategory == "Other"))
        {
            if (drink is LmtdDrink)
                LimitedOtherDrinks.Add(drink);
            else
                PermanentOtherDrinks.Add(drink);
        }
        
        
        
    }

    public void AddProduct(Product product)
    {
        CartItems.Add(product);
    }
}