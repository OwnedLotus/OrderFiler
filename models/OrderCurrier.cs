using System.Text.Json;

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
            if(order is not null)
                order.DisplayOrder();
        }
        Console.WriteLine("---------------------------");
    }

    public void GetOrder(uint orderNum)
    {
        var order = orderSet.Single(ord => ord?.OrderNumber == orderNum);
        order?.DisplayOrder();
    }

    public void GetOrder(string poNumber)
    {
        var order = orderSet.Single(ord => ord?.PoNumber == poNumber);
        if (order is not null)
            order.DisplayOrder();
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
