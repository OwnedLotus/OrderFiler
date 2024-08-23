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

    private AddWindow addWindow;
    private EditWindow editWindow;
    private RemoveWindow removeWindow;

    public MainWindow()
    {
        addWindow = new AddWindow("Add Window") {
            CanFocus = true
        };
        editWindow = new EditWindow("Edit Window") {
            CanFocus = true
        };
        removeWindow = new RemoveWindow("Remove Window") {
            CanFocus = true
        };


        Title = $"Order Filer, {Application.QuitKey} to quit";

        var addLabel = new Label 
        { 
            Text = "Add an Order",
        };
        addBtn = new Button 
        {
            Text = "Add",
            Y = Pos.Bottom(addLabel)
        };
        addBtn.Accept += (s, e) => {
            addLabel.Text = "Button Pressed";

            // if(Application.OnKeyDown(Key.D)
            RemoveAll();
            addWindow.SuperView.SetFocus();
            
        };

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

        editBtn.Accept += (s,e) => {
            editLabel.Text = "Button Pressed";
        };

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

        removeBtn.Accept += (s, e) => {
            removeLabel.Text = "Button Pressed";
        };

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
}