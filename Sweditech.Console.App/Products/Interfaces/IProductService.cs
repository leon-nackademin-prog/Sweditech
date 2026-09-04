
using Sweditech.ConsoleApp.Products.Models;

namespace Sweditech.ConsoleApp.Products.Interfaces
{
    public interface IProductService
    {
        Product AddProduct(string name, decimal price);
        IReadOnlyList<Product> GetAllProducts();
    }
}
