using OrderFiler.Models;

var orders = new OrderCurrier();

while (true)
{
    Console.WriteLine("Please Enter an Order Number");
    var OrderNumberIn = Console.ReadLine();

    if (OrderNumberIn == "q") QuitProgram();
    if (OrderNumberIn == "list")
    {
        orders.DisplayAllOrders();
        continue;
    } 

    Console.WriteLine("Please Enter the PO Number");
    var PONumberIn = Console.ReadLine();


    var failed = false;
    bool check = false;
    do
    {
        System.Console.WriteLine("Is the order pulled?");
        var checkedIn = Console.ReadLine();

        if (checkedIn == "t" || checkedIn == "T")
        {
            check = true;
        } else if (checkedIn == "f" || checkedIn == "F")
        {
            check = false;
        }
        else
        {
            failed = true;
        }
    } while (failed);


    uint parsedValue = 1;
    bool success = false;

    if (OrderNumberIn is not null)
        success = OrderNumberIn.Length == 8;

    success = uint.TryParse(OrderNumberIn, out parsedValue);

    if (success)
    {
        if (PONumberIn is not null)
            orders.AddOrder(new Order(parsedValue, PONumberIn, check));
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