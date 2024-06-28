using System.Linq;
using System.Text.Json;

namespace OrderFiler.Models;

class OrderCurrier
{
    private SortedSet<Order> orderSet;

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
            System.Console.WriteLine("Order Duplicated");
            return false;
        }
    }

    public void DisplayAllOrders()
    {
        System.Console.WriteLine("---------------------------");
        foreach (var order in orderSet)
        {
            order.DisplayOrder();
        }
        System.Console.WriteLine("---------------------------");
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
        System.Console.WriteLine("Successfully removed Order");
    }

    public void RemoveOrder(string po)
    {
        orderSet.RemoveWhere(order => order.PONumber == po);
        System.Console.WriteLine("Successfully removed Order");
    }

    // intend for plaintext json database
    // there is no need for security
    public void SaveOrders()
    {
        foreach (var order in orderSet)
        {
            var jsonOrder = JsonSerializer.Serialize(order);
            Console.WriteLine(jsonOrder);
        }
    }
}
