using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderFiler.Models;

class OrderCurrier
{
    string jsonOrderCollection = String.Empty;
    private SortedSet<Order?> orderSet;
    private string pathToDB =  Directory.GetCurrentDirectory() + "/database.json";

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
            order.DisplayOrder();
        }
        Console.WriteLine("---------------------------");
    }

    public void GetOrder(uint ordernum)
    {
        var order = orderSet.Single(ord => ord?.OrderNumber == ordernum);
        order?.DisplayOrder();
    }

    public void GetOrder(string ponumber)
    {
        var order = orderSet.Single(ord => ord?.PoNumber == ponumber);
    }

    public IEnumerable<Order> SelectMethod(ShippingMethod method)
    {
        return from order in orderSet
                    where order.Method == method
                    select order;
    }

    public void RemoveOrder(uint ordernum)
    {
        orderSet.RemoveWhere(order => order.OrderNumber == ordernum);
        Console.WriteLine("Successfully removed Order");
    }

    public void RemoveOrder(string po)
    {
        orderSet.RemoveWhere(order => order.PoNumber == po);
        Console.WriteLine("Successfully removed Order");
    }

    // intend for plaintext json database
    // there is no need for security
    public void SaveOrders()
    {
        var serializedOrders = JsonSerializer.Serialize<SortedSet<Order?>>(orderSet);

        File.Delete(pathToDB);   
        File.WriteAllText(pathToDB, serializedOrders);
    }

    public void LoadOrders()
    {
        var serializedOrders = File.ReadAllText(pathToDB);

        orderSet = JsonSerializer.Deserialize<SortedSet<Order?>>(serializedOrders)!;
    }
}
