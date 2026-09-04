using Sweditech.ConsoleApp.Suppliers.Models;

namespace Sweditech.ConsoleApp.Suppliers.Interfaces;

public interface ISupplierDialog
{
    void SupplierMenuDialog();
    void ShowAllSuppliersDialog(IReadOnlyList<Supplier> suppliers);
    void AddSupplierDialog();
    void RemoveSupplierDialog();
}
