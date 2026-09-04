using Sweditech.Console.App.Suppliers.Interfaces;
using Sweditech.Console.App.Suppliers.Models;

namespace Sweditech.Console.App.Suppliers.Services;

internal class SupplierService : ISupplierService
{
    private readonly List<Supplier> _suppliers = [];

    //private Supplier GenerateSupplier(string name, string contactEmail, string contactPhone, string contactAddress)
    //{
    //    var companyId = Guid.NewGuid();
    //    var companyName = $"Supplier {companyId}";
    //    var contactEmail = $"

    public Supplier AddSupplier(string name, string contactEmail, string contactPhone, string contactAddress)
    {
        Console.WriteLine($"Adding supplier: {name}, {contactEmail}, {contactPhone}, {contactAddress}");
        var supplier = new Supplier(Guid.NewGuid(), name, contactEmail, contactPhone, contactAddress);
        _suppliers.Add(supplier);
        return supplier;
    }

    public bool RemoveSupplier(Guid companyId)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.CompanyId == companyId);
        if (supplier == null) return false;
        _suppliers.Remove(supplier);
        return true;
    }

    public IReadOnlyList<Supplier> ShowAllSuppliers() => _suppliers;    

}
