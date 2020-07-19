using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.Data
{
    public class PrinterCartridgeDBContext : DbContext
    {
        public PrinterCartridgeDBContext(DbContextOptions<PrinterCartridgeDBContext> options) : base(options)
        {

        }

        public DbSet<Printer> Printers { get; set; }
        public DbSet<Cartridge> Cartridges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("PrinterGastonia");
                entity.Property(e => e.Printer_ID).ValueGeneratedOnAdd();
                
            });

            modelBuilder.Entity<Cartridge>(entity =>
            {
                entity.ToTable("PrinterCartridge");
                entity.Property(e => e.Cartridge_ID).ValueGeneratedOnAdd();
                
            });

        }
    }
}
