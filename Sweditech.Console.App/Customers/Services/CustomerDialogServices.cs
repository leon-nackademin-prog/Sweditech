using Sweditech.ConsoleApp.Customers.Interfaces;

namespace Sweditech.ConsoleApp.Customers.Services;

internal class CustomerDialogServices(ICustomerService customerService) : ICustomerDialog
{
    public void KundMeny()
    {

        bool isRunning = true;
        while (isRunning == true)
        {

            Console.WriteLine("Välkommen till kundmenyn!");
            Console.WriteLine("1. Lägg till kund");
            Console.WriteLine("2. Visa kundinformation");
            Console.WriteLine("3. Avsluta");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowCustomerDialog();
                    break;
                case "2":
                    DisplayCustomerInfo();
                    break;
                case "3":
                    Console.WriteLine("Avslutar programmet...");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    public void ShowCustomerDialog()
    {
        Console.WriteLine("Ange namn: ");
        string name = Console.ReadLine();
        Console.WriteLine("Ange Emailadress:");
        string email = Console.ReadLine();

        string customerInfo = $"{name}, {email}";
        Console.WriteLine("Kundinformation:");
        Console.WriteLine(customerInfo);

        var CustomerMessage = customerService.AddCustomer(name, email);

        Console.WriteLine($"Kund tillagd med namn {CustomerMessage.Name} och email {CustomerMessage.Email}.");
    }

    public void DisplayCustomerInfo()
    {
        foreach (var customer in customerService.GetAllCustomers())
        {
            Console.WriteLine($"Kundnamn: {customer.Name}, \n Kundemail: {customer.Email}");
        }
        ;
    }
}
