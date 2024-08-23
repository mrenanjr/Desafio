using Desafio.Application.Extensions;
using Desafio.Application.Interfaces;
using Desafio.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Desafio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;
        public HomeController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetAllAsync();
            ViewBag.Produtos = produtos;
            TempData.Put("Produtos", produtos);

            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var produtos = TempData.Get<List<ProdutoViewModel>>("Produtos");

            if(produtos != null) ViewBag.Produtos = produtos;
            else ViewBag.Produtos = await _produtoService.GetAllAsync();

            ViewBag.ProdutoId = id;

            var prod = await _produtoService.GetByIdAsync(id);
            return View("Index", prod);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(viewModel.Id.HasValue) await _produtoService.UpdateAsync((long)viewModel.Id.Value, viewModel);
                else await _produtoService.CreateAsync(viewModel);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long Id)
        {
            await _produtoService.DeleteAsync(Id);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _produtoService.DeleteAllAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}