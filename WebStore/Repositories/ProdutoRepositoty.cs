using Microsoft.EntityFrameworkCore;
using WebStore.Context;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories
{
    public class ProdutoRepositoty : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepositoty(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos
                                    .Include(c => c.Categoria);
        public IEnumerable<Produto> ProdutosDestaques => _context.Produtos
                                    .Where(p => p.ProdutoDestaque)
                                    .Include(c => c.Categoria);
        public Produto GetProdutoById(int produtoId)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

        }
    }
        
}
