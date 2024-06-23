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
            return orderSet.Add(order);

        return false;
    }
}
