using OrderFiler.Models;

var orders = new OrderCurrier();

while (true)
{
    Console.WriteLine("What would you like to do?");
    var input = Console.ReadLine();

    switch (input)
    {
        case "list":
            orders.DisplayAllOrders();
        break;
        case "select":
            SelectOrder();
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
        case "save":
            orders.SaveOrders();
        break;
        case "forceload":
            orders.LoadOrders();
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
        Console.WriteLine("Is the order pulled?");
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
        Console.WriteLine("What shipping method? (\"S\", \"C\", \"B\")");
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
        Console.WriteLine("Sales Order, PO Number, Shipping Method");
        var response = Console.ReadLine();
        switch (response)
        {
            case "s":
                FindBySO();
            break;
            case "S":
                FindBySO();
            break;
            case "P":
                FindByPO();
            break;
            case "p":
                FindByPO();
            break;
            case "M":
                ControlFlowMethod();
            break;
            case "m":
                ControlFlowMethod();
            break;
            
            default:
            break;
        }

    } while (true);
}

void RemoveMenu()
{

}

void EditOrder()
{
    do
    {
        Console.WriteLine("Sales Order or PO Number");
        var response = Console.ReadLine();
        if (response == "S" || response == "s")
        {
            Console.WriteLine("Enter The Order Number");
            var input = Console.ReadLine();
            uint result;

            var success = uint.TryParse(input, out result);
            if (success)
                orders.GetOrder(result);
            else
                Console.WriteLine("Failed to find order");
        } 
        else if (response == "P" || response == "p")
        {
            Console.WriteLine("Enter The PO Number");
            var input = Console.ReadLine();
            uint result;

            var success = uint.TryParse(input, out result);
            if (success)
                orders.GetOrder(result);
            else
                Console.WriteLine("Failed to find order");
        }

    } while (true);
}

void SelectOrder()
{
    do 
    {
        System.Console.WriteLine("\'D\'isplay, \'E\'dit?");
        var input = Console.ReadLine();

        switch (input)
        {
            case "D":
                FindOrder();
            break;
            case "d":
                FindOrder();
            break;
            case "E":
                EditOrder();
            break;
            case "e":
                EditOrder();
            break;
        }

    } while(true);
}

void ControlFlowMethod()
{
        Console.WriteLine("Enter the Shipping Method (\'S\', \'B\', \'C\')");
        var input = Console.ReadLine();

        switch (input)
        {
            case "s":
                orders.SelectMethod(ShippingMethod.SHIPPING);
            break;
            case "S":
                orders.SelectMethod(ShippingMethod.SHIPPING);
            break;
            case "B":
                orders.SelectMethod(ShippingMethod.BACKORDER);
            break;
            case "b":
                orders.SelectMethod(ShippingMethod.BACKORDER);
            break;
            case "C":
                orders.SelectMethod(ShippingMethod.CPUP);
            break;
            case "c":
                orders.SelectMethod(ShippingMethod.CPUP);
            break;
            default:
            break;
        }
}

void FindByPO()
{
    Console.WriteLine("Enter The PO Number");
    var input = Console.ReadLine();

    uint result;

    var success = uint.TryParse(input, out result);
    if (success)
        orders.GetOrder(result);
    else
        Console.WriteLine("Failed to find order");
}

void FindBySO()
{
    Console.WriteLine("Enter The Order Number");
    var input = Console.ReadLine();
    uint result;

    bool success = uint.TryParse(input, out result);
    if (success)
        orders.GetOrder(result);
    else
        Console.WriteLine("Failed to find order");
}