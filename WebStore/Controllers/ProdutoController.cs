using Microsoft.AspNetCore.Mvc;
using WebStore.Repositories.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoRepository _productRepository;

    public ProdutoController(IProdutoRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult List()
    {
        //ViewData["Titulo"] = "Todos os Produtos";
        //var produto = _productRepository.Produtos;
        //return View(produto);

        var produtoListViewModel = new ProdutoListViewModel();
        produtoListViewModel.Produtos = _productRepository.Produtos;
        produtoListViewModel.CategoriaAtual = "Categoria Atual";

        return View(produtoListViewModel);
    }
}