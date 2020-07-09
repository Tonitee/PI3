using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAula10.Data;
using AtividadeAula10.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAula10.Services
{

    public class JogoService
    {
        private readonly AtividadeAula10Context _context;

        public JogoService(AtividadeAula10Context context)
        {
            _context = context;
        }

        public async Task InserirAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _context.Produto.Include(prod => prod.Plataforma).OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Produto> getProdutoByIdAsync(int id)
        {
            return await _context.Produto.Include(prod => prod.Plataforma).FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task ExcluirAsync(int id)
        {
            var prod = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(prod);
            await _context.SaveChangesAsync();
        }

        public async Task EditarAsync(Produto produto)
        {
            bool EncontrouProduto = await _context.Produto.AnyAsync(prod => prod.Id == produto.Id);
            if (EncontrouProduto)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch(Exception e)
                {

                }
            }
        }
    }
}
