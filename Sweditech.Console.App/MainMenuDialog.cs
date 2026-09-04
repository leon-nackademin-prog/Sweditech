using Sweditech.ConsoleApp.Customers.Interfaces;
using Sweditech.ConsoleApp.Products.Interfaces;
using Sweditech.ConsoleApp.Suppliers.Interfaces;

namespace Sweditech.ConsoleApp;

public class MainMenuDialog(
    ICustomerDialog customerDialog,
    IProductDialog productDialog,
    ISupplierDialog supplierDialog) : IMainMenuDialog
{
    public void Run()
    {
        var isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Sweditech Console Application!");
            Console.WriteLine("Vänligen välj ett alternativ:");
            Console.WriteLine("1. Kundsidan");
            Console.WriteLine("2. Produktsidan");
            Console.WriteLine("3. Leverantörssidan");
            Console.WriteLine("4. Avsluta");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    customerDialog.KundMeny();
                    break;
                case "2":
                    productDialog.MenuDialog();
                    break;
                case "3":
                    supplierDialog.SupplierMenuDialog();
                    break;
                case "4":
                    isRunning = false;
                    Environment.Exit(0);
                    return;
                default:
                    break;
            }
        }
    }
}
