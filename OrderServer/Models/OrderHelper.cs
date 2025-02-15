using System.Text.Json;
using OrderFiler.Models;

namespace OrderServer.Models;

public class OrderHelper
{
    string jsonOrderCollection = String.Empty;
    SortedSet<Order> orders = new();
    private string pathToDb = Directory.GetCurrentDirectory() + "/database.json";
    public int Count => orders.Count;

    public bool AddOrder(Order order)
    {
        return orders.Add(order);
    }

    public void DisplayOrders()
    {
        Console.WriteLine("---------------------------");
        foreach (var order in orders)
        {
            order.DisplayOrder();
        }
        Console.WriteLine("---------------------------");
    }

    public Order? GetOrder(uint orderId)
    {
        return orders.SingleOrDefault(ord => ord.OrderNumber == orderId);
    }

    public Order? GetOrder(string poNumber)
    {
        return orders.SingleOrDefault(ord => ord.PoNumber == poNumber);
    }

    public IEnumerable<Order> SelectMethod(ShippingMethod method)
    {
        return orders.Where(ord => ord.Method == method);
    }

    public int RemoveOrder(uint orderId)
    {
        return orders.RemoveWhere(ord => ord.OrderNumber == orderId);
    }

    public int RemoveOrder(string poNumber)
    {
        return orders.RemoveWhere(ord => ord.PoNumber == poNumber);
    }

    public async Task LoadAsync()
    {
        if (File.Exists(pathToDb))
        {
            jsonOrderCollection = await File.ReadAllTextAsync(pathToDb);
            orders.Clear();
            
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                TypeInfoResolver = Theme
            }
            
            
            var check = JsonSerializer.Deserialize<SortedSet<Order>>(jsonOrderCollection);
        }
    }

}