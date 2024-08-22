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
    private ScrollView orderView;

    public MainWindow()
    {
        Title = $"Order Controller, {Application.QuitKey} to quit";

        var addLabel = new Label 
        { 
            Text = "Add an Order",
        };
        addBtn = new Button 
        {
            Text = "Add",
            Y = Pos.Bottom(addLabel)
        };
        addBtn.Clicked += Add_Clicked;

        var editLabel = new Label 
        {
            Text = "Edit an Order",
            X = Pos.Center()
        };
        editBtn = new Button 
        {
            Text = "Edit",
            X = Pos.Center(),
            Y = Pos.Bottom(editLabel),
        };

        editBtn.Clicked += Edit_Clicked;

        var removeLabel = new Label 
        {
            Text = "Remove an Order",
            X = Pos.AnchorEnd(20)
        };
        removeBtn = new Button 
        {
            Text = "Remove",
            X = Pos.AnchorEnd(17),
            Y = Pos.Bottom(removeLabel),
        };

        removeBtn.Clicked += Remove_Clicked;

        searchField = new TextField 
        {
            Y = Pos.Bottom(editBtn) + 1,
            Width = Dim.Fill()
        };

        orderView = new ScrollView()
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            X = Pos.Center(),
            Y = Pos.Bottom(searchField)
        };

        Add(editBtn, editLabel, addLabel, addBtn, removeLabel, removeBtn, searchField, orderView);
    
    }

    private void Add_Clicked()
    {

    }

    private void Edit_Clicked()
    {

    }

    private void Remove_Clicked()
    {

    }
}