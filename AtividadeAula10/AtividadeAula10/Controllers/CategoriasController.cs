using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAula10.Services;
using Microsoft.AspNetCore.Mvc;
using AtividadeAula10.Models;

namespace AtividadeAula10.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategoriasAsync();
            return View( categorias );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.InserirAsync(categoria);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if(id == categoria.Id)
            {
                await _categoriaService.EditarAsync(categoria);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }
            else
            {
                var categoria = await _categoriaService.GetCategoriaByIdAsync(id.Value);
                if(categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(categoria);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
