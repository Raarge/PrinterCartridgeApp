using PrinterCartridgeApp.Data;
using PrinterCartridgeApp.Interfaces;
using PrinterCartridgeApp.Models;
using System.Collections.Generic;

namespace PrinterCartridgeApp.Repositories
{
    public class SQLCartridgeRepository : ICartridgeRepository
    {
        private readonly PrinterCartridgeDBContext context;

        public SQLCartridgeRepository(PrinterCartridgeDBContext context)
        {
            this.context = context;
        }
        public Cartridge GetCartridge(int Id)
        {
            return context.Cartridges.Find(Id);
        }

        public IEnumerable<Cartridge> GetAllCartridges()
        {
            return context.Cartridges;
        }

        public Cartridge Add(Cartridge cartridge)
        {
            context.Cartridges.Add(cartridge);
            context.SaveChanges();
            return cartridge;
        }

        public Cartridge Update(Cartridge cartridgeChanges)
        {
            var cartridge = context.Cartridges.Attach(cartridgeChanges);
            cartridge.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return cartridgeChanges;
        }

        public Cartridge Delete(int Id)
        {
            Cartridge cartridge = context.Cartridges.Find(Id);
            if (cartridge != null)
            {
                context.Cartridges.Remove(cartridge);
                context.SaveChanges();
            }

            return cartridge;
        }
    }
}
