
using Sweditech.ConsoleApp.Products.Interfaces;
using Sweditech.ConsoleApp.Products.Models;

namespace Sweditech.ConsoleApp.Products.Services;

public class ProductDialogService(IProductService productService) : IProductDialog
{
    public void MenuDialog()
    {
        string menuSelection;

        do
        {
            List<string> menu = [
                "1. Lägg till produkt",
                "2. Visa alla produkter",
                "0. Avsluta"
            ];

            menu.ForEach(menuItem => Console.WriteLine(menuItem));

            Console.WriteLine();
            menuSelection = Console.ReadLine() ?? "";

            switch (menuSelection)
            {
                case "1":
                    AddProductDialog();
                    break;
                case "2":
                    ShowAllProductsDialog();
                    break;
                case "0":
                    break;
            } 
        }
        while(menuSelection == "1" || menuSelection == "2");
    }
    public void AddProductDialog()
    {
        string name;

        do
        {
            Console.Clear();
            Console.Write("Ange produktnamn: ");
            name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("--- Du måste ange ett giligt namn ---");
            }

        }
        while (string.IsNullOrWhiteSpace(name));

        decimal price;
        bool parseSuccess;

        do
        {
            Console.Write("Ange pris: ");
            parseSuccess = decimal.TryParse(Console.ReadLine(), out price);

            if (!parseSuccess || price <= 0)
            {
                Console.WriteLine("--- Du måste ange ett nummer större än 0 ---");
            }
        }
        while (!parseSuccess || price <= 0);

        productService.AddProduct(name, price);

        Console.Clear();
        Console.WriteLine($"{name} har lagts till");
        Console.WriteLine();
    }

    public void ShowAllProductsDialog()
    {
        IReadOnlyList<Product> products = productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("=== Products ===");
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}");
            Console.WriteLine($"Produktnamn: {product.Name}");
            Console.WriteLine($"Pris: {product.Price}kr");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
