
using Sweditech.Console.App.Products.Models;

namespace Sweditech.Console.App.Products.Interfaces
{
    public interface IProductService
    {
        void AddProduct(string name, decimal price);
        IReadOnlyList<Product> GetAllProducts();
    }
}
