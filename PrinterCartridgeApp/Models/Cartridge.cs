using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterCartridgeApp.Models
{
    public class Cartridge
    {
        

        [Key]
        [Display(Name = "Cartridge ID:")]
        public int Cartridge_ID { get; set; }
        [Required, Display(Name = "Cartridge Number:")]
        public string Cartridge_Number { get; set; }
        [Required, Display(Name = "Printer Model:")]
        public string Printer_Model { get; set; }
        [Required, Display(Name = "Catridge Type:")]
        public string Cartridge_Type { get; set; }
        [Required, Display(Name = "Printer Received For:")]
        public string Printer_Recd_For { get; set; }
        [Required, Display(Name = "Date Received:")]
        public DateTime Date_Keyed { get; set; }
        public string Printer_Used_For { get; set; }
        public DateTime? Date_Used { get; set; }
    }
}
