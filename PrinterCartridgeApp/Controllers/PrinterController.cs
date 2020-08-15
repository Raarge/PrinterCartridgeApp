using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrinterCartridgeApp.Data;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;
using PrinterCartridgeApp.ViewModels;

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

        [HttpGet]
        public IActionResult PrinterDelete()
        {
            var model = new PrinterViewModel();

            model.PrinterReturnByName = _printerRepository.GetAllPrinters().Select(o => new SelectListItem(o.Printer_Name, o.Printer_ID.ToString()));

            return View(model);
        }

        [HttpGet]
        public IActionResult GetPrinter(int printerID)
        {
            var model = new PrinterViewModel();

            model.PrinterSelected = _printerRepository.GetPrinter(printerID);

            return Json(model);
        }

        [HttpPost]
        public IActionResult DeletePrinter(int printerID)
        {
            _printerRepository.Delete(printerID);

            return Json(printerID);
        }

        [HttpGet]
        public IActionResult PrinterList()
        {
            var model = new PrinterViewModel();

            model.Printers = _printerRepository.GetAllPrinters().Where(o => o.Printer_Model != "NA").ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult GetPrintersList()
        {
            
            var printers = _printerRepository.GetAllPrinters().Where(o=>o.Printer_Model != "NA");

            return Json(printers);
        }

    }
}
