using System.Configuration;
using System.Data;
using System.Windows;
using Starbucks_POS.Models;

namespace Starbucks_POS;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // On start up it will populate the database
        using var context = new PosContext();
        DbInitialise.SeedMenu(context);
    }
}