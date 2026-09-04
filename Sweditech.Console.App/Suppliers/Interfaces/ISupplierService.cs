using Sweditech.Console.App.Suppliers.Models;

namespace Sweditech.Console.App.Suppliers.Interfaces;

public interface ISupplierService
{
    Supplier AddSupplier(string name, string contactEmail, string contactPhone, string contactAddress);
    bool RemoveSupplier(string name);
    IReadOnlyList<Supplier> ShowAllSuppliers();
}
