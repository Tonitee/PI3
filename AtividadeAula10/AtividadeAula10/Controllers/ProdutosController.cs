using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtividadeAula10.Data;
using AtividadeAula10.Models;
using AtividadeAula10.Services;
using AtividadeAula10.Models.ViewModels;

namespace AtividadeAula10.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AtividadeAula10Context _context;

        private readonly JogoService _jogoService;
        private readonly CategoriaService _categoriaService;
        /*
        public ProdutosController(AtividadeAula10Context context)
        {
            _context = context;
        }
        */

        public ProdutosController(JogoService jogoService, CategoriaService categoriaService)
        {
            _jogoService = jogoService;
            _categoriaService = categoriaService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            //         return View(await _context.Produto.ToListAsync());
            return View(await _jogoService.GetProdutosAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var prod = await _jogoService.getProdutoByIdAsync(id.Value);

            if( prod == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaService.GetCategoriasAsync();
            var viewModel = new JogoViewModel { Categorias = categorias };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            await _jogoService.InserirAsync(produto);
            return RedirectToAction("Index");
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Plataforma")] Produto produto)
          {
              if (ModelState.IsValid)
              {
                  _context.Add(produto);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(produto);
          }

          */

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _jogoService.getProdutoByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            List<Categoria> categorias = await _categoriaService.GetCategoriasAsync();
            JogoViewModel viewModel = new JogoViewModel
            {
                Produto = produto,
                Categorias = categorias
            };

            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JogoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Produto.Id)
            {
                return NotFound();
            }

            try
            {
                await _jogoService.EditarAsync(produtoViewModel.Produto);
            }catch(Exception e)
            {

            }

            return RedirectToAction( nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if( id != null)
            {
                var prod = await _jogoService.getProdutoByIdAsync(id.Value);
                if(prod == null)
                {
                    return NotFound();
                }else
                {
                    return View(prod);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _jogoService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            return await _context.Produto.AnyAsync(e => e.Id == id);
        }
    }
}
