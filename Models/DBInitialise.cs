using System.IO;
using System.Text.Json;

namespace Starbucks_POS.Models;

public static class DbInitialise
{
    public static void SeedMenu(PosContext context)
    {
        // This creates the database if it doesn't exist and builds all tables
        
        //Delete the database if it exists and then create it again
        context.Database.EnsureDeleted(); //Delete the database if it exists
        context.Database.EnsureCreated();
        
        if (context.Products.Any()) return; // If the database already has drinks exit
        
        string jsonText = File.ReadAllText("InitialDrinks.json"); // Reads the text from the JSON

        
        var startingDrinks = JsonSerializer.Deserialize<List<Drink>>(jsonText); // Assigns the values in the JSON to instances of the class 
         

        if (startingDrinks != null && startingDrinks.Any())
        {
            context.Products.AddRange(startingDrinks);
            context.SaveChanges();
        }
    }
}