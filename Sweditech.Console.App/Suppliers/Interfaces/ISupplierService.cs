using Sweditech.ConsoleApp.Suppliers.Models;

namespace Sweditech.ConsoleApp.Suppliers.Interfaces;

public interface ISupplierService
{
    Supplier AddSupplier(string name, string contactEmail, string contactPhone, string contactAddress);
    bool RemoveSupplier(Guid companyId);
    IReadOnlyList<Supplier> ShowAllSuppliers();
}
