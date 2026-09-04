
using Sweditech.ConsoleApp.Products.Interfaces;
using Sweditech.ConsoleApp.Products.Models;

namespace Sweditech.ConsoleApp.Products.Services;

internal class ProductService : IProductService
{
    private readonly List<Product> _products = [];
    public Product AddProduct(string name, decimal price)
    {
        Product product = CreateProduct(name, price);

        _products.Add(product);

        return product;
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _products;
    }

    private static Product CreateProduct(string name, decimal price)
    {
        Guid id = Guid.NewGuid();
        Product product = new(id, name, price);

        return product;
    }
}
