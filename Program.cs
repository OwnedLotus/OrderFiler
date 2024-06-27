using OrderFiler.Models;

var orders = new OrderCurrier();

while (true)
{
    System.Console.WriteLine("What would you like to do?");
    var input = Console.ReadLine();

    switch (input)
    {
        case "list":
            orders.DisplayAllOrders();
        break;
        case "search":
        break;
        case "remove":
        break;
        case "add":
            AddOrders();
        break;
        case "quit":
            QuitProgram();
        break;
        default:
        break;
    }
}



    // if (OrderNumberIn == "list")
    // {
    //     orders.DisplayAllOrders();
    //     continue;
    // } 
    // if (OrderNumberIn == "remove") {}
    // if (OrderNumberIn == "edit") {}
    // if (OrderNumberIn == "search")


void QuitProgram()
{
    Environment.Exit(0);
}

void AddOrders()
{
    while (true)
    {
    Console.WriteLine("Please Enter an Order Number");
    var OrderNumberIn = Console.ReadLine();

    if (OrderNumberIn == "exit") return;


    Console.WriteLine("Please Enter the PO Number");
    var PONumberIn = Console.ReadLine();


    var failed = true;
    bool check = false;
    do
    {
        System.Console.WriteLine("Is the order pulled?");
        var checkedIn = Console.ReadLine();

        if (checkedIn == "t" || checkedIn == "T" || checkedIn == "Y" || checkedIn == "y")
        {
            check = true;
            failed = false;
        } else if (checkedIn == "f" || checkedIn == "F" || checkedIn == "N" || checkedIn =="n")
        {
            check = false;
            failed = false;
        }
        else
        {
            failed = true;
        }
    } while (failed);

    ShippingMethod method = ShippingMethod.CPUP;
    failed = true;

    do
    {
        System.Console.WriteLine("What shipping method? (\"S\", \"C\", \"B\")");
        var methodIn = Console.ReadLine();

        if (methodIn == "S"|| methodIn == "s")
        {
            method = ShippingMethod.SHIPPING;
            failed = false;
        }
        if (methodIn == "C" || methodIn == "c")
        {
            method = ShippingMethod.CPUP;
            failed = false;
        }
        if (methodIn == "B" || methodIn == "b")
        {
            method = ShippingMethod.BACKORDER;
            failed = false;
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
            orders.AddOrder(new Order(parsedValue, PONumberIn, check, method));
        else
            Console.WriteLine("PO is null");
    }
    else
        Console.WriteLine("Order Failed to be registered");
    }
}