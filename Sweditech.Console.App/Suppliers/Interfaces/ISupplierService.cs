using Sweditech.ConsoleApp.Suppliers.Models;

namespace Sweditech.ConsoleApp.Suppliers.Interfaces;

public interface ISupplierService
{
    Supplier AddSupplier(string name, string contactEmail, string contactPhone);
    bool RemoveSupplier(string contactEmail);
    IReadOnlyList<Supplier> GetAllSuppliersList();
}
