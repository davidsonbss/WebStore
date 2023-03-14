using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class HomeController : Controller
{
    private readonly IProdutoRepository _produtoRepository;

    public HomeController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            ProdutosDestaques = _produtoRepository.ProdutosDestaques
        };

        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}