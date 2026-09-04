
using Sweditech.ConsoleApp.Products.Services;

var productService = new ProductService();
var productDialogService = new ProductDialogService(productService);
productDialogService.MenuDialog();