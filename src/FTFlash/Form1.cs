namespace FTFlash;

public partial class Form1 : Form
{
    FtdiSharp.Protocols.SPI? SpiComm = null;

    public Form1()
    {
        InitializeComponent();
        Disconnect();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        if (SpiComm is null)
        {
            ScanAndConnect();
        }
        else
        {
            Disconnect();
        }
    }

    void Disconnect()
    {
        SpiComm?.Close();
        SpiComm = null;
        Text = "Disconnected";
        btnConnect.Text = "Scan for FT232H Devices";
    }

    void ScanAndConnect()
    {
        System.Diagnostics.Debug.WriteLine("Scanning for FTDI devices...");
        var devices = FtdiSharp.FtdiDevices.Scan();
        foreach (var device in devices)
        {
            System.Diagnostics.Debug.WriteLine($"Found: {device}");
            if (device.Type == "232H")
            {
                Text = $"FT232H ({device.ID}) connecting...";
                SpiComm = new(device);
                Text = $"FT232H ({device.ID}) connected";
                btnConnect.Text = "Disconnect";
                return;
            }
        }

        Text = $"No FT232H found...";
    }
}
