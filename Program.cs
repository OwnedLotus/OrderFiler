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
            FindOrder();
        break;
        case "Edit":
            EditOrder();
            break;
        case "remove":
            RemoveMenu();
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

void FindOrder()
{
    do
    {
        System.Console.WriteLine("Sales Order or PO Number");
        var response = Console.ReadLine();
        if (response == "S" || response == "s")
        {
            System.Console.WriteLine("Enter The Order Number");
            var input = Console.ReadLine();
            uint result;

            var success = uint.TryParse(input, out result);
            if (success)
                orders.GetOrder(result);
            else
                System.Console.WriteLine("Failed to find order");
        } 
        else if (response == "P" || response == "p")
        {
            System.Console.WriteLine("Enter The PO Number");
            var input = Console.ReadLine();
            uint result;

            var success = uint.TryParse(input, out result);
            if (success)
                orders.GetOrder(result);
            else
                System.Console.WriteLine("Failed to find order");
        }

    } while (true);
}

void RemoveMenu()
{

}

void EditOrder()
{
    throw new NotImplementedException();
}