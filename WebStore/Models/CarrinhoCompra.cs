using Microsoft.EntityFrameworkCore;
using WebStore.Context;

namespace WebStore.Models;

public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //obtem ou gera um Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribui o id do carrinho na Sessão
        session.SetString("CarrinhoId", carrinhoId);

        //retorna o carrinho com o contexto e o Id atribuído ao obtido
        return new CarrinhoCompra(context) { CarrinhoCompraId = carrinhoId };
    }

    public void AdicionarAoCarrinho(Produto produto)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s =>
            s.Produto.ProdutoId == produto.ProdutoId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem()
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Produto = produto,
                Quantidade = 1
            };
            _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();
    }

    public int RemoverDoCarrinho(Produto produto)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s =>
            s.Produto.ProdutoId == produto.ProdutoId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        var quatidadeLocal = 0;

        if (carrinhoCompraItem != null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quatidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
            }
        }

        _context.SaveChanges();
        return quatidadeLocal;
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
    {
        return CarrinhoCompraItems ?? (CarrinhoCompraItems =
               _context.CarrinhoCompraItems
               .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
               .Include(s => s.Produto)
               .ToList());
    }

    public void LimparCarrinho()
    {
        var carrinhoItems = _context.CarrinhoCompraItems
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItems.RemoveRange(carrinhoItems);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItems
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.Produto.Preco * c.Quantidade)
            .Sum();

        return total;
    }
}

