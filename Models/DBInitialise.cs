using System.IO;
using System.Text.Json;
using System.Windows;

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

        try
        {
            string jsonText = File.ReadAllText("InitialDrinks.json"); // Reads the text from the JSON


            var startingDrinks =
                JsonSerializer
                    .Deserialize<List<Drink>>(jsonText); // Assigns the values in the JSON to instances of the class 


            if (startingDrinks != null && startingDrinks.Any())
            {
                context.Products.AddRange(startingDrinks);
                context.SaveChanges();
            }
        }
        catch (JsonException ex)
        {
            // Catches missing commas, bad types, or ItemType placement errors
            MessageBox.Show($"JSON Formatting Error: {ex.Message}", "Database Seed Failed");
        }
        catch (FileNotFoundException)
        {
            // Catches issues where the file didn't copy to the bin folder
            MessageBox.Show("InitialDrinks.json could not be found.", "Database Seed Failed");
        }
    }
}
