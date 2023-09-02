namespace FTFlash;

public partial class ProgForm : Form
{
    private int PageCount => ((int)(numericUpDown1.Value * 2)) << 8;

    public ProgForm()
    {
        InitializeComponent();
        UpdateByteCount();
        this.Select();
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

    private SpiFlashManager? GetFlashMan()
    {
        System.Diagnostics.Debug.WriteLine("Scanning for FTDI devices...");
        List<FtdiSharp.FtdiDevice> ft232s = new();
        foreach (FtdiSharp.FtdiDevice device in FtdiSharp.FtdiDevices.Scan())
        {
            System.Diagnostics.Debug.WriteLine($"Found: {device}");
            if (device.Type == "232H")
            {
                ft232s.Add(device);
            }
        }

        if (!ft232s.Any())
        {
            Progress($"No FT232H found...");
            return null;
        }

        FtdiSharp.FtdiDevice firstDevice = ft232s.First();
        Progress($"FT232H ({firstDevice.ID}) connecting...");
        SpiFlashManager flashMan = new(firstDevice);

        if (flashMan.ConnectionIsActive())
        {
            Progress($"FT232H ({firstDevice.ID}) connected");
            return flashMan;
        }
        else
        {
            Progress($"SPI connection error");
            flashMan.Disconnect();
            MessageBox.Show("A FT232H was found but the SPI chip did not respond to it. " +
                "Ensure your wiring and power configuration is correct.", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return null;
        }
    }

    private void LaunchAndSelect(string filePath)
    {
        filePath = Path.GetFullPath(filePath);
        System.Diagnostics.Process.Start("explorer.exe", filePath);
        System.Diagnostics.Process.Start("explorer.exe", $"/select, \"{filePath}\"");
    }

    private void btnRead_Click(object sender, EventArgs e)
    {
        SpiFlashManager? com = GetFlashMan();
        if (com is null)
            return;

        byte[] bytes = new byte[PageCount * 256];

        for (int i = 0; i < PageCount; i++)
        {
            double percent = (double)i / PageCount * 100;
            Progress($"Reading page {i} of {PageCount} ({percent:0.00}%).", percent);

            byte[] pageBytes = com.ReadPage(i);
            Array.Copy(pageBytes, 0, bytes, i * 256, 256);
        }

        string filename = DateTime.Now.Ticks.ToString() + ".bin";
        File.WriteAllBytes(filename, bytes);
        LaunchAndSelect(filename);

        com.Disconnect();
        Progress($"Disconnected.");
    }

    private void btnWrite_Click(object sender, EventArgs e)
    {
        OpenFileDialog diag = new() { Filter = "BIN files (*.bin)|*.bin|All files (*.*)|*.*" };
        if (diag.ShowDialog() != DialogResult.OK)
            return;
        byte[] fileBytes = File.ReadAllBytes(diag.FileName);

        SpiFlashManager? com = GetFlashMan();
        if (com is null)
            return;

        Progress($"Erasing chip...");
        com.Erase();

        int pagesToWrite = fileBytes.Length / 256;
        for (int i = 0; i < pagesToWrite; i++)
        {
            double percent = (double)i / pagesToWrite * 100;
            Progress($"Writing page {i} of {pagesToWrite} ({percent:0.00}%).", percent);
            byte[] pageBytes = new byte[256];
            Array.Copy(fileBytes, i * 256, pageBytes, 0, 256);
            com.WritePage(i, pageBytes);
        }

        com.Disconnect();
        Progress($"Disconnected.");
    }
}
