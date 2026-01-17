using System.ComponentModel;
using System.Drawing.Printing;
using CompanyManager.Pages;
using Microsoft.EntityFrameworkCore;
using OrderManager.Models;

namespace OrderManager.Pages;

public partial class HomePage : Form
{
    private Order? selectedOrder = null;
    private string data = string.Empty;
    BindingList<Order> orders = [];
    readonly OrderContext ctx = new();

    public HomePage()
    {
        InitializeComponent();
        LoadOrders();
        CullOrders();
    }

    // Orders marked for deletion will be culled after two weeks
    private void CullOrders()
    {
        List<Order> markedOrders = [.. ctx.Orders.Where(o => o.isDeleted).AsNoTracking()];
        List<Order> deleteOrders = [];

        foreach (var order in markedOrders) {
            if (DateTime.Now - order.UpdatedDate.Date > TimeSpan.FromDays(14))
                deleteOrders.Add(order);
        }

        if (deleteOrders.Count <= 0) return;

        var choice = MessageBox.Show("Delete two week old orders?", "Orders to be deleted", MessageBoxButtons.OKCancel);
        if (choice != DialogResult.OK) return;

        ctx.Orders.RemoveRange(deleteOrders);
        ctx.SaveChanges();
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        LoadOrders();
        searchBox.Text = string.Empty;
    }

    private void LoadOrders()
    {
        orders = [.. GetAllOrders(ctx)];
        orderGridView.DataSource = orders;
    }

    private void PoButton_Clicked(object sender, EventArgs e)
    {
        orders.Clear();

        var foundOrder = ctx.Orders.FirstOrDefault(o => o.PoNumber == searchBox.Text && !o.isDeleted);
        if (foundOrder is not null)
        {
            orders.Add(foundOrder);
            // SuccessBeep();
        }
        else
            // FailedBeep();


        orders.ResetBindings();
    }

    private async void OnButton_Clicked(object sender, EventArgs e)
    {
        var ctx = new OrderContext();

        var success = uint.TryParse(searchBox.Text, out uint on);
        orders.Clear();

        if (success)
        {
            var foundOrder = await ctx.Orders.FirstOrDefaultAsync(o => o.OrderNumber == on && !o.isDeleted);
            if (foundOrder is not null)
            {
                orders.Add(foundOrder);
                // SuccessBeep();
            }
        }

        orders.ResetBindings();
    }

    private void PrintButton_Clicked(object sender, EventArgs e)
    {
        PrintDocument doc = new();
        doc.PrintPage += PrintPageHandler;

        using (var ctx = new OrderContext())
        {
            GetOpenOrders(ctx)
                .ToList()
                .ForEach(order =>
                {
                    data += order.DisplayOrder();
                });
        }

        try
        {
            doc.Print();
        }
        catch (Exception error)
        {
            MessageBox.Show(
                $"Error while printing: {error.Message}",
                "Printing Error",
                MessageBoxButtons.OK
            );
        }
    }

    private void PrintPageHandler(object sender, PrintPageEventArgs e)
    {
        int charactersOnPage = 0;
        e.Graphics?.MeasureString(
            data,
            new Font("Ariel", 12),
            e.MarginBounds.Size,
            StringFormat.GenericTypographic,
            out charactersOnPage,
            out _
        );

        e.Graphics?.DrawString(
            data,
            new Font("Ariel", 12),
            Brushes.Black,
            e.MarginBounds,
            StringFormat.GenericTypographic
        );

        data = data[charactersOnPage..];
        e.HasMorePages = data.Length > 0;
    }

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        var ctx = new OrderContext();

        Order? order = null;

        if (e.KeyCode == Keys.Enter)
        {
            bool search = uint.TryParse(searchBox.Text, out uint searchNum);

            if (search) {
                order = ctx.Orders.FirstOrDefault(o => o.OrderNumber == searchNum && !o.isDeleted);
            }
            else {
                order = ctx.Orders.FirstOrDefault(o => o.PoNumber == searchBox.Text && !o.isDeleted);
            }

            if (order is not null) {
                orders.Clear();
                orders.Add(order);
                orders.ResetBindings();
            }
        }
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        var orderPage = new OrderPage(null, this);
        orderPage.Show();

        orderPage.OrderSaved += (obj, order) => {
            var context = new OrderContext();
            context.Orders.Add(order);
            context.SaveChanges();
            orders.Clear();
            LoadOrders();
            selectedOrder = null;
        };
    }

    private void UpdateButton_Clicked(object sender, EventArgs e)
    {
        if (selectedOrder is null)
            return;

        var orderPage = new OrderPage(selectedOrder, this);
        orderPage.Show();

        orderPage.OrderSaved += (obj, order) => {
            var context = new OrderContext();
            order.isDeleted = false;
            context.Orders.Update(order);
            context.SaveChanges();
            LoadOrders();
            selectedOrder = null;
        };
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (selectedOrder is not null) {
            selectedOrder.isDeleted = true;
            ctx.Orders.Update(selectedOrder);
            ctx.SaveChanges();
            LoadOrders();      
        }
        else {
            MessageBox.Show("There is no selected Order", "Select an Order", MessageBoxButtons.OK);
        }

    }

    // private void FailedBeep()
    // {
    //     Console.Beep();
    //     Task.Delay(100);
    //     Console.Beep();
    // }

    // private void SuccessBeep()
    // {
    //     Console.Beep();
    // }

    private void OrderGridView_SelectionChanged(object sender, EventArgs e)
    {
        var selectedCellCount = orderGridView.GetCellCount(DataGridViewElementStates.Selected);

        if (selectedCellCount > 0) {
            var selectedRow = orderGridView.SelectedRows;

            if (selectedRow.Count > 0)
                selectedOrder = selectedRow[0].DataBoundItem as Order;
        }
    }
    
    private void ReviveOrder_Clicked(object sender, EventArgs e)
    {
        var foundOrder = searchBox.Text;

    }

    private void QuitButton_Clicked(object sender, EventArgs e) => Environment.Exit(0);

    private static IEnumerable<Order> GetAllOrders(OrderContext ctx) =>
        [.. ctx.Orders.AsNoTracking().Where(o => !o.isDeleted).OrderBy(o => o.OrderNumber), ..ctx.Orders.AsNoTracking().Where(o => o.isDeleted).OrderBy(o => o.OrderNumber)];

    private static IEnumerable<Order> GetOpenOrders(OrderContext ctx) =>
        [.. ctx.Orders.AsNoTracking().Where(o => !o.isDeleted).OrderBy(o => o.OrderNumber)];
}
