using Sweditech.Console.App.Suppliers.Interfaces;
using Sweditech.Console.App.Suppliers.Models;

namespace Sweditech.Console.App.Suppliers.Services;

internal class SupplierService : ISupplierService
{
    public Supplier AddSupplier(string name, string contactEmail, string contactPhone, string contactAddress)
    {
        throw new NotImplementedException();
    }

    public bool RemoveSupplier(string name)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Supplier> ShowAllSuppliers()
    {
        throw new NotImplementedException();
    }
}
