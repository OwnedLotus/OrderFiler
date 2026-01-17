




namespace OrderManager.Pages;

partial class HomePage
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1280, 720);
        this.Text = "Order Manager";


        printButton = new()
        {
            Name = "printButton",
            Text = "Print Database",
            AutoSize = true,
            Location = new Point(50, 10)
        };
        printButton.Click += PrintButton_Clicked;

        orderGridView = new()
        {
            Name = "orderGridView",
            Location = new Point(200, 10),
            Size = new Size(650, 500)
        };
        orderGridView.SelectionChanged += OrderGridView_SelectionChanged;

        searchLabel = new()
        {
            Name = "searchLabel",
            Location = new Point(900, 10),
            Text = "Search Box",
            AutoSize = true
        };
        searchBox = new()
        {
            Name = "searchBox",
            Location = new Point(900, 30)
        };
        searchBox.KeyDown += SearchBox_KeyDown;
        onButton = new()
        {
            Name = "onButton",
            Location = new Point(900, 60),
            Text = "Search Order Number",
            AutoSize = true
        };
        onButton.Click += OnButton_Clicked;

        poButton = new()
        {
            Name = "poButton",
            Location = new Point(900, 90),
            Text = "Search Purchase Order",
            AutoSize = true
        };
        poButton.Click += PoButton_Clicked;

        clearButton= new()
        {
            Name = "clearButton",
            Location = new Point(900, 120),
            Text = "Clear Search",
            AutoSize = true
        };
        clearButton.Click += ClearButton_Clicked;

        addButton = new()
        {
            Name = "addButton",
            Location = new Point(200, 540),
            Text = "Add Order",
            AutoSize = true,
        };

        addButton.Click += AddButton_Clicked;

        updateButton = new()
        {
            Name = "updateButton",
            Location = new Point(350, 540),
            Text = "Update Order",
            AutoSize = true,
        };

        updateButton.Click += UpdateButton_Clicked;

        deleteButton = new()
        {
            Name = "deleteButton",
            Location = new Point(500, 540),
            Text = "Delete Button",
            AutoSize = true,
        };

        deleteButton.Click += DeleteButton_Clicked;

        quitButton = new()
        {
            Name = "quitButton",
            Location = new Point(700, 540),
            Text = "Quit",
            AutoSize = true
        };
        quitButton.Click += QuitButton_Clicked;

        Controls.Add(printButton);
        Controls.Add(orderGridView);
        Controls.Add(searchLabel);
        Controls.Add(searchBox);
        Controls.Add(onButton);
        Controls.Add(poButton);
        Controls.Add(clearButton);
        Controls.Add(addButton);
        Controls.Add(updateButton);
        Controls.Add(deleteButton);
        Controls.Add(quitButton);
    }


    Button printButton;
    DataGridView orderGridView;

    Label searchLabel;
    TextBox searchBox;
    Button onButton;
    Button poButton;
    Button clearButton;

    Button addButton;
    Button updateButton;
    Button deleteButton;
    Button quitButton;
}
