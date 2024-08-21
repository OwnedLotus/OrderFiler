using Terminal.Gui;

namespace OrderFiler.Models.Windows;

class MainWindow : Window 
{

    // button enter
    private Button addBtn;

    // button remove
    private Button removeBtn;

    // button edit
    private Button editBtn;

    // search bar
    private TextField searchField;

    // auto updating scroll view
    private ScrollBarView orderView;

    public MainWindow()
    {
        Title = $"Order Controller, {Application.QuitKey} to quit";

        var editLabel = new Label 
        {
            Text = "Edit an Order",
            X = Pos.Center()
        };
        editBtn = new Button 
        {
            Text = "Edit",
            Y = Pos.Bottom(editLabel),
            Width = Dim.Fill()
        };

        var addLabel = new Label 
        { 
            Text = "Add an Order",
            X = Pos.Left(editLabel)
        };
        addBtn = new Button 
        {
            Text = "Add",
            X = Pos.Left(editLabel),
            Y = Pos.Bottom(addLabel),
            Width = Dim.Fill()
        };

        var removeLabel = new Label 
        {
            Text = "Remove an Order",
            X = Pos.Right(editLabel)
        };
        removeBtn = new Button 
        {
            Text = "Remove",
            X = Pos.Right(editBtn),
            Y = Pos.Bottom(removeLabel),
            Width = Dim.Fill()
        };

        orderView = new ScrollBarView
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            X = Pos.Center()
        };
        searchField = new TextField 
        {
            Text = "Search...",
            X = Pos.Center(),
            Y = Pos.Bottom(editBtn),
        };

        Add(editLabel, editBtn, addLabel, addBtn, removeLabel, removeBtn, searchField);
    }
}