# FTFlash

**FTFlash is a Windows application for reading and writing FLASH memory in SPI chips using a FT232H.** A voltage regulator is required to step 5V down to 3.3V, but otherwise no external components are required. FTFlash allows for manual inspection of device information and reading/writing individual memory addresses as well as dumping/programming the entire memory to/from binary files on disk.

### Wiring

![](dev/wiring/wiring.png)

### Device and Memory Inspection

![](dev/screenshot.png)

### Full Chip Read/Write

![](dev/screenshot2.png)

## Resources

* [FtdiSharp](https://github.com/swharden/FtdiSharp)

* [W25Q32 Datasheet](https://www.elinux.org/images/f/f5/Winbond-w25q32.pdf)

* [FT232H Breakout Board](https://www.adafruit.com/product/2264) (Adafruit) has 3.3V built in and USBC

* [FT232H Breakout Board](https://www.amazon.com/dp/B09KGT5TGJ/) (Amazon) is cheaper with Prime shipping but has a less convenient PCB layout and silkscreen