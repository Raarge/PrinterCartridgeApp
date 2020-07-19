using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrinterCartridgeApp.Data;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.Controllers
{
    public class PrinterController : Controller
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        [HttpGet]
        public IActionResult PrinterAdd()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult PrinterAdd(Printer newPrinter)
        {
            _printerRepository.Add(newPrinter);
            ModelState.Clear();
            return View();
        }
    }
}
