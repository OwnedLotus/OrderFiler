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
    public async void SaveOrders()
    {
        using StreamWriter stream = new StreamWriter(pathToDB, false);

        foreach (var order in orderSet)
        {
            jsonOrderCollection += JsonSerializer.Serialize(order);
            jsonOrderCollection +="\n";
        }

    
        stream.Close();
    }

    public async void LoadOrders()
    {
        var orders = File.ReadAllTextAsync(pathToDB);


        // foreach (var order in splitOrders)
        // {
        //     orderSet.Add(JsonSerializer.Deserialize<Order?>(order));
        // }
    }
}
