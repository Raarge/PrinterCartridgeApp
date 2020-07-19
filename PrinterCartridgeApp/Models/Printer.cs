using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrinterCartridgeApp.Models
{
    public class Printer
    {
        [Key]
        public int Printer_ID { get; set; }
        [Required, Display(Name = "Printer Windows ID:")]
        public string Printer_Name { get; set; }
        [Required, Display(Name = "Printer Model:")]
        public string Printer_Model { get; set; }

        public Printer()
        {
            
        }
    }
}
