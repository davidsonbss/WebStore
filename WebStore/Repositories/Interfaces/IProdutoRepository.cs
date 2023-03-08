using WebStore.Models;

namespace WebStore.Repositories.Interfaces;

public interface IProdutoRepository
{
    IEnumerable<Produto> Produtos { get; }
    IEnumerable<Produto> ProdutosDestaques { get; }
    Produto GetProdutoById(int produtoId);
}
