using System;
using System.Collections.Generic;
namespace FTFlash;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) => new TestForm().ShowDialog();

    private void button2_Click(object sender, EventArgs e) => new ProgForm().ShowDialog();
}
