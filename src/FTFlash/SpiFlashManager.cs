using FtdiSharp;

namespace FTFlash;

public class SpiFlashManager
{
    public readonly FtdiSharp.Protocols.SPI SpiComm;
    public readonly FtdiDevice Device;

    public SpiFlashManager(FtdiDevice device, int slowDownFactor = 50)
    {
        Device = device;
        System.Diagnostics.Debug.WriteLine($"FT232H ({device.ID}) connecting...");
        SpiComm = new(device, spiMode: 0, slowDownFactor: slowDownFactor);
        System.Diagnostics.Debug.WriteLine($"FT232H ({device.ID}) connected");
    }

    public bool ConnectionIsActive(double timeoutSeconds = 2)
    {
        Task task = Task.Run(() =>
        {
            try
            {
                WaitForNotBusy();
            }
            catch (FtdiSharp.FTD2XX.FT_EXCEPTION ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        });

        return task.Wait(TimeSpan.FromSeconds(timeoutSeconds));
    }

    public void Disconnect()
    {
        System.Diagnostics.Debug.WriteLine("Disconnecting...");
        SpiComm.Close();
    }

    private void WaitForNotBusy()
    {
        SpiComm.CsLow();
        byte statusByte = 0b00000001;
        while ((statusByte & 1) != 0)
        {
            SpiComm.Write(0x05);
            statusByte = SpiComm.ReadWrite(new byte[] { 0 }).Single();
        }
        SpiComm.CsHigh();
    }

    public ChipID ReadIDs()
    {
        System.Diagnostics.Debug.WriteLine("Reading device IDs...");

        WaitForNotBusy();
        SpiComm.CsLow();
        foreach (byte b in new byte[] { 0x90, 0, 0, 0 })
            SpiComm.Write(b);
        byte[] ids1 = SpiComm.ReadWrite(new byte[] { 0, 0 });
        SpiComm.CsHigh();

        WaitForNotBusy();
        SpiComm.CsLow();
        foreach (byte b in new byte[] { 0x4B, 0, 0, 0, 0 })
            SpiComm.Write(b);
        byte[] ids2 = SpiComm.ReadBytes(8);
        SpiComm.CsHigh();

        WaitForNotBusy();
        SpiComm.CsLow();
        SpiComm.Write(0x9F);
        byte[] ids3 = SpiComm.ReadBytes(3);
        SpiComm.CsHigh();

        return new ChipID()
        {
            Manufacturer = ids1[0],
            Device = ids1[1],
            Unique = ids2,
            JEDEC = ids3,
        };
    }

    public void Erase()
    {
        System.Diagnostics.Debug.WriteLine("Erasing chip...");

        WaitForNotBusy();

        SpiComm.CsLow();
        SpiComm.Write(6);
        SpiComm.CsHigh();

        WaitForNotBusy();

        SpiComm.CsLow();
        SpiComm.Write(0xC7);
        SpiComm.CsHigh();

        WaitForNotBusy();
    }

    public void WritePage(int page, byte[] bytes)
    {
        System.Diagnostics.Debug.WriteLine($"Writing {bytes.Length} bytes to address {page}...");

        WaitForNotBusy();

        SpiComm.CsLow();
        SpiComm.Write(6);
        SpiComm.CsHigh();

        WaitForNotBusy();

        byte address1 = (byte)(page >> 8);
        byte address2 = (byte)(page >> 0);
        byte address3 = 0;

        SpiComm.CsLow();
        foreach (byte b in new byte[] { 2, address1, address2, address3 })
            SpiComm.Write(b);
        foreach (byte b in bytes)
            SpiComm.Write(b);
        SpiComm.CsHigh();

        WaitForNotBusy();
    }

    public byte[] ReadPage(int page, int count = 256)
    {
        if (count > 256)
            throw new ArgumentException("A single read cannot exceed 256 bytes");

        System.Diagnostics.Debug.WriteLine($"Reading {count} bytes to address {page}...");

        WaitForNotBusy();

        byte address1 = (byte)(page >> 8);
        byte address2 = (byte)(page >> 0);
        byte address3 = 0;

        SpiComm.CsLow();

        foreach (byte b in new byte[] { 3, address1, address2, address3 })
            SpiComm.Write(b);

        byte[] bytes = SpiComm.ReadBytes(256);
        SpiComm.CsHigh();
        WaitForNotBusy();

        return bytes;
    }
}
