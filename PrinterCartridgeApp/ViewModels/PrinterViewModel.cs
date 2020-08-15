using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.ViewModels
{
    public class PrinterViewModel
    {
        public IEnumerable<SelectListItem> PrinterReturnByName { get; set; }

        public List<Printer> Printers { get; set; }

        public Printer PrinterSelected { get; set; }

        [Key]
        public int Printer_ID { get; set; }
        [Required, Display(Name = "Printer Windows ID:")]
        public string Printer_Name { get; set; }
        [Required, Display(Name = "Printer Model:")]
        public string Printer_Model { get; set; }
    }
}
