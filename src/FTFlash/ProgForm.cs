using System.Security;

namespace FTFlash;

public partial class ProgForm : Form
{
    private int ByteCount => ((int)(numericUpDown1.Value * 8)) << 8;

    public ProgForm()
    {
        InitializeComponent();
        UpdateByteCount();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e) => UpdateByteCount();

    private void UpdateByteCount() => lblBytes.Text = $"{ByteCount:N0} bytes";

    private void Progress(string message, double percent = 0)
    {
        progressBar1.Maximum = ByteCount;
        progressBar1.Value = (int)(percent / 100 * progressBar1.Maximum);
        System.Diagnostics.Debug.WriteLine(message);
        lblProgress.Text = message;
    }

    private FtdiSharp.Protocols.SPI? GetCom()
    {
        var devices = FtdiSharp.FtdiDevices.Scan();
        foreach (var device in devices)
        {
            System.Diagnostics.Debug.WriteLine($"Found: {device}");
            if (device.Type == "232H")
            {
                Progress($"FT232H ({device.ID}) connecting...");
                FtdiSharp.Protocols.SPI spiComm = new(device, spiMode: 0, slowDownFactor: 50);
                Progress($"FT232H ({device.ID}) connected");
                return spiComm;
            }
        }

        Progress($"No FT232H found...");
        return null;
    }

    private void LaunchAndSelect(string filePath)
    {
        filePath = Path.GetFullPath(filePath);
        System.Diagnostics.Process.Start("explorer.exe", filePath);
        System.Diagnostics.Process.Start("explorer.exe", $"/select, \"{filePath}\"");
    }

    private void WaitForNotBusy(FtdiSharp.Protocols.SPI com)
    {
        com.CsLow();
        byte statusByte = 0b00000001;
        while ((statusByte & 1) != 0)
        {
            com.Write(0x05);
            statusByte = com.ReadWrite(new byte[] { 0 }).Single();
        }
        com.CsHigh();
    }

    private byte[] ReadPage(FtdiSharp.Protocols.SPI com, int page)
    {
        int address = page * 256;
        byte pageH = (byte)(address >> 8);
        byte pageL = (byte)(address >> 0);

        WaitForNotBusy(com);
        com.CsLow();
        foreach (byte b in new byte[] { 3, pageH, pageL, 0 })
            com.Write(b);
        byte[] bytes = com.ReadBytes(256);
        com.CsHigh();

        return bytes;
    }

    private void btnRead_Click(object sender, EventArgs e)
    {
        FtdiSharp.Protocols.SPI? com = GetCom();
        if (com is null)
            return;

        byte[] bytes = new byte[ByteCount];
        int pageCount = ByteCount / 256;

        for (int i = 0; i < pageCount; i++)
        {
            double percent = (double)i / pageCount * 100;
            Progress($"Reading page {i} of {pageCount} ({percent:0.00}%).", percent);
            byte[] pageBytes = ReadPage(com, i);
            Array.Copy(pageBytes, 0, bytes, i * 256, 256);
        }

        string filename = DateTime.Now.Ticks.ToString() + ".bin";
        File.WriteAllBytes(filename, bytes);
        LaunchAndSelect(filename);

        com.FtdiDevice.Close();
        Progress($"Disconnected.");
    }
}
