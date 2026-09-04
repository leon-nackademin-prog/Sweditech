using System.Threading.Channels;

namespace Sweditech.Customers.Services;

internal class CustomerDialogServices
{
    public void ShowCustomerDialog()
    {
        Console.WriteLine("Ange namn: ");
        string name = Console.ReadLine();
        Console.WriteLine("Ange Emailadress:");
        string email = Console.ReadLine();
    }
}
