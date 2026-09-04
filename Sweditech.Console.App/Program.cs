using Sweditech.ConsoleApp.Suppliers.Services;

var supplierService = new SupplierService();
var supplierDialog = new SupplierDialogService(supplierService);
supplierDialog.SupplierMenuDialog();