using PrinterCartridgeApp.Models;
using System.Collections.Generic;

namespace PrinterCartridgeApp.Interfaces
{
    public interface ICartridgeRepository
    {
        Cartridge GetCartridge(int Id);
        IEnumerable<Cartridge> GetAllCartridges();
        Cartridge Add(Cartridge cartridge);
        Cartridge Update(Cartridge updateCartridge);
        Cartridge Delete(int Id);

    }
}
