using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAula10.Data;
using AtividadeAula10.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAula10.Services
{

    public class CategoriaService
    {
        private readonly AtividadeAula10Context _context;

        public CategoriaService(AtividadeAula10Context context)
        {
            _context = context;
        }

        public async Task InserirAsync(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await _context.Plataforma.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _context.Plataforma.FirstOrDefaultAsync(cat => cat.Id == id);
        }

        public async Task EditarAsync(Categoria categoria)
        {
            bool EncontrouCategoria = await _context.Plataforma.AnyAsync(cat => cat.Id == categoria.Id);
            if (EncontrouCategoria)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                }
            }
        }

        public async Task ExcluirAsync(int id)
        {
            var cat = await GetCategoriaByIdAsync(id);
            _context.Plataforma.Remove(cat);
            await _context.SaveChangesAsync();
        }

    }
}
