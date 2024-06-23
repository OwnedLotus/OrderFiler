using OrderFiler.Models;

var orders = new OrderCurrier();

while (true)
{
    Console.WriteLine("Please Enter an Order Number");
    var OrderNumberIn = Console.ReadLine();

    if (OrderNumberIn == "q") QuitProgram();

    Console.WriteLine("Please Enter the PO Number");
    var PONumberIn = Console.ReadLine();


    uint parsedValue = 1;
    bool success = false;

    if (OrderNumberIn is not null)
        success = OrderNumberIn.Length == 8;

    success = uint.TryParse(OrderNumberIn, out parsedValue);

    if (success)
    {
        if (PONumberIn is not null)
            orders.AddOrder(new Order(parsedValue, PONumberIn));
        else
            Console.WriteLine("PO is null");
    }
    else
        Console.WriteLine("Order Failed to be registered");


}

void QuitProgram()
{
    Environment.Exit(0);
}
