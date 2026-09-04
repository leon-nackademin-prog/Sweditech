
namespace Sweditech.ConsoleApp.Products.Models;

public class Product(Guid id, string name, decimal price)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
}
