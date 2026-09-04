namespace Sweditech.ConsoleApp.Suppliers.Models;

public record Supplier(
    Guid CompanyId,
    string CompanyName,
    string ContactEmail,
    string ContactPhone
    );
