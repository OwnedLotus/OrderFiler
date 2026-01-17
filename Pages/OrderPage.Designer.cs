
namespace CompanyManager.Pages;

partial class OrderPage
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
        this.Text = "Orders";

        orderNumLabel = new()
        {
            Name = "orderNumLabel",
            Text = "Order Number",
            AutoSize = true,
            Location = new Point(300, 10)
        };
        orderNumBox = new()
        {
            Name = "orderNumBox",
            Location = new Point(300, 30)
        };
        poNumLabel = new()
        {
            Name = "poNumLabel",
            Text = "PO Number",
            AutoSize = true,
            Location = new Point(300, 60)
        };
        poNumBox = new()
        {
            Name = "poNumBox",
            Location = new Point(300, 80)
        };
        pulledLabel = new()
        {
            Name = "pulledLabel",
            Text = "Is Pulled?",
            AutoSize = true,
            Location = new Point(300, 110)
        };
        pulledCheckBox = new()
        {
            Name = "pulledCheckBox",
            Location = new Point(450, 110),
            Checked = false
        };

        shippingMethodLabel = new()
        {
            Name = "shippingMethodLabel",
            Location = new Point(600, 10),
            AutoSize = true,
            Text = "Shipping method"
        };

        shippingMethodBox = new()
        {
            Name = "shippingMethodBox",
            Location = new Point(600, 30),
            Size = new Size(90, 100)
        };


        saveButton = new()
        {
            Name = "saveButton",
            Location = new Point(800, 10),
            AutoSize = true,
            Text = "Save"
        };
        saveButton.Click += SaveButton_Clicked;

        cancelButton = new()
        {
            Name = "cancelButton",
            Location = new Point(800, 50),
            AutoSize = true,
            Text = "Quit"
        };

        cancelButton.Click += CancelButton_Clicked;

        Controls.Add(orderNumLabel);
        Controls.Add(orderNumBox);
        Controls.Add(poNumLabel);
        Controls.Add(poNumBox);
        Controls.Add(pulledLabel);
        Controls.Add(pulledCheckBox);
        Controls.Add(shippingMethodLabel);
        Controls.Add(shippingMethodBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);

    }


    Label orderNumLabel;
    TextBox orderNumBox;
    Label poNumLabel;
    TextBox poNumBox;
    Label pulledLabel;
    CheckBox pulledCheckBox;
    Label shippingMethodLabel;
    ComboBox shippingMethodBox;
    Button saveButton;
    Button cancelButton;


    // bool isPulled,
    //     uint orderNumber,
    //     string poNumber,
    //     ShippingMethod method,
}