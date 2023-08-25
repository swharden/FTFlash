namespace FTFlash;

public partial class Form1 : Form
{
    FtdiSharp.Protocols.SPI? SpiComm = null;

    public Form1()
    {
        InitializeComponent();
        Disconnect();
        btnConnect_Click(this, EventArgs.Empty);
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
        lblConnection.Text = "Disconnected";
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
                lblConnection.Text = $"FT232H ({device.ID}) connecting...";
                SpiComm = new(device, spiMode: 0, slowDownFactor: 500);
                //SpiComm.ClockIdlesLow = true;
                //SpiComm.TransmitOnRisingClock = false;
                //SpiComm.SampleOnRisingClock = true;
                lblConnection.Text = $"FT232H ({device.ID}) connected";
                btnConnect.Text = "Disconnect";
                return;
            }
        }

        lblConnection.Text = $"No FT232H found...";
    }

    private void btnReadIDs_Click(object sender, EventArgs e)
    {
        if (SpiComm is null)
            return;

        SpiComm.CsLow();
        SpiComm.CsHigh();

        SpiComm.CsLow();
        SpiComm.Write(0x90);
        SpiComm.Write(0);
        SpiComm.Write(0);
        SpiComm.Write(0);

        System.Threading.Thread.Sleep(1);

        byte[] dummy = { 0, 0 };
        byte[] bytes = SpiComm.ReadWrite(dummy);
        SpiComm.CsHigh();

        lblIDs.Text = string.Join(", ", bytes.Select(x => $"{x}")).ToString();
    }
}
