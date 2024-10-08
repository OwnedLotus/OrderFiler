using System.Text.Json;

namespace OrderFiler.Models;

class OrderCurrier
{
    string jsonOrderCollection = String.Empty;
    private SortedSet<Order?> orderSet;
    private string pathToDB =  Directory.GetCurrentDirectory() + "/database.json";
    public int Count { get => orderSet.Count; }  

    public OrderCurrier()
    {
        orderSet = new SortedSet<Order?>();
    }

    public bool AddOrder(Order order)
    {
        var success = orderSet.Add(order);
        if (success)
        {
            return success;
        }
        else
        {
            Console.WriteLine("Order Duplicated");
            return false;
        }
    }

    public void DisplayAllOrders()
    {
        Console.WriteLine("---------------------------");
        foreach (var order in orderSet)
        {
            if(order is not null)
                order.DisplayOrder();
        }
        Console.WriteLine("---------------------------");
    }

    public Order? GetOrder(uint orderNum)
    {
        var order = orderSet.SingleOrDefault(ord => ord?.OrderNumber == orderNum);
        if (order is not null)
            return order;
        else
        {
            Console.WriteLine("Order not found");
            return null;
        }
    }

    public Order? GetOrder(string poNumber)
    {
        var order = orderSet.SingleOrDefault(ord => ord?.PoNumber == poNumber);
        if (order is not null)
            return order;
        else
        {
            Console.WriteLine("Order not Found");
            return null;
        }
    }

    public IEnumerable<Order> SelectMethod(ShippingMethod method)
    {
        return from order in orderSet
                    where order.Method == method
                    select order;
    }

    public void RemoveOrder(uint orderNum)
    {
        var num = orderSet.RemoveWhere(order => order?.OrderNumber == orderNum);
        if (num != 0)
        Console.WriteLine("Successfully removed Orders");
        else
        Console.WriteLine("Failed to remove orders");
    }

    public void RemoveOrder(string po)
    {
        var num = orderSet.RemoveWhere(order => order?.PoNumber == po);
        if (num != 0)
        Console.WriteLine("Successfully removed Order");
        else
        Console.WriteLine("Failed to remove order");
    }

    public bool ReplaceOrder(Order? order)
    {
        return false;
    }

    // intend for plaintext json database
    // there is no need for security
    public void SaveOrders()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        var serializedOrders = JsonSerializer.Serialize<SortedSet<Order?>>(orderSet, options);

        File.Delete(pathToDB);   
        File.WriteAllText(pathToDB, serializedOrders);
    }

    public async Task<Task> LoadOrders()
    {
        if(File.Exists(pathToDB))
        {
            var serializedOrders = await File.ReadAllTextAsync(pathToDB);
           

            orderSet = JsonSerializer.Deserialize<SortedSet<Order?>>(serializedOrders)!;
        }
        else
        {
            Console.WriteLine("Nothing to load");
        }

        return Task.CompletedTask;
    }
}
