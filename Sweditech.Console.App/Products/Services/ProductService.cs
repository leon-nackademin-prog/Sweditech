
using Sweditech.Console.App.Products.Interfaces;
using Sweditech.Console.App.Products.Models;

namespace Sweditech.Console.App.Products.Services;

internal class ProductService : IProductService
{
    private readonly List<Product> _products = [];
    public void AddProduct(string name, decimal price)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }
}
