using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sweditech.ConsoleApp;
using Sweditech.ConsoleApp.Customers.Interfaces;
using Sweditech.ConsoleApp.Customers.Services;
using Sweditech.ConsoleApp.Products.Interfaces;
using Sweditech.ConsoleApp.Products.Services;
using Sweditech.ConsoleApp.Suppliers.Interfaces;
using Sweditech.ConsoleApp.Suppliers.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerDialog, CustomerDialogServices>();
builder.Services.AddTransient<IProductDialog, ProductDialogService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddTransient<ISupplierDialog, SupplierDialogService>();
builder.Services.AddSingleton<ISupplierService, SupplierService>();
builder.Services.AddSingleton<IMainMenuDialog, MainMenuDialog>();


using var host = builder.Build();

var dialog = host.Services.GetRequiredService<IMainMenuDialog>();
dialog.Run();
