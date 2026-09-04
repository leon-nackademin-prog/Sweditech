using Sweditech.ConsoleApp.Suppliers.Interfaces;
using Sweditech.ConsoleApp.Suppliers.Models;
using System.ComponentModel.DataAnnotations;

namespace Sweditech.ConsoleApp.Suppliers.Services;

public class SupplierDialogService(ISupplierService supplierService) : ISupplierDialog
{
    public void SupplierMenuDialog()
    {
        var isRunning = true;
        var inputKey = ConsoleKey.NoName;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("### Leverantörhanterings Menyn ###");
            Console.WriteLine("1. Skapa ny leverantör");
            Console.WriteLine("2. Visa alla leverantörer");
            Console.WriteLine("3. Ta bort leverantör");
            Console.WriteLine("4. Återgå till huvudmenyn");

            inputKey = Console.ReadKey(true).Key;

            Console.Clear();

            switch (inputKey)
            {
                case ConsoleKey.D1:
                    AddSupplierDialog();
                    break;
                case ConsoleKey.D2:
                    ShowAllSuppliersDialog(supplierService.GetAllSuppliersList());
                    break;
                case ConsoleKey.D3:
                    RemoveSupplierDialog();
                    break;
                case ConsoleKey.D4:
                    isRunning = false;
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                    break;
            }
        }
    }

    public void AddSupplierDialog()
    {
        Console.Clear();
        InputDialog("Ange leverantörens namn:", out var name);
        Console.Clear();
        var emailAdressAttribute = new EmailAddressAttribute();
        InputDialogEmail("Ange leverantörens kontakt e-post:", emailAdressAttribute, out var contactEmail);
        Console.Clear();
        InputDialogPhone("Ange leverantörens kontakt telefonnummer:", out var contactPhone);

        Supplier supplier = supplierService.AddSupplier(name, contactEmail, contactPhone);
        Console.WriteLine($"Leverantör {supplier.CompanyName} har lagts till.");
        Console.ReadKey(true);
    }

    public void RemoveSupplierDialog()
    {
        Console.Clear();
        Console.WriteLine("Ta bort leverantör, ange leverantörens e-postadress:");
        var supplierToRemove = Console.ReadLine();
        if (supplierService.RemoveSupplier(supplierToRemove!))
        {
            Console.WriteLine("Leverantören har tagits bort.");
        }
        else
        {
            Console.WriteLine("Ingen leverantör med denna e-postadress hittades.");
        }
        Console.ReadKey(true);
    }

    public void ShowAllSuppliersDialog(IReadOnlyList<Supplier> suppliers)
    {
        if (suppliers.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Inga leverantörer hittades.");
            Console.ReadKey(true);
            return;
        }

        foreach (var supplier in suppliers)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Leverantör: {supplier.CompanyName}");
            Console.WriteLine($"E-post: {supplier.ContactEmail}");
            Console.WriteLine($"Telefon: {supplier.ContactPhone}");
            Console.WriteLine("------------------------------");
        }
        Console.ReadKey(true);
    }

    private void InputDialog(string text, out string value)
    {
        value = string.Empty;
        while (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine(text);
            value = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.Clear();
                Console.WriteLine("Värdet får inte vara tomt. Vänligen försök igen.");
            }
        }
    }

    private void InputDialogEmail(string text, EmailAddressAttribute emailAdressAttribute, out string value)
    {
        value = string.Empty;
        while (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine(text);
            value = Console.ReadLine()!;

            if (emailAdressAttribute != null && !emailAdressAttribute.IsValid(value))
            {
                Console.Clear();
                Console.WriteLine("Ogiltig e-postadress. Vänligen försök igen.");
                value = string.Empty;
            }

            var tempValue = value;

            if (supplierService.GetAllSuppliersList().Any(s => s.ContactEmail.Equals(tempValue, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Clear();
                Console.WriteLine("En leverantör med denna e-postadress finns redan. Vänligen försök igen.");
                value = string.Empty;
            }
        }
    }

    private void InputDialogPhone(string text, out string value)
    {
        value = string.Empty;
        while (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine(text);
            value = Console.ReadLine()!;

            if (!IsValidPhone(value))
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt telefonnummer. Vänligen försök igen.");
                value = string.Empty;
            }
        }
    }

    private static bool IsValidPhone(string input) => input.All(char.IsDigit) && input.Length >= 7 && input.Length <= 15;
}
