using System.Security;

namespace FTFlash;

public partial class ProgForm : Form
{
    private int PageCount => ((int)(numericUpDown1.Value * 2)) << 8;

    public ProgForm()
    {
        InitializeComponent();
        UpdateByteCount();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e) => UpdateByteCount();

    private void UpdateByteCount() => lblBytes.Text = $"{PageCount:N0} pages ({PageCount * 256:N0} bytes)";

    private void Progress(string message, double percent = 0)
    {
        progressBar1.Maximum = PageCount;
        progressBar1.Value = (int)(percent / 100 * progressBar1.Maximum);
        System.Diagnostics.Debug.WriteLine(message);
        lblProgress.Text = message;
        Application.DoEvents();
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
                FtdiSharp.Protocols.SPI spiComm = new(device, spiMode: 0);
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

    private void Erase(FtdiSharp.Protocols.SPI com)
    {
        WaitForNotBusy(com);

        com.CsLow();
        com.Write(6);
        com.CsHigh();

        com.CsLow();
        com.Write(0xC7);
        com.CsHigh();

        WaitForNotBusy(com);
    }

    private byte[] WritePage(FtdiSharp.Protocols.SPI com, int page, byte[] bytes)
    {
        if (bytes.Length > 256)
            throw new InvalidOperationException();

        byte pageH = (byte)(page >> 8);
        byte pageL = (byte)(page >> 0);

        WaitForNotBusy(com);

        com.CsLow();
        com.Write(6);
        com.CsHigh();

        com.CsLow();
        foreach (byte b in new byte[] { 2, pageH, pageL, 0 })
            com.Write(b);
        foreach (byte b in bytes)
            com.Write(b);
        com.CsHigh();

        return bytes;
    }

    private byte[] ReadPage(FtdiSharp.Protocols.SPI com, int page)
    {
        byte pageH = (byte)(page >> 8);
        byte pageL = (byte)(page >> 0);

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

        byte[] bytes = new byte[PageCount * 256];

        for (int i = 0; i < PageCount; i++)
        {
            double percent = (double)i / PageCount * 100;
            Progress($"Reading page {i} of {PageCount} ({percent:0.00}%).", percent);
            byte[] pageBytes = ReadPage(com, i);
            Array.Copy(pageBytes, 0, bytes, i * 256, 256);
        }

        string filename = DateTime.Now.Ticks.ToString() + ".bin";
        File.WriteAllBytes(filename, bytes);
        LaunchAndSelect(filename);

        com.FtdiDevice.Close();
        Progress($"Disconnected.");
    }

    private void btnWrite_Click(object sender, EventArgs e)
    {
        OpenFileDialog diag = new() { Filter = "BIN files (*.bin)|*.bin|All files (*.*)|*.*" };
        if (diag.ShowDialog() != DialogResult.OK)
            return;
        byte[] fileBytes = File.ReadAllBytes(diag.FileName);

        FtdiSharp.Protocols.SPI? com = GetCom();
        if (com is null)
            return;

        Progress($"Erasing chip...");
        Erase(com);

        int pagesToWrite = fileBytes.Length / 256;
        for (int i = 0; i < pagesToWrite; i++)
        {
            double percent = (double)i / pagesToWrite * 100;
            Progress($"Writing page {i} of {pagesToWrite} ({percent:0.00}%).", percent);
            byte[] pageBytes = new byte[256];
            Array.Copy(fileBytes, i * 256, pageBytes, 0, 256);
            WritePage(com, i, pageBytes);
        }

        com.FtdiDevice.Close();
        Progress($"Disconnected.");
    }
}
