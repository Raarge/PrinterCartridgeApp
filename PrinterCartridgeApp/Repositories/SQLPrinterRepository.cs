using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrinterCartridgeApp.Data;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.Repositories
{
    public class SQLPrinterRepository : IPrinterRepository
    {
        private readonly PrinterCartridgeDBContext context;

        public SQLPrinterRepository(PrinterCartridgeDBContext context)
        {
            this.context = context;
        }

        public Printer GetPrinter(int Id)
        {
            return context.Printers.Find(Id);
        }

        public IEnumerable<Printer> GetAllPrinters()
        {
            return context.Printers;
        }

        public Printer Add(Printer printer)
        {
            context.Printers.Add(printer);
            context.SaveChanges();
            return printer;
        }

        public Printer Update(Printer printerChanges)
        {
            var printer = context.Printers.Attach(printerChanges);
            printer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return printerChanges;
        }

        public Printer Delete(int Id)
        {
            Printer printer = context.Printers.Find(Id);
            if (printer != null)
            {
                context.Printers.Remove(printer);
                context.SaveChanges();
            }

            return printer;
        }
    }
}
