using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.ViewModels
{
    public class CartridgeViewModel
    {
        public IEnumerable<SelectListItem> PrinterOptions { get; set; }

        public IEnumerable<SelectListItem> PrinterModelOptions { get; set; }

        [Required, Display(Name = "Cartridge Number:")]
        public string Cartridge_Number { get; set; }
        [Required, Display(Name = "Printer Model:")]
        public string Printer_Model { get; set; }
        [Required, Display(Name = "Cartridge Type:")]
        public string Cartridge_Type { get; set; }
        [Required, Display(Name = "Printer Name Received For:")]
        public string Printer_Recd_For { get; set; }
        [Required]
        public DateTime Date_Keyed { get; set; }

    }
}
