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
            return View(model);
        }

        [HttpPost]
        public IActionResult CartridgeAdd(Cartridge cartridge)
        {
            cartridge.Date_Keyed = DateTime.Now;
            _cartridgeRepository.Add(cartridge);
            ModelState.Clear();
            return RedirectToAction("CartridgeAdd", "Cartridge");
        }
    }
}
