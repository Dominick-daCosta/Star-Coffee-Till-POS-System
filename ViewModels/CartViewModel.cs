using System.Collections.ObjectModel;
using Starbucks_POS.Models;

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