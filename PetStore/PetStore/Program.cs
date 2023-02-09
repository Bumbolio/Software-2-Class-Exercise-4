using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore;
using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Logic;
using System.Text.Json;
using System.Text.Json.Serialization;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();
var orderLogic = services.GetService<IOrderLogic>();

string userInput = DisplayMenuAndGetInput();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a Dog Leash in JSON format");
        var userInputAsJson = Console.ReadLine();
        var dogLeash = JsonSerializer.Deserialize<Product>(userInputAsJson);
        productLogic.AddProduct(dogLeash);
    }
    if (userInput == "2")
    {
        Console.Write("What is the name of the dog leash you would like to view? ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetProductByName(dogLeashName);
        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        Console.WriteLine();
    }
    if (userInput == "3")
    {
        Console.Write(" Insert an Order by providing the name of a product");

        var productName = Console.ReadLine();
        var products = productLogic.GetAllProducts();
        var product = productLogic.GetProductByName(productName);

        var order = new Order
        {
            OrderId = Guid.NewGuid(),
            OrderDate = DateTime.UtcNow,
            Products = new List<Product>() { product }
        };

        orderLogic.AddOrder(order);
    }
    if (userInput == "4")
    {
        Console.Write(" Here are a list of order");

        var orders = orderLogic.GetAllOrders();

        orders.ForEach(o => {
            Console.WriteLine($"{o.OrderId} - {o.OrderDate} - {o.Products.First() }");
        });

    }

    userInput = DisplayMenuAndGetInput();
}

static string DisplayMenuAndGetInput()
{
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a Dog Leash Product");
    Console.WriteLine("Press 3 to add an Order");
    Console.WriteLine("Press 4 to view all Orders");
    Console.WriteLine("Type 'exit' to quit");

    return Console.ReadLine();
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<IOrderLogic, OrderLogic>()
        .AddTransient<IOrdersRepository, OrdersRepository>()
        .BuildServiceProvider();
}