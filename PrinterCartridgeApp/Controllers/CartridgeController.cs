using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;
using PrinterCartridgeApp.ViewModels;

namespace PrinterCartridgeApp.Controllers
{
    public class CartridgeController : Controller
    {
        private readonly ICartridgeRepository _cartridgeRepository;
        private readonly IPrinterRepository _printerRepository;

        public CartridgeController(ICartridgeRepository cartridgeRepository, IPrinterRepository printerRepository)
        {
            _cartridgeRepository = cartridgeRepository;
            _printerRepository = printerRepository;
        }

        [HttpGet]
        public IActionResult CartridgeAdd()
        {
            var model = new CartridgeViewModel();
            model.PrinterOptions = _printerRepository.GetAllPrinters()
                .Select(o => new SelectListItem(o.Printer_Name, o.Printer_Name));

            model.PrinterModelOptions = _printerRepository.GetAllPrinters()
                .Select(o => new SelectListItem(o.Printer_Name, o.Printer_Model));
            return View(model);
        }

        [HttpPost]
        public IActionResult CartridgeAdd(CartridgeViewModel newcartridge)
        {
            Cartridge currentCartridge = new Cartridge();

            newcartridge.Printer_Model = _printerRepository.GetAllPrinters()
                .Where(o => o.Printer_Name == newcartridge.Printer_Recd_For).Select(o => o.Printer_Model)
                .FirstOrDefault();

            newcartridge.Date_Keyed = DateTime.Now;

            currentCartridge.Cartridge_Number = newcartridge.Cartridge_Number;
            currentCartridge.Printer_Model = newcartridge.Printer_Model;
            currentCartridge.Cartridge_Type = newcartridge.Cartridge_Type;
            currentCartridge.Printer_Recd_For = newcartridge.Printer_Recd_For;
            currentCartridge.Date_Keyed = newcartridge.Date_Keyed;

            _cartridgeRepository.Add(currentCartridge);
            ModelState.Clear();
            return RedirectToAction("CartridgeAdd", "Cartridge");
        }

        [HttpGet]
        public IActionResult CartridgeIssue()
        {
            var model = new CartridgeViewModel();

            model.PrinterOptions = _printerRepository.GetAllPrinters()
                .Select(o => new SelectListItem(o.Printer_Name, o.Printer_Name));
            return View(model);
        }

    }
}
