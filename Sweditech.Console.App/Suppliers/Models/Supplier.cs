namespace Sweditech.Console.App.Suppliers.Models;

public record Supplier(
    Guid CompanyId,
    string CompanyName,
    string ContactEmail,
    string ContactPhone,
    string ContactAddress
    );
