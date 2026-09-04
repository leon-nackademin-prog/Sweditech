namespace Sweditech.Console.App.Suppliers.Interfaces;

public interface ISupplierService
{
    void AddSupplier(string name, string contactEmail);
    void RemoveSupplier(string name);
    void ShowAllSuppliers();
}
