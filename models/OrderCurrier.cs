namespace OrderFiler.Models;

class OrderCurrier
{
    private SortedSet<Order> orderSet;

    public OrderCurrier()
    {
        orderSet = new SortedSet<Order>();
    }

    public bool AddOrder(Order? order)
    {
        if (order is not null)
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
        else
        {
            System.Console.WriteLine("Entry Failed because of Null Order");   
            return false;
        }
    }

    public void DisplayAllOrders()
    {
        System.Console.WriteLine("---------------------------");
        foreach (var order in orderSet)
        {
            System.Console.WriteLine(order.OrderNumber + " / " + order.PONumber + $" / Pulled? {order.IsPulled}");
        }
        System.Console.WriteLine("---------------------------");
    }
}
