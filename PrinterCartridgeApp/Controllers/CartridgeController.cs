using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;

namespace PrinterCartridgeApp.Controllers
{
    public class CartridgeController : Controller
    {
        private readonly ICartridgeRepository _cartridgeRepository;

        public CartridgeController(ICartridgeRepository cartridgeRepository)
        {
            _cartridgeRepository = cartridgeRepository;
        }

        [HttpGet]
        public IActionResult CartridgeAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CartridgeAdd(Cartridge cartridge)
        {
            cartridge.Date_Keyed = DateTime.Now;
            _cartridgeRepository.Add(cartridge);
            ModelState.Clear();
            return View();
        }
    }
}
