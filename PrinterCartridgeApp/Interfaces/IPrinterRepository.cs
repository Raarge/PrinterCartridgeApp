using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.Interfaces
{
    public interface IPrinterRepository
    {
        Printer GetPrinter(int Id);
        IEnumerable<Printer> GetAllPrinters();
        Printer Add(Printer printer);
        Printer Update(Printer printerChanges);
        Printer Delete(int Id);
    }
}
