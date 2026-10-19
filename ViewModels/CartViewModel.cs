using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Starbucks_POS.Models;

// This is where the database is populated from

namespace Starbucks_POS.ViewModels;

public class CartViewModel
{
    // This stores your items and automatically notifies the UI of changes
    public ObservableCollection<Product> CartItems { get; set; } = new();

    public void AddProduct(Product product)
    {
        CartItems.Add(product);
    }
}