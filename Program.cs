using System.Diagnostics;
using OrderFiler.Models;

var orders = new OrderCurrier();

Console.WriteLine("Loading Orders...");
orders.LoadOrders();
Console.WriteLine("Finished Loading Orders");

orders.DisplayAllOrders();

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
            orders.AddOrder(new Order(check, parsedValue, PONumberIn, method, DateTime.Now));
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

        if (response == "S" || response == "s")
        {
            FindBySO();
        } 
        else if (response == "P" || response == "p")
        {
            FindByPO();
        }
        else if (response == "M" || response == "m")
        {
            ControlFlowMethod();
        }
        else if (response == "q" || response == "Q")
        {
            return;
        }
    } while (true);
}

void RemoveMenu()
{
    Console.WriteLine("Sales Order or by PO");
    var input = Console.ReadLine();

    while (true)
    {
        if (input == "S" || input == "s")
        {
            RemoveSalesOrder();
        }
        else if (input == "P" || input == "p")
        {
            RemovePO();
        }
        else if (input == "q" || input == "Q")
        {
            return;
        }
        else
        {
            Console.WriteLine("Failed to intemperate result: \'S\' or \'P\' or \'Q\'");
        }
    }
}

void RemoveSalesOrder()
{
    Console.WriteLine("Enter The Order Number");
    var input = Console.ReadLine();
    uint result;

    var success = uint.TryParse(input, out result);
    if (success)
        orders.RemoveOrder(result);
    else
        Console.WriteLine("Failed to find order");
}

void RemovePO()
{
    Console.WriteLine("Enter The PO Number");
    var input = Console.ReadLine();

    if (input is not null)
        orders.GetOrder(input);
    else
        Console.WriteLine("Failed to find order");
}

void EditOrder()
{
    bool success = false;

    do
    {
        Console.WriteLine("Sales Order or PO Number");
        var response = Console.ReadLine();
        if (response == "S" || response == "s")
        {
            EditSalesOrder();
            success = true;
        } 
        else if (response == "P" || response == "p")
        {
            EditPO();
            success = true;
        }
        else if (response == "q" || response == "Q")
        {
            return;
        }

    } while (!success);
}

void EditSalesOrder()
{
    bool success = false;

    do
    {
        Console.WriteLine("Enter The Order Number");
        var input = Console.ReadLine();
        uint result;

        success = uint.TryParse(input, out result);
        if (success)
            orders.GetOrder(result);
        else
            Console.WriteLine("Failed to find order");
    } while(!success);
}

void EditPO()
{
    bool success = false;
    do
    {
        Console.WriteLine("Enter The PO Number");
        var input = Console.ReadLine();

        if (input is not null)
        {
            orders.GetOrder(input);
            success = true;
        }
        else
            Console.WriteLine("Failed to find order");
    } while (!success);
}


void SelectOrder()
{
    bool success = false;
    do 
    {
        System.Console.WriteLine("\'D\'isplay, \'E\'dit?");
        var input = Console.ReadLine();

        if (input == "D" || input == "d")
        {
            FindOrder();
            success = true;
        }
        else if (input == "E" || input == "e")
        {
            EditOrder();
            success = true;
        }
        else if (input == "q" || input == "Q")
        {
            return;
        }
        else
        {
            Console.WriteLine("Failed to interpret input");
        }
    } while(!success);
}

void ControlFlowMethod()
{
    Console.WriteLine("Enter the Shipping Method (\'S\', \'B\', \'C\')");
    var input = Console.ReadLine();
    bool success = false;

    do
    {
        if (input == "s" || input == "S")
        {
            orders.SelectMethod(ShippingMethod.SHIPPING);
            success = true;
        } 
        else if (input == "B" || input == "b")
        {
            orders.SelectMethod(ShippingMethod.BACKORDER);
            success = true;
        } 
        else if (input == "C" || input == "c")
        {
            orders.SelectMethod(ShippingMethod.CPUP);
            success = true;
        }
        else if (input == "q" || input == "Q")
        {
            return;
        }
        else
        {
            Console.WriteLine("Failed to interpret input");

        }
    } while (!success);
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