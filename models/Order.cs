using System.Text.Json.Serialization;

namespace OrderFiler.Models;

public enum ShippingMethod
{
    CPUP,
    BACKORDER,
    SHIPPING
}

class Order : IComparable<Order>
{
    public bool IsPulled { get; set; }
    public uint OrderNumber { get; set; }
    public string? PoNumber { get; set; }
    public ShippingMethod Method { get; set; }
    public DateTime OrderEntered { get; set; }

    [JsonConstructor]
    public Order(bool isPulled, uint orderNumber, string poNumber,  ShippingMethod method, DateTime orderEntered)
    {
        OrderNumber = orderNumber;
        PoNumber = poNumber;
        IsPulled = isPulled;
        Method = method;
        OrderEntered = orderEntered;
    }


    public int CompareTo(Order? obj)
    {
        if (obj is not null)
            return this.OrderNumber.CompareTo(obj.OrderNumber);
    
        return 0;
    }

    public void DisplayOrder()
    {
        System.Console.WriteLine($"{this.OrderNumber} / {this.PoNumber} / Shipping: {this.Method} / Pulled? {this.IsPulled} // Time Entered {this.OrderEntered}");
    }
}
