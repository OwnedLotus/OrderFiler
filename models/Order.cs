namespace OrderFiler.Models;

class Order(uint on, string po, bool ip) : IComparable<Order>
{

    private DateTime orderEntered = DateTime.Now;

    public bool IsPulled { get; set; } = ip;
    public uint OrderNumber { get; set; } = on;
    public string? PONumber { get; set; } = po;
    public DateTime OrderEntered
    {
        get => orderEntered;
    }


    public int CompareTo(Order obj)
    {
        return this.OrderNumber.CompareTo(obj.OrderNumber);
    }
}
