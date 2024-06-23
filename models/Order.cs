namespace OrderFiler.Models;

class Order : IComparable<Order>
{

    private DateTime orderEntered = DateTime.Now;

    public uint OrderNumber { get; set; }
    public string? PONumber { get; set; }
    public DateTime OrderEntered
    {
        get => orderEntered;
    }


    public Order(uint on, string po)
    {
        this.OrderNumber = on;
        this.PONumber = po;
    }


    public int CompareTo(Order obj)
    {
        if (this.OrderNumber < obj.OrderNumber) return -1;
        if (this.OrderNumber == obj.OrderNumber) return 0;
        return 0;
    }
}
