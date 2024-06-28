namespace OrderFiler.Models;

public enum ShippingMethod
{
    CPUP,
    BACKORDER,
    SHIPPING
}


class Order(uint on, string po, bool ip, ShippingMethod m) : IComparable<Order>
{

    private DateTime orderEntered = DateTime.Now;

    public bool IsPulled { get; set; } = ip;
    public uint OrderNumber { get; set; } = on;
    public string? PONumber { get; set; } = po;
    public ShippingMethod Method { get; set; } = m;
    public DateTime OrderEntered
    {
        get => orderEntered;
    }


    public int CompareTo(Order? obj)
    {
        if (obj is not null)
            return this.OrderNumber.CompareTo(obj.OrderNumber);
    
        return 0;
    }

    public void DisplayOrder()
    {
            System.Console.WriteLine($"{this.OrderNumber} / {this.PONumber} / Shipping: {this.Method} / Pulled? {this.IsPulled}");
    }
}
