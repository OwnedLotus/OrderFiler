using OrderFiler.Models;
using Terminal.Gui;
using OrderFiler.Models.Windows;

Application.Init();
var top = Application.Top;
var mainWindow = new MainWindow("Home Page"){
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()! - 1
};
var addPage = new AddWindow("Add Orders"){
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()! - 1
};
var editPage = new EditWindow("Edit Orders"){
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()! - 1
};
var removePage = new RemoveWindow("Remove Orders"){
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()! - 1
};

mainWindow.TabIndex = 0;
addPage.TabIndex = 1;
editPage.TabIndex = 2;
removePage.TabIndex = 3;

top?.Add(mainWindow);

var menu = new MenuBar(new MenuBarItem[]
{
    new MenuBarItem("Add Order","", () => {
        mainWindow.RemoveAll();

    })
});


Application.Shutdown();







// var orders = new OrderCurrier();

// Console.WriteLine("Loading Orders...");
// await orders.LoadOrders();
// Console.WriteLine("Finished Loading Orders");

// orders.DisplayAllOrders();

// while (true)
// {
//     Console.WriteLine("What would you like to do?");
//     var input = Console.ReadLine();

//     switch (input)
//     {
//         case "list":
//             orders.DisplayAllOrders();
//         break;
//         case "count":
//             Console.WriteLine($"The current number of order is: {orders.Count}");
//             break;
//         case "select":
//             SelectOrder();
//         break;
//         case "search":
//             FindOrder();
//         break;
//         case "edit":
//             EditOrder();
//             break;
//         case "remove":
//             RemoveMenu();
//         break;
//         case "add":
//             AddOrders();
//         break;
//         case "save":
//             orders.SaveOrders();
//         break;
//         case "forceload":
//             await orders.LoadOrders();
//             break;
//         case "quit":
//             QuitProgram();
//         break;
//         default:
//         break;
//     }
// }

// void QuitProgram()
// {
//     orders.SaveOrders();
//     Environment.Exit(0);
// }

// void AddOrders()
// {
//     while (true)
//     {
//         Console.WriteLine("Please Enter an Order Number");
//         var OrderNumberIn = Console.ReadLine();

//         if (OrderNumberIn?.ToLower() == "quit") return;
//         var success = uint.TryParse(OrderNumberIn, out uint parsedValue);
//         orders.GetOrder(parsedValue);

//         Console.WriteLine("Please Enter the PO Number");
//         var PONumberIn = Console.ReadLine();


//         var failed = true;
//         bool check = false;
//         do
//         {
//             Console.WriteLine("Is the order pulled?");
//             var checkedIn = Console.ReadLine();

//             if (checkedIn == "t" || checkedIn == "T" || checkedIn == "Y" || checkedIn == "y")
//             {
//                 check = true;
//                 failed = false;
//             } else if (checkedIn == "f" || checkedIn == "F" || checkedIn == "N" || checkedIn =="n")
//             {
//                 check = false;
//                 failed = false;
//             }
//             else
//             {
//                 failed = true;
//             }
//         } while (failed);

//         ShippingMethod method = ShippingMethod.CPUP;
//         failed = true;

//         do
//         {
//             Console.WriteLine("What shipping method? (\"S\", \"C\", \"B\")");
//             var methodIn = Console.ReadLine();

//             if (methodIn == "S"|| methodIn == "s")
//             {
//                 method = ShippingMethod.SHIPPING;
//                 failed = false;
//             }
//             if (methodIn == "C" || methodIn == "c")
//             {
//                 method = ShippingMethod.CPUP;
//                 failed = false;
//             }
//             if (methodIn == "B" || methodIn == "b")
//             {
//                 method = ShippingMethod.BACKORDER;
//                 failed = false;
//             }
//         } while (failed);


//         if (OrderNumberIn is not null)
//             success = OrderNumberIn.Length == 8;


//         if (success)
//         {
//             if (PONumberIn is not null)
//                 orders.AddOrder(new Order(check, parsedValue, PONumberIn, method, DateTime.Now));
//             else
//                 Console.WriteLine("PO is null");
//         }
//         else
//             Console.WriteLine("Order Failed to be registered");
//     }
// }

// void FindOrder()
// {
//     do
//     {
//         Console.WriteLine("Sales Order, PO Number, Shipping Method");
//         var response = Console.ReadLine();

//         if (response == "S" || response == "s")
//         {
//             FindBySO();
//         } 
//         else if (response == "P" || response == "p")
//         {
//             FindByPO();
//         }
//         else if (response == "M" || response == "m")
//         {
//             ControlFlowMethod();
//         }
//         else if (response == "q" || response == "Q")
//         {
//             return;
//         }
//     } while (true);
// }

// void RemoveMenu()
// {

//     while (true)
//     {
//         Console.WriteLine("Sales Order or by PO");
//         var input = Console.ReadLine();
//         if (input == "S" || input == "s")
//         {
//             RemoveSalesOrder();
//         }
//         else if (input == "P" || input == "p")
//         {
//             RemovePO();
//         }
//         else if (input == "q" || input == "Q")
//         {
//             return;
//         }
//         else
//         {
//             Console.WriteLine("Failed to intemperate result: \'S\' or \'P\' or \'Q\'");
//         }
//     }
// }

// void RemoveSalesOrder()
// {
//     Console.WriteLine("Enter The Order Number");
//     var input = Console.ReadLine();
//     uint result;

//     var success = uint.TryParse(input, out result);
//     if (success)
//         orders.RemoveOrder(result);
//     else if (input == "q" || input == "Q")
//     return;
//     else
//         Console.WriteLine("Failed to find order");
// }

// void RemovePO()
// {
//     Console.WriteLine("Enter The PO Number");
//     var input = Console.ReadLine();

//     if (input is not null)
//         orders.GetOrder(input);
//     else if (input == "q" || input == "Q")
//     return;
//     else
//         Console.WriteLine("Failed to find order");
// }

// void EditOrder()
// {
    




//     // bool success = false;

//     // do
//     // {
//     //     Console.WriteLine("Sales Order or PO Number");
//     //     var response = Console.ReadLine();
//     //     if (response == "S" || response == "s")
//     //     {
//     //         EditSalesOrder();
//     //         success = true;
//     //     } 
//     //     else if (response == "P" || response == "p")
//     //     {
//     //         EditPO();
//     //         success = true;
//     //     }
//     //     else if (response == "q" || response == "Q")
//     //     {
//     //         return;
//     //     }

//     // } while (!success);
// }

// void EditSalesOrder()
// {
//     bool success = false;

//     do
//     {
//         Console.WriteLine("Enter The Order Number");
//         var input = Console.ReadLine();
//         uint result;

//         success = uint.TryParse(input, out result);
//         if (success)
//             orders.GetOrder(result);
//         else if (input == "q" || input == "Q")
//         return;
//         else
//             Console.WriteLine("Failed to find order");
//     } while(!success);
// }

// void EditPO()
// {
//     bool success = false;
//     do
//     {
//         Console.WriteLine("Enter The PO Number");
//         var input = Console.ReadLine();

//         if (input is not null)
//         {
//             orders.GetOrder(input);
//             success = true;
//         }
//         else if (input == "q" || input == "Q")
//             return;
//         else
//             Console.WriteLine("Failed to find order");
//     } while (!success);
// }

// void SelectOrder()
// {
//     bool success = false;
//     do 
//     {
//         System.Console.WriteLine("\'D\'isplay, \'E\'dit?");
//         var input = Console.ReadLine();

//         if (input == "D" || input == "d")
//         {
//             FindOrder();
//             success = true;
//         }
//         else if (input == "E" || input == "e")
//         {
//             EditOrder();
//             success = true;
//         }
//         else if (input == "q" || input == "Q")
//         {
//             return;
//         }
//         else
//         {
//             Console.WriteLine("Failed to interpret input");
//         }
//     } while(!success);
// }

// void ControlFlowMethod()
// {
//     Console.WriteLine("Enter the Shipping Method (\'S\', \'B\', \'C\')");
//     var input = Console.ReadLine();
//     bool success = false;
//     List<Order?> foundOrders = new();

//     do
//     {
//         if (input == "s" || input == "S")
//         {
//             foundOrders = orders.SelectMethod(ShippingMethod.SHIPPING).ToList()!;
//             success = true;
//         } 
//         else if (input == "B" || input == "b")
//         {
//             foundOrders = orders.SelectMethod(ShippingMethod.BACKORDER).ToList()!;
//             success = true;
//         } 
//         else if (input == "C" || input == "c")
//         {
//             foundOrders = orders.SelectMethod(ShippingMethod.CPUP).ToList()!;
//             success = true;
//         }
//         else if (input == "q" || input == "Q")
//         {
//             return;
//         }
//         else
//         {
//             Console.WriteLine("Failed to interpret input");

//         }

//         foreach (var order in foundOrders)
//         {
//             order?.DisplayOrder();
//         }
//     } while (!success);
// }

// void FindByPO()
// {
//     Console.WriteLine("Enter The PO Number");
//     var input = Console.ReadLine();
//     Order? foundOrder = null;

//     uint result;

//     var success = uint.TryParse(input, out result);
//     if (success)
//         foundOrder = orders.GetOrder(result);
//     else if (input == "q" || input == "Q")
//     return;
//     else
//         Console.WriteLine("Failed to find order");
    
//     if (foundOrder is not null)
//     {
//         foundOrder.DisplayOrder();
//     }
// }

// void FindBySO()
// {
//     Console.WriteLine("Enter The Order Number");
//     var input = Console.ReadLine();
//     uint result;
//     Order? foundOrder = null;

//     bool success = uint.TryParse(input, out result);
//     if (success)
//         foundOrder = orders.GetOrder(result);
//     else if (input == "q" || input == "Q")
//     return;
//     else
//         Console.WriteLine("Failed to find order");

//     if (foundOrder is not null)
//     {
//         foundOrder.DisplayOrder();
//     }
// }