using Sweditech.ConsoleApp.Suppliers.Interfaces;
using Sweditech.ConsoleApp.Suppliers.Models;

namespace Sweditech.ConsoleApp.Suppliers.Services;

internal class SupplierService : ISupplierService
{
    private readonly List<Supplier> _suppliers = [];

    private Supplier GenerateSupplier(string name, string contactEmail, string contactPhone)
    {
        var supplier = new Supplier(Guid.NewGuid(), name, contactEmail, contactPhone);
        return supplier;
    }

    public Supplier AddSupplier(string name, string contactEmail, string contactPhone)
    {
        var supplier = GenerateSupplier(name, contactEmail, contactPhone);
        _suppliers.Add(supplier);
        return supplier;
    }

    public bool RemoveSupplier(string companyEmail)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.ContactEmail == companyEmail);
        if (supplier == null) return false;
        _suppliers.Remove(supplier);
        return true;
    }

    public IReadOnlyList<Supplier> GetAllSuppliersList() => _suppliers;    
}
