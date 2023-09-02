namespace FTFlash;

public partial class TestForm : Form
{
    SpiFlashManager? FlashMan = null;

    public TestForm()
    {
        InitializeComponent();
        Disconnect();
        btnConnect_Click(this, EventArgs.Empty);
        FormClosing += (s, e) => Disconnect();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        if (FlashMan is null)
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
        FlashMan?.Disconnect();
        FlashMan = null;
        lblConnection.Text = "Disconnected";
        btnConnect.Text = "Scan for FT232H Devices";
    }

    void ScanAndConnect()
    {
        System.Diagnostics.Debug.WriteLine("Scanning for FTDI devices...");
        foreach (FtdiSharp.FtdiDevice device in FtdiSharp.FtdiDevices.Scan())
        {
            System.Diagnostics.Debug.WriteLine($"Found: {device}");
            if (device.Type == "232H")
            {
                lblConnection.Text = $"FT232H ({device.ID}) connecting...";
                FlashMan = new(device);
                lblConnection.Text = $"FT232H ({device.ID}) connected";
                btnConnect.Text = "Disconnect";
                return;
            }
        }

        lblConnection.Text = $"No FT232H found...";
    }

    private void btnReadIDs_Click(object sender, EventArgs e)
    {
        if (FlashMan is null)
            return;

        ChipID ids = FlashMan.ReadIDs();
        lblID1.Text = $"Manufacturer: 0x{ids.Manufacturer:X}";
        lblID2.Text = $"Device: 0x{ids.Device:X}";
        lblID3.Text = "Unique: " + string.Join("", ids.Unique.Select(x => $"{x:X2}")).ToString();
        lblID4.Text = "JEDEC: " + string.Join(", ", ids.JEDEC.Select(x => $"0x{x:X2}")).ToString();
    }

    private void btnErase_Click(object sender, EventArgs e)
    {
        FlashMan?.Erase();
    }

    private void btnWritePage_Click(object sender, EventArgs e)
    {
        byte[] bytes = Enumerable.Range(Random.Shared.Next(100), 256).Select(x => (byte)x).ToArray();
        lblWrite.Text = $"First byte: {bytes.First()}";
        int address = (int)nudPage.Value * 256;
        FlashMan?.WritePage(address, bytes);
    }

    private void btnReadPage_Click(object sender, EventArgs e)
    {
        if (FlashMan is null)
            return;

        int address = (int)nudPage.Value * 256;
        byte[] bytes = FlashMan.ReadPage(address, 256);
        richTextBox1.Text = string.Join(", ", bytes.Select(x => $"{x}")).ToString();
    }
}
