using System.Text.Json;

namespace OrderFiler.Models;

class OrderCurrier
{
    string jsonOrderCollection = String.Empty;
    private SortedSet<Order> orderSet;
    private string pathToDB = Environment.CurrentDirectory.ToString() + "database.json";

    public OrderCurrier()
    {
        orderSet = new SortedSet<Order>();
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
        var order = orderSet.Single(ord => ord.OrderNumber == ordernum);
        order.DisplayOrder();
    }

    public void GetOrder(string ponumber)
    {
        var order = orderSet.Single(ord => ord.PONumber == ponumber);
    }

    public void RemoveOrder(uint ordernum)
    {
        orderSet.RemoveWhere(order => order.OrderNumber == ordernum);
        Console.WriteLine("Successfully removed Order");
    }

    public void RemoveOrder(string po)
    {
        orderSet.RemoveWhere(order => order.PONumber == po);
        Console.WriteLine("Successfully removed Order");
    }

    // intend for plaintext json database
    // there is no need for security
    public void SaveOrders()
    {
        foreach (var order in orderSet)
        {
            jsonOrderCollection += JsonSerializer.Serialize(order);
            jsonOrderCollection += '\n';
        }

        File.WriteAllText(jsonOrderCollection, pathToDB);
    }

    public void LoadOrders()
    {
        File.ReadAllLines(pathToDB);


    }
}
