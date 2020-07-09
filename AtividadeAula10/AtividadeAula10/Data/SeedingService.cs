using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAula10.Models;

namespace AtividadeAula10.Data
{
    public class SeedingService
    {
        private AtividadeAula10Context _context;

        public SeedingService(AtividadeAula10Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if( _context.Produto.Any())
            {
                return;
            }

            Categoria cat01 = new Categoria(1, "PC");
            Categoria cat02 = new Categoria(2, "PS4");
            Categoria cat03 = new Categoria(3, "Xbox One");

            _context.Plataforma.AddRange(cat01, cat02, cat03);

            _context.SaveChanges();
        }
    }
}
