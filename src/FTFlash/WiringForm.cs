using System.Diagnostics;

namespace FTFlash;

public partial class WiringForm : Form
{
    public WiringForm()
    {
        InitializeComponent();
        button2.Select();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string url = "https://swharden.com/blog/2023-08-24-ft232h-spi-flash/";
        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Close();
    }
}
