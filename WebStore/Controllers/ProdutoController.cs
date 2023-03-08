using Microsoft.AspNetCore.Mvc;
using WebStore.Repositories.Interfaces;

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
        var produto = _productRepository.Produtos;
        return View(produto);
    }
}